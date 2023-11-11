using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;

public class ScaleManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> objectsToScale = new List<GameObject>(); // List of objects to scale

    public Vector3 targetScale = new Vector3(2f, 2f, 2f); // Target scale size
    public Ease easeType = Ease.OutQuad; // Ease type for the scaling animation
    public float scaleDuration = 1f; // Duration for scaling the object
    public float restartDuration = 0.5f; // Duration for restarting the object's scale after scaling

    public void StartScaling()
    {
        // Apply scaling effect to each object in the list
        foreach (GameObject objectToScale in objectsToScale)
        {
            // Get the initial scale of the object
            Vector3 initialScale = objectToScale.transform.localScale;

            // Scale the object using DoTween with customizable parameters
            objectToScale.transform.DOScale(targetScale, scaleDuration)
                .SetEase(easeType)
                .OnComplete(() =>
                {
                    // Restart the object's scale after scaling
                    objectToScale.transform.DOScale(initialScale, restartDuration);
                });
        }
    }
}
