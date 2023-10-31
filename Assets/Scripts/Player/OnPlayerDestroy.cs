using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class OnPlayerDestroy : MonoBehaviour
{
    public AudioSource DeathSFX;
    public UnityEvent onPlayerDestroy;
    public void RealOnDestroy()
    {
        DeathSFX.Play();
        onPlayerDestroy.Invoke();
        StartCoroutine(RestartSceneCoroutine());
    }

    IEnumerator RestartSceneCoroutine()
    {
        // Wait for 1 seconds before restarting the scene.
        yield return new WaitForSeconds(1f);

        // Restart the current scene.
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
