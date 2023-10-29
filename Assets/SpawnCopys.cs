using UnityEngine;

public class SpawnCopys : MonoBehaviour
{
    public GameObject prefabToSpawn; // Reference to the prefab you want to spawn
    public float spawnDistance = 1.0f; // Distance from the object's position to spawn the prefabs
    private bool hasSpawned = false; // Flag to track if the method has been executed

    // Public method that can be called externally to spawn the prefab and destroy the game object
    public void SpawnCopyAndDestroy()
    {
        // Check if the method has already been executed
        if (!hasSpawned)
        {
            // Calculate offset based on object's rotation
            Vector2 offset = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z) * Vector2.up * spawnDistance;

            // Spawn above the object
            SpawnPrefabAtPosition((Vector2)transform.position + offset);
            // Spawn below the object
            SpawnPrefabAtPosition((Vector2)transform.position - offset);

            // Set the flag to true to indicate that the method has been executed
            hasSpawned = true;

            // Destroy the game object
            Destroy(gameObject);
        }
    }

    private void SpawnPrefabAtPosition(Vector2 spawnPosition)
    {
        Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
    }
}
