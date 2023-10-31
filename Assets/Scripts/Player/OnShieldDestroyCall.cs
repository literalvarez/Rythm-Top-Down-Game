using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnShieldDestroyCall : MonoBehaviour
{
    public OnShieldDestroy ShieldDestroyLogic;
    void OnDestroy()
    {
        ShieldDestroyLogic.ShieldOnDestroy();
    }
}
