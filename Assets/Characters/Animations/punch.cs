using UnityEngine;

public class Punch : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        // Get the Animator component attached to the GameObject
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            UnityEngine.Debug.LogError("Animator component not found on Gioana!");
        }
    }

    void Update()
    {
        // Trigger animation on left mouse click
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("Punch");
        }
    }
}
