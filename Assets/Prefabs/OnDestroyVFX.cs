using UnityEngine;

public class OnDestroyVFX : MonoBehaviour
{
    public GameObject particlePrefab; // Particle System Prefab

    void OnDestroy()
    {
        // Instantiate the particle system at the position of the destroyed game object
        GameObject particleSystem = Instantiate(particlePrefab, transform.position, Quaternion.identity);

        // Get the duration of the particle system
        float particleDuration = particleSystem.GetComponent<ParticleSystem>().main.duration;

        // Destroy the particle system after it has finished playing
        Destroy(particleSystem, particleDuration);
    }
}
