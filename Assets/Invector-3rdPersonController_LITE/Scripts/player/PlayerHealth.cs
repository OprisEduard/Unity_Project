using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;  
    public int currentHealth;
    public Transform respawnPoint;

    void Start()
    {
        currentHealth = maxHealth;  
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;  
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);  

        if (currentHealth <= 0)
        {
            Die();  
        }
    }
    private void Die()
    {
        Debug.Log("Player died!");
        Respawn();  
    }

    private void Respawn()
    {
       
        transform.position = respawnPoint.position;
        currentHealth = maxHealth; 
        Debug.Log("Player respawned!");
    }
}
