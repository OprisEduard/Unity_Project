using UnityEngine;

public class EnemyPunch : MonoBehaviour
{
    private Animator animator;
    public float attackRange = 2f;  // Distanta la care inamicul poate ataca
    public float attackCooldown = 2f;  // Timp între atacuri
    private float lastAttackTime = 0f;
    public Transform player;  // Referinta catre jucator

    void Start()
    {
        // Obtine componenta Animator
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("Animator component not found on enemy!");
        }
    }

    void Update()
    {
        // Verifica distanta dintre inamic si player
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= attackRange && Time.time >= lastAttackTime + attackCooldown)
        {
            Attack();  // Ataca jucatorul
        }
    }

    private void Attack()
    {
        // Declan?eaz? anima?ia de punch
        animator.SetTrigger("Punch");
        Debug.Log("Enemy attacks!");
        lastAttackTime = Time.time;  // Reseteaz? timer-ul pentru atac
    }
}
