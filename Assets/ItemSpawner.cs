using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject[] itemsToSpawn;  
    public int maxItems = 5; 
    public float spawnInterval = 5f;  
    public Vector3 spawnAreaSize = new Vector3(20f, 0f, 20f); 
    private int currentItems = 0;

    void Start()
    {
        InvokeRepeating(nameof(SpawnRandomItem), 2f, spawnInterval); 
    }

    void SpawnRandomItem()
    {
        if (currentItems < maxItems)
        {
            Vector3 randomPosition = GetRandomPosition();
            GameObject randomItem = itemsToSpawn[Random.Range(0, itemsToSpawn.Length)];
            Instantiate(randomItem, randomPosition, Quaternion.identity);
            currentItems++;
        }
    }

    Vector3 GetRandomPosition()
    {
        float x = Random.Range(-spawnAreaSize.x / 2f, spawnAreaSize.x / 2f);
        float z = Random.Range(-spawnAreaSize.z / 2f, spawnAreaSize.z / 2f);
        float y = 0f;  
        return new Vector3(x, y, z) + transform.position; 
    }

    public void ItemCollected()
    {
        currentItems--; 
    }
}
