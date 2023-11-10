using UnityEngine;

public class PlayOnDeath : MonoBehaviour
{
    public GameObject prefabToSpawn; // Assign the prefab to spawn in the Inspector
    public float audioDuration = 2f; // Duration of the audio clip

    private void OnDestroy()
    {
        SpawnPrefab();
    }

    private void SpawnPrefab()
    {
        if (prefabToSpawn != null)
        {
            GameObject spawnedPrefab = Instantiate(prefabToSpawn, transform.position, Quaternion.identity);
            AudioSource audioSource = spawnedPrefab.GetComponent<AudioSource>();

            if (audioSource != null)
            {
                // Randomize pitch and volume
                float pitchRandomization = Random.Range(-0.1f, 0.1f);
                float volumeRandomization = Random.Range(-0.1f, 0.1f);

                audioSource.pitch += pitchRandomization;
                audioSource.volume += volumeRandomization;

                audioSource.Play(); // Play the audio with randomized pitch and volume
                Destroy(spawnedPrefab, audioDuration); // Destroy the prefab after the specified duration
            }
            else
            {
                Debug.LogWarning("Prefab does not have an AudioSource component.");
            }
        }
        else
        {
            Debug.LogWarning("Prefab to spawn is not assigned.");
        }
    }
}
