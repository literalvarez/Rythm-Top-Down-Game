using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public GameObject[] powerUpPrefabs;
    public Transform[] spawnPoints;
    public float spawnInterval = 5f;

    private void Start()
    {
        // Invoke the SpawnPowerUp method every spawnInterval seconds
        InvokeRepeating("SpawnPowerUp", 0f, spawnInterval);
    }

    private void SpawnPowerUp()
    {
        // Select a random power-up prefab from the array
        GameObject randomPowerUpPrefab = powerUpPrefabs[Random.Range(0, powerUpPrefabs.Length)];

        // Select a random transform from the array
        Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // Set the rotation to 45 degrees in the Z-axis
        Quaternion rotation = Quaternion.Euler(0f, 0f, 45f);

        // Instantiate the randomPowerUpPrefab at the randomSpawnPoint position with the specified rotation
        Instantiate(randomPowerUpPrefab, randomSpawnPoint.position, rotation);
    }
}
