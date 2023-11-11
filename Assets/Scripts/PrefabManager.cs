using UnityEngine;
using UnityEngine.SceneManagement;

public class PrefabManager : MonoBehaviour
{
    public GameObject prefabToSpawn; // Reference to the prefab you want to spawn

    private void Start()
    {
        DontDestroyOnLoad(gameObject); // Don't destroy this object when loading a new scene

        SceneManager.sceneLoaded += OnSceneLoaded; // Register the method to be called when a scene is loaded
    }

    public void SpawnPrefabs(Vector2 spawnPosition)
    {
        // Calculate offset based on object's rotation
        Vector2 offset = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z) * Vector2.up;

        // Spawn above the object
        Instantiate(prefabToSpawn, spawnPosition + offset, Quaternion.identity);
        // Spawn below the object
        Instantiate(prefabToSpawn, spawnPosition - offset, Quaternion.identity);
    }

    public void DestroyPrefabs(bool sceneRestart)
    {
        // Destroy spawned prefabs
        foreach (GameObject prefab in GameObject.FindGameObjectsWithTag("SpawnedPrefab"))
        {
            Destroy(prefab);
        }

        // Additional logic for scene restart if needed
        if (sceneRestart)
        {
            // Handle scene restart logic here
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Handle scene loaded logic if needed
    }
}
