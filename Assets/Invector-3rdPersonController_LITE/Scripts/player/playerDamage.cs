using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int enemyDamage = 10;  
    public float attackCooldown = 2f;   
    private float lastAttackTime = 0f;   

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AttackPlayer(collision.gameObject);
        }
    }

    private void AttackPlayer(GameObject player)
    {
        if (Time.time - lastAttackTime >= attackCooldown)   
        {
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.TakeDamage(enemyDamage);
                Debug.Log($"Enemy attacked player! Damage: {enemyDamage}");
            }

            lastAttackTime = Time.time; 
        }
    }
}
