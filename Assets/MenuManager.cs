using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // M�todo p�blico para cargar la escena de juego
    public void LoadPlayScene()
    {
        // Puedes cambiar "PlayScene" al nombre de tu escena de juego
        SceneManager.LoadScene("MainGame");
    }
}
