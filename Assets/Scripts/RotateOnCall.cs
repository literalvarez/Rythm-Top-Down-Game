using UnityEngine;
using DG.Tweening;

public class RotateOnCall : MonoBehaviour
{
    public float rotationSpeed = 90f; // Rotation speed in degrees per second
    public Ease easeType = Ease.OutQuad; // Ease type for the rotation animation
    public float rotationDuration = 1f; // Duration for rotating the object
    public GameObject objectToRotate; // Reference to the object you want to rotate

    private void OnEnable()
    {
        RotateGameObject();
    }

    private void RotateGameObject()
    {
        // Calculate the target rotation based on the rotation speed and duration
        Vector3 targetRotation = objectToRotate.transform.eulerAngles + new Vector3(0f, 0f, rotationSpeed * rotationDuration);

        // Rotate the object using DoTween with customizable parameters
        objectToRotate.transform.DORotate(targetRotation, rotationDuration)
            .SetEase(easeType)
            .OnComplete(() =>
            {
                // This code block will be executed after rotation is complete
                Debug.Log("Rotation complete!");
            });
    }
}
