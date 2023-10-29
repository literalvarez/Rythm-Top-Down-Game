using TMPro;
using UnityEngine;
using System.Collections;
public class TUiextFaders : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro; // Use TextMeshProUGUI for TMPro UI text
    public float duration = 5f; // Duration in seconds for the fade effect
    [SerializeField] private float fadeAmount = 0.3f;

    void Start()
    {
        // Start the fading process when the script is enabled
        StartCoroutine(UiTextFadeOut());
    }

    public IEnumerator UiTextFadeOut()
    {
        float elapsedTime = 0f;
        Color originalColor = textMeshPro.color;
        while (elapsedTime < duration)
        {
            // Calculate the alpha value based on the elapsed time and duration
            float alpha = Mathf.Lerp(originalColor.a, fadeAmount, elapsedTime / duration);

            // Set the new alpha value to the TMP UI text object's color
            textMeshPro.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);

            // Update the elapsed time
            elapsedTime += Time.deltaTime;
            yield return null; // Wait for the end of the frame before continuing the loop
        }

        // Ensure the alpha is exactly 0 at the end of the coroutine
        textMeshPro.color = new Color(originalColor.r, originalColor.g, originalColor.b, fadeAmount);
    }
}