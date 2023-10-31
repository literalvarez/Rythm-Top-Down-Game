using UnityEngine;
using DG.Tweening;

public class ScaleAnimation : MonoBehaviour
{
    // Duration of the animation in seconds
    public float animationDuration = 1f;

    // Amount to grow the object
    public Vector3 targetScale = new Vector3(2f, 2f, 2f);

    // Ease type for the animation
    [SerializeField]
    private Ease easeType = Ease.OutQuad;

    // Method to trigger the scale animation
    public void PlayScaleAnimation()
    {
        // Get the current scale of the object
        Vector3 originalScale = transform.localScale;

        // Use DoTween to animate the scale from originalScale to targetScale and back to originalScale
        transform.DOScale(targetScale, animationDuration).SetEase(easeType).OnComplete(() =>
        {
            // When the animation is complete, revert back to the original scale
            transform.DOScale(originalScale, animationDuration).SetEase(easeType);
        });
    }
}
