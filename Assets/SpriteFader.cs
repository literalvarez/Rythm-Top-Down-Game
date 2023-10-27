using UnityEngine;
using System.Collections;

public class SpriteFader : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public float duration = 10f; // Duration in seconds for the fade effects
    [SerializeField] private float fadeAmount = 0.5f;

    void Start()
    {
        // Start the fading process when the script is enabled
        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut()
    {
        float elapsedTime = 0f;
        Color spriteColor = spriteRenderer.color;
        while (elapsedTime < duration)
        {
            // Calculate the alpha value based on the elapsed time and duration
            float alpha = Mathf.Lerp(1f, fadeAmount, elapsedTime / duration);

            // Set the new alpha value to the sprite renderer's color
            spriteColor.a = alpha;
            spriteRenderer.color = spriteColor;

            // Update the elapsed time
            elapsedTime += Time.deltaTime;
            yield return null; // Wait for the end of the frame before continuing the loop
        }

        // Ensure the alpha is exactly 0 at the end of the coroutine
        spriteColor.a = fadeAmount;
        spriteRenderer.color = spriteColor;
    }
}
