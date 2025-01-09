using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHits = 4; 
    private int currentHits = 0; 

    private void OnCollisionEnter(Collision collision)
    {
      
        if (collision.gameObject.CompareTag("Player"))
        {
            currentHits++; 

            if (currentHits >= maxHits)
            {
                Destroy(gameObject); 
            }
        }
    }
}
