using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerOnDestroyLogic : MonoBehaviour
{
    public OnPlayerDestroy RealLogic;
    void OnDestroy()
    {
        // Only run game over when the player dies, not when the scene closes
        if (SceneTeardown.IsTearingDown || RealLogic == null) return;

        RealLogic.RealOnDestroy();
    }
}
