using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform spawnPoint;
    public float spawnCooldown = 2f; // Cooldown in seconds between spawns
    public int numberOfEnemiesToSpawn = 5; // Number of enemies to spawn

    private float lastSpawnTime;

    private void Start()
    {
        lastSpawnTime = Time.time;
    }

    private void Update()
    {
        // Check if enough time has passed since the last spawn
        if (Time.time - lastSpawnTime >= spawnCooldown)
        {
            // Spawn enemies
            SpawnEnemies();
            // Update last spawn time
            lastSpawnTime = Time.time;
        }
    }

    private void SpawnEnemies()
    {
        for (int i = 0; i < numberOfEnemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
        }
    }
}
