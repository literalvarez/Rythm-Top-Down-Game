using System.Collections;
using UnityEngine;
using UnityEngine.Events;


public class AutoShootPowerUp : MonoBehaviour
{
    public float duration = 10f; // Duration of the power-up in seconds
    public float interval = 2f; // Time interval between each shot
    public Color startColor = Color.green;
    public Color endColor = Color.red;
    public UnityEvent onShoot;

    public SpriteRenderer spriteRenderer;
    private Color originalColor;
    private float timer;

    private void OnEnable()
    {
        StartPower();
    }

    private void StartPower()
    {
        originalColor = spriteRenderer.color;

        // Set the color to the start color
        spriteRenderer.color = startColor;

        // Start the timer
        timer = duration;

        // Invoke Repeating the Shoot method with the specified interval
        InvokeRepeating("Shoot", 0f, interval);

        // Start a coroutine to handle color transition during the power-up duration
        StartCoroutine(ColorTransition());
    }

    private void Shoot()
    {
        // Trigger the Unity Event
        onShoot.Invoke();
    }

    private IEnumerator ColorTransition()
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            // Lerp color from startColor to endColor over time
            spriteRenderer.color = Color.Lerp(startColor, endColor, elapsedTime / duration);

            // Increment the elapsed time
            elapsedTime += Time.deltaTime;

            // Wait for the next frame
            yield return null;
        }

        // Set color to EndColor when the transition is complete
        spriteRenderer.color = endColor;
    }

    private void OnDisable()
    {
        // Set color to EndColor when the power-up is disabled
        spriteRenderer.color = endColor;

        // Cancel the invoke repeating
        CancelInvoke("Shoot");
    }
}
