using UnityEngine;

public class CollectItem : MonoBehaviour
{
    public int points = 10; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
            if (scoreManager != null)
            {
                scoreManager.AddScore(points); 
            }

            Destroy(gameObject); 
        }
    }
}
