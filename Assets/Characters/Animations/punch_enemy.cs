using UnityEngine;

public class EnemyPunch : MonoBehaviour
{
    private Animator animator;
    public float attackRange = 2f; 
    public float attackCooldown = 2f;  
    private float lastAttackTime = 0f;
    public Transform player;  

    void Start()
    {
        
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("Animator component not found on enemy!");
        }
    }

    void Update()
    {
        
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= attackRange && Time.time >= lastAttackTime + attackCooldown)
        {
            Attack();
        }
    }

    private void Attack()
    {

        Debug.Log("Enemy attacks!");
        lastAttackTime = Time.time;
    }
}
