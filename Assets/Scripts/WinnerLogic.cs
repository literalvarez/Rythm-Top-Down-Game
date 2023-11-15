using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class WinnerLogic : MonoBehaviour
{
    public UnityEvent onWin;
    public void Winner()
    {
        onWin.Invoke();
        //StartCoroutine(RestartSceneCoroutine());
    }

    public void RestartScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator RestartSceneCoroutine()
    {
        // Wait for 1 seconds before restarting the scene.
        yield return new WaitForSeconds(10f);

        // Restart the current scene.
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
