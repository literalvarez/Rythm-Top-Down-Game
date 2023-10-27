using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerOnDestroyLogic : MonoBehaviour
{
    public OnPlayerDestroy RealLogic;
    void OnDestroy()
    {
        RealLogic.RealOnDestroy();      
    }
}
