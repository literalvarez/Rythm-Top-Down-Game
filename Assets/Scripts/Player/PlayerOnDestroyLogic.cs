using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerOnDestroyLogic : MonoBehaviour
{
    void OnDestroy()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
