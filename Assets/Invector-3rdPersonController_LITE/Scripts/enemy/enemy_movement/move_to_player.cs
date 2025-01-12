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
            // Calculeaz? direc?ia c?tre player
            Vector3 direction = (player.position - transform.position).normalized;

            // Seteaz? rota?ia inamicului c?tre direc?ia calculat?
            if (direction != Vector3.zero)
            {
                Quaternion lookRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * speed);
            }

            // Muta inamicul spre player
            transform.position += direction * speed * Time.deltaTime;
        }
    }

}

