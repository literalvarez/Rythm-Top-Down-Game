using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;

public class PauseGame : MonoBehaviour
{
    [SerializeField]
    private AudioSource[] audioSources; // Array of AudioSources to pause and resume

    [SerializeField]
    private UnityEvent doWhenPause; // UnityEvent to trigger when game is paused

    [SerializeField]
    private UnityEvent doWhenUnpause; // UnityEvent to trigger when game is unpaused

    private bool isPaused = false;

    void Update()
    {
        // Check if the Escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StartOrPause();
        }       
    }
    public void StartOrPause()
    {
        // Toggle the pause state
        isPaused = !isPaused;

        // Pause or resume the game based on the pause state
        if (isPaused)
        {
            Time.timeScale = 0f; // Set time scale to 0 to pause the game

            // Pause all audio sources associated with active GameObjects
            foreach (var audioSource in audioSources)
            {
                if (audioSource.gameObject.activeInHierarchy)
                {
                    audioSource.Pause();
                }
            }

            // Trigger UnityEvent for pause
            doWhenPause.Invoke();
        }
        else
        {
            Time.timeScale = 1f; // Set time scale back to 1 to resume the game

            // Resume audio sources associated with active GameObjects
            foreach (var audioSource in audioSources)
            {
                if (audioSource.gameObject.activeInHierarchy)
                {
                    audioSource.UnPause();
                }
            }

            // Trigger UnityEvent for unpause
            doWhenUnpause.Invoke();
        }
    }

    public void PauseToLvLUp()
    {
        // Toggle the pause state
        isPaused = !isPaused;

        // Pause or resume the game based on the pause state
        if (isPaused)
        {
            Time.timeScale = 0f; // Set time scale to 0 to pause the game

            // Pause all audio sources associated with active GameObjects
            foreach (var audioSource in audioSources)
            {
                if (audioSource.gameObject.activeInHierarchy)
                {
                    audioSource.Pause();
                }
            }
        }
        else
        {
            Time.timeScale = 1f; // Set time scale back to 1 to resume the game

            // Resume audio sources associated with active GameObjects
            foreach (var audioSource in audioSources)
            {
                if (audioSource.gameObject.activeInHierarchy)
                {
                    audioSource.UnPause();
                }
            }
        }
    }
}