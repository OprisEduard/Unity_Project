using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    public Slider healthSlider;  
    public PlayerHealth playerHealth;  

    void Start()
    {
      
        healthSlider = GetComponentInChildren<Slider>();  
        playerHealth = Object.FindFirstObjectByType<PlayerHealth>();
      
        healthSlider.maxValue = playerHealth.maxHealth;
        healthSlider.value = playerHealth.maxHealth;

    
    }
    //aparet se poate ca alte scripturi sa modifice valorile în timpul Update() si de asta am folosit lateUpdate
    //ca nu se actualiza health barul cand primea player ul damage 
    void LateUpdate()
    {
        if (playerHealth != null && healthSlider != null)
        {
            healthSlider.value = playerHealth.currentHealth;
            Debug.Log("Updating health bar in LateUpdate: " + playerHealth.currentHealth);
        }
    }


}
