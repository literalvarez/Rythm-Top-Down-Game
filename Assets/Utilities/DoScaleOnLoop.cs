using UnityEngine;
using DG.Tweening;

public class DoScaleOnLoop : MonoBehaviour
{
    [SerializeField] private Ease easeType = Ease.Linear;
    [SerializeField] private Vector3 initialScale = Vector3.one;
    [SerializeField] private Vector3 scaleAmount = new Vector3(1.5f, 1.5f, 1.5f);
    [SerializeField] private float tweenTime = 1.0f;

    private void OnEnable()
    {
        // Set the initial scale of the GameObject
        transform.localScale = initialScale;

        // Call the ScaleOnLoop method to start the scaling loop
        ScaleOnLoop();
    }

    private void ScaleOnLoop()
    {
        // Use DoTween to scale the GameObject with the specified parameters
        transform.DOScale(scaleAmount, tweenTime)
            .SetEase(easeType)
            .OnComplete(() =>
            {
                // OnComplete callback is triggered when the tween is complete
                // Reverse the scale tween by swapping initialScale and scaleAmount
                Vector3 temp = initialScale;
                initialScale = scaleAmount;
                scaleAmount = temp;

                // Restart the scaling loop by calling ScaleOnLoop recursively
                ScaleOnLoop();
            });
    }

    // Optional: You can add a method to stop the scaling loop if needed
    private void StopScaleLoop()
    {
        // Kill any active tweens on the GameObject
        DOTween.Kill(transform);
    }
}
