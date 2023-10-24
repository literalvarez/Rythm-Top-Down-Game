using UnityEngine;
using TMPro;

public class TimerController : MonoBehaviour
{
    public float totalTimeInSeconds = 300f; // Total time in seconds (5 minutes)
    private float currentTimeInSeconds;
    public TMP_Text timerText;

    void Start()
    {
        currentTimeInSeconds = totalTimeInSeconds;
        UpdateTimerDisplay();
    }

    void Update()
    {
        // Update the timer every frame
        if (currentTimeInSeconds > 0f)
        {
            currentTimeInSeconds -= Time.deltaTime;
            UpdateTimerDisplay();
        }
        else
        {
            // Timer has reached zero, you can handle the timer completion logic here
            Debug.Log("Time's up!");
        }
    }

    void UpdateTimerDisplay()
    {
        // Convert time to minutes and seconds
        int minutes = Mathf.FloorToInt(currentTimeInSeconds / 60f);
        int seconds = Mathf.FloorToInt(currentTimeInSeconds % 60f);

        // Update TMP text to display the timer
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
