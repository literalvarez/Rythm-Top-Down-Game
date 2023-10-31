using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Method to close the game
    public void QuitGame()
    {
        // This will quit the game when running in the Unity Editor
        // and build the application when running as a standalone application
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}
