using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    public Slider healthSlider;  
    public PlayerHealth playerHealth;  

    void Start()
    {
    
        healthSlider.maxValue = playerHealth.maxHealth;
        healthSlider.value = playerHealth.maxHealth;
    }

    void Update()
    {

        void Update()
        {
            if (playerHealth == null || healthSlider == null)
            {
                Debug.LogError("Referinta null!");
                return;  
            }

            healthSlider.value = playerHealth.currentHealth;
        }
    }
}
