using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class OnPlayerDestroy : MonoBehaviour
{
    public AudioSource DeathSFX;
    public UnityEvent onPlayerDestroy;

    // True once the player has died this run. Stops score and enemy friendly fire after death.
    public static bool IsPlayerDead { get; private set; }

    private void Awake()
    {
        // Reset for each new run (scene load)
        IsPlayerDead = false;
    }

    public void RealOnDestroy()
    {
        IsPlayerDead = true;
        DeathSFX.Play();
        onPlayerDestroy.Invoke();
        //StartCoroutine(RestartSceneCoroutine());
    }

    IEnumerator RestartSceneCoroutine()
    {
        // Wait for 1 seconds before restarting the scene.
        yield return new WaitForSeconds(1f);

        // Restart the current scene.
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
