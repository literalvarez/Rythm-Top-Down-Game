using UnityEngine;

public class BeatSoundPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource; // Reference to the AudioSource component
    public AudioClip beatSound; // The sound to play every beat

    void Start()
    {
        if (audioSource == null)
        {
            Debug.LogError("AudioSource reference not set in BeatSoundPlayer script.");
            return;
        }

        // Subscribe to the beat event from the BPMManager
        BPMManager.OnBeatEvent += PlayBeatSound;
    }

    void PlayBeatSound()
    {
        // Play the beat sound using the provided AudioSource
        audioSource.PlayOneShot(beatSound);
    }

    void OnDestroy()
    {
        // Unsubscribe from the beat event when the object is destroyed
        BPMManager.OnBeatEvent -= PlayBeatSound;
    }
}
