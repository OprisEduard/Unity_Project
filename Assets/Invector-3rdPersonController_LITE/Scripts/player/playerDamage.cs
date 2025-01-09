using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int enemyDamage = 10;  // D?un? produs? player-ului
    public float attackCooldown = 2f;  // Timpul minim între atacuri
    private bool hasBeenTouched = false;  // Verific? dac? a fost atins o dat?
    private float lastAttackTime = 0f;

    // Detect?m coliziunea cu player-ul
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && !hasBeenTouched)
        {
            hasBeenTouched = true;
            AttackPlayer(collision.gameObject);
        }
    }

    private void AttackPlayer(GameObject player)
    {
        if (Time.time - lastAttackTime >= attackCooldown)
        {
            // Presupunem c? player-ul are un script "PlayerHealth"
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
