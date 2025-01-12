using UnityEngine;

public class CollectItem : MonoBehaviour
{
    public int points = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ScoreManager scoreManager = Object.FindFirstObjectByType<ScoreManager>();
            ItemSpawner spawner = Object.FindFirstObjectByType<ItemSpawner>();  

            if (scoreManager != null)
            {
                scoreManager.AddScore(points);
            }

            if (spawner != null)
            {
                spawner.ItemCollected(); 
            }

            Destroy(gameObject);
        }
    }
}
