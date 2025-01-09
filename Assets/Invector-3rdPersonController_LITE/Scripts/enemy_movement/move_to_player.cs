using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    public Transform player; 
    public float speed = 3f; 
    private bool isChasing = false;

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            isChasing = true; 
        }
    }

    private void Update()
    {
        if (isChasing)
        {
          
            Vector3 direction = (player.position - transform.position).normalized; 
            transform.position += direction * speed * Time.deltaTime; 
        }
    }
}
