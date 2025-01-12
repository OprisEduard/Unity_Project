using UnityEngine;
using TMPro;  

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; 
    public int currentHealth; 
    public Transform respawnPoint;  
    public TextMeshProUGUI deathMessage; 
    public float deathMessageDuration = 3f;  

    void Start()
    {
        currentHealth = maxHealth; 
        deathMessage.gameObject.SetActive(false);  
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Current Health: " + currentHealth);
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Player died!");
        StartCoroutine(ShowDeathMessageAndRespawn());
    }

    private System.Collections.IEnumerator ShowDeathMessageAndRespawn()
    {
        
        deathMessage.gameObject.SetActive(true);
        yield return new WaitForSeconds(deathMessageDuration);
        deathMessage.gameObject.SetActive(false);
        Respawn();
    }

    private void Respawn()
    {
        transform.position = respawnPoint.position;   
        currentHealth = maxHealth;
        Debug.Log("Current Health: " + currentHealth);
        Debug.Log("Player respawned!");
    }
}
