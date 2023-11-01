using UnityEngine.Events;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    // UnityEvent to be invoked when the game starts
    public UnityEvent doToStart;

    private void Start()
    {
        Time.timeScale = 0f;
    }

    public void ToStartGame()
    {
        // Set the game's time scale to 1
        Time.timeScale = 1f;

        // Invoke the UnityEvent doToStart
        if (doToStart != null)
        {
            doToStart.Invoke();
        }
    }
}