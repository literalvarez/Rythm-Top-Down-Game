using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class OnShieldDestroy : MonoBehaviour
{
    public AudioSource ShieldSFX;
    public UnityEvent onShieldDestroy;
    public void ShieldOnDestroy()
    {
        ShieldSFX.Play();
        onShieldDestroy.Invoke();
    }

}
