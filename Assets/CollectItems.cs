using UnityEngine;

public class CollectItem : MonoBehaviour
{
    public int points = 10;   
    public ScoreManager scoreManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            if (scoreManager != null)
            {
                scoreManager.AddScore(points);

                Destroy(gameObject);
            }
    }
}
