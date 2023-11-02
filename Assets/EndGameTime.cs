using UnityEngine;
using TMPro;

public class EndGameTime : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Reference to the TextMeshProUGUI component
    private float elapsedTime = 0f; // Elapsed time in seconds

    private void Update()
    {
        elapsedTime += Time.deltaTime; // Increase the elapsed time by deltaTime

        // Calculate minutes and seconds
        int minutes = Mathf.FloorToInt(elapsedTime / 60f);
        int seconds = Mathf.FloorToInt(elapsedTime % 60f);

        // Display the timer in the desired format (MM:SS) using TextMeshPro
        string timerString = string.Format("{0:00}:{1:00}", minutes, seconds);
        timerText.text = "Time: " + timerString; // Update the TextMeshPro text
    }
}
