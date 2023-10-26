using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerOnDestroyLogic : MonoBehaviour
{
    void OnDestroy()
    {
        StartCoroutine(RestartSceneCoroutine());
    }

    IEnumerator RestartSceneCoroutine()
    {
        // Wait for 3 seconds before restarting the scene.
        yield return new WaitForSeconds(3f);

        // Restart the current scene.
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
