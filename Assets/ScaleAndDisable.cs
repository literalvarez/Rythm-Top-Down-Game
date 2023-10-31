using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

public class ScaleAndDisable : MonoBehaviour
{
    public Vector3 targetScale = new Vector3(2f, 2f, 2f); // Target scale size
    public Ease easeType = Ease.OutQuad; // Ease type for the scaling animation
    public float scaleDuration = 1f; // Duration for scaling the object
    public float restartDuration = 0.5f; // Duration for restarting the object's scale after scaling
    public GameObject objectToScale; // Reference to the object you want to scale
    public GameObject objectDeactivate; // Reference to the object you want to scale
    public UnityEvent onEndDo;

    private void OnEnable()
    {
        ScaleGameObject();
    }

    private void ScaleGameObject()
    {
        // Scale the object using DoTween with customizable parameters
        objectToScale.transform.DOScale(targetScale, scaleDuration)
            .SetEase(easeType)
            .OnComplete(() =>
            {
                // Restart the object's scale and turn it off after scaling
                objectToScale.transform.DOScale(Vector3.one, restartDuration)
                    .OnComplete(() =>
                    {
                        onEndDo.Invoke();
                        objectDeactivate.SetActive(false); // Turn off the object after scaling
                    });
            });
    }
}
