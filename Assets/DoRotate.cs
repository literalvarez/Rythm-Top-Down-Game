using UnityEngine;
using DG.Tweening;

public class DoRotate : MonoBehaviour
{
    public float rotationSpeed = 90f; // Rotation speed in degrees per second

    private void OnEnable()
    {
        RotateGameObject();
    }

    private void RotateGameObject()
    {
        // Calculate the rotation duration based on the rotation speed
        float rotationDuration = 360f / rotationSpeed;

        // Rotate the object using DoTween with customizable parameters
        transform.DORotate(new Vector3(0f, 0f, 360f), rotationDuration, RotateMode.FastBeyond360)
            .SetEase(Ease.Linear)
            .OnComplete(() =>
            {
                // Restart the rotation when it is complete
                RotateGameObject();
            });
    }

}
