using UnityEngine;
using DG.Tweening;

public class RotateOnCall : MonoBehaviour
{
    public Vector3 targetRotation = new Vector3(0f, 0f, 90f); // Target rotation angles
    public Ease easeType = Ease.OutQuad; // Ease type for the rotation animation
    public float rotationDuration = 1f; // Duration for rotating the object
    public GameObject objectToRotate; // Reference to the object you want to rotate

    private void OnEnable()
    {
        RotateGameObject();
    }

    private void RotateGameObject()
    {
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
