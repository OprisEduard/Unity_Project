using UnityEngine;

namespace Invector.vCharacterController
{
    public class vThirdPersonController : vThirdPersonAnimator
    {
		private Rigidbody rb;

        public int maxJumps = 2; 
        private int jumpsPerformed = 0;
        public float jumpForce = 20.0f; 

		
		void Awake()
        {
            rb = GetComponent<Rigidbody>();

            if (rb == null)
            {
                Debug.LogError("Rigidbody component is missing from this GameObject!");
            }
        }
        // Funcția care controlează mișcarea folosind Root Motion
        public virtual void ControlAnimatorRootMotion()
        {
            if (!this.enabled) return;

            if (inputSmooth == Vector3.zero)
            {
                transform.position = animator.rootPosition;
                transform.rotation = animator.rootRotation;
            }

            if (useRootMotion)
                MoveCharacter(moveDirection);
        }

        // Controlul tipului de locomotie (spre exemplu, mișcare liberă sau cu strafe)
        public virtual void ControlLocomotionType()
        {
            if (lockMovement) return;

            if (locomotionType.Equals(LocomotionType.FreeWithStrafe) && !isStrafing || locomotionType.Equals(LocomotionType.OnlyFree))
            {
                SetControllerMoveSpeed(freeSpeed);
                SetAnimatorMoveSpeed(freeSpeed);
            }
            else if (locomotionType.Equals(LocomotionType.OnlyStrafe) || locomotionType.Equals(LocomotionType.FreeWithStrafe) && isStrafing)
            {
                isStrafing = true;
                SetControllerMoveSpeed(strafeSpeed);
                SetAnimatorMoveSpeed(strafeSpeed);
            }

            if (!useRootMotion)
                MoveCharacter(moveDirection);
        }

        // Controlul rotației în funcție de direcția input-ului
        public virtual void ControlRotationType()
        {
            if (lockRotation) return;

            bool validInput = input != Vector3.zero || (isStrafing ? strafeSpeed.rotateWithCamera : freeSpeed.rotateWithCamera);

            if (validInput)
            {
                // Calcularea input-ului
                inputSmooth = Vector3.Lerp(inputSmooth, input, (isStrafing ? strafeSpeed.movementSmooth : freeSpeed.movementSmooth) * Time.deltaTime);

                Vector3 dir = (isStrafing && (!isSprinting || sprintOnlyFree == false) || (freeSpeed.rotateWithCamera && input == Vector3.zero)) && rotateTarget ? rotateTarget.forward : moveDirection;
                RotateToDirection(dir);
            }
        }

        // Actualizarea direcției de mișcare
        public virtual void UpdateMoveDirection(Transform referenceTransform = null)
        {
            if (input.magnitude <= 0.01)
            {
                moveDirection = Vector3.Lerp(moveDirection, Vector3.zero, (isStrafing ? strafeSpeed.movementSmooth : freeSpeed.movementSmooth) * Time.deltaTime);
                return;
            }

            if (referenceTransform && !rotateByWorld)
            {
                var right = referenceTransform.right;
                right.y = 0;
                var forward = Quaternion.AngleAxis(-90, Vector3.up) * right;
                moveDirection = (inputSmooth.x * right) + (inputSmooth.z * forward);
            }
            else
            {
                moveDirection = new Vector3(inputSmooth.x, 0, inputSmooth.z);
            }
        }

        // Controlul sprint-ului
        public virtual void Sprint(bool value)
        {
            var sprintConditions = (input.sqrMagnitude > 0.1f && isGrounded &&
                !(isStrafing && !strafeSpeed.walkByDefault && (horizontalSpeed >= 0.5 || horizontalSpeed <= -0.5 || verticalSpeed <= 0.1f)));

            if (value && sprintConditions)
            {
                if (input.sqrMagnitude > 0.1f)
                {
                    if (isGrounded && useContinuousSprint)
                    {
                        isSprinting = !isSprinting;
                    }
                    else if (!isSprinting)
                    {
                        isSprinting = true;
                    }
                }
                else if (!useContinuousSprint && isSprinting)
                {
                    isSprinting = false;
                }
            }
            else if (isSprinting)
            {
                isSprinting = false;
            }
        }

        // Controlul mișcării pe lateral 
        public virtual void Strafe()
        {
            isStrafing = !isStrafing;
        }

        // Funcția pentru Jump 
        public virtual void Jump()
        {
            if (CanJump())
            {
                jumpCounter = jumpTimer;
                isJumping = true;


                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

                if (input.sqrMagnitude < 0.1f)
                    animator.CrossFadeInFixedTime("Jump", 0.1f);
                else
                    animator.CrossFadeInFixedTime("JumpMove", 0.2f);

                jumpsPerformed++;
            }
        }

        // Verifică dacă personajul poate sări
        private bool CanJump()
        {
            if (isGrounded)
            {
            
                jumpsPerformed = 0;
                return true; 
            }

            return jumpsPerformed < maxJumps;
        }

        // Apelează funcția Jump din Update
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump(); 
            }
        }
    }
}
