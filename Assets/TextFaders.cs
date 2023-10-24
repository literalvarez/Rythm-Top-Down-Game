using UnityEngine;
using TMPro;
using System.Collections;

public class TextFaders : MonoBehaviour
{
    public TextMeshPro textMeshPro;
    public float duration = 10f; // Duration in seconds for the fade effect

    void Start()
    {
        // Start the fading process when the script is enabled
        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut()
    {
        float elapsedTime = 0f;
        Color originalColor = textMeshPro.color;
        while (elapsedTime < duration)
        {
            // Calculate the alpha value based on the elapsed time and duration
            float alpha = Mathf.Lerp(originalColor.a, 0f, elapsedTime / duration);

            // Set the new alpha value to the TMP text object's color
            textMeshPro.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);

            // Update the elapsed time
            elapsedTime += Time.deltaTime;
            yield return null; // Wait for the end of the frame before continuing the loop
        }

        // Ensure the alpha is exactly 0 at the end of the coroutine
        textMeshPro.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0f);
    }
}
