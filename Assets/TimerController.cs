using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class TimerController : MonoBehaviour
{
    public float totalTimeInSeconds = 300f; // Total time in seconds (5 minutes)
    private float currentTimeInSeconds;
    public TMP_Text timerText;

    public UnityEvent on1MinutePassed;
    public UnityEvent on2MinutesPassed;
    public UnityEvent on3MinutesPassed;
    public UnityEvent on4MinutesPassed;
    public UnityEvent on5MinutesPassed;

    private bool isPaused = false;

    void Start()
    {
        currentTimeInSeconds = totalTimeInSeconds;
        UpdateTimerDisplay();
    }

    void Update()
    {
        if (!isPaused && currentTimeInSeconds > 0f)
        {
            currentTimeInSeconds -= Time.deltaTime;
            UpdateTimerDisplay();

            // Check if specific minutes have passed and trigger corresponding events
            if (currentTimeInSeconds <= totalTimeInSeconds - 60f)
            {
                on1MinutePassed.Invoke();
            }

            if (currentTimeInSeconds <= totalTimeInSeconds - 120f)
            {
                on2MinutesPassed.Invoke();
            }

            if (currentTimeInSeconds <= totalTimeInSeconds - 180f)
            {
                on3MinutesPassed.Invoke();
            }

            if (currentTimeInSeconds <= totalTimeInSeconds - 240f)
            {
                on4MinutesPassed.Invoke();
            }

            if (currentTimeInSeconds <= 0f)
            {
                on5MinutesPassed.Invoke();
                // Timer has reached zero, you can handle the timer completion logic here
                Debug.Log("Time's up!");
            }
        }
    }

    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(currentTimeInSeconds / 60f);
        int seconds = Mathf.FloorToInt(currentTimeInSeconds % 60f);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    // Method to pause the timer
    public void PauseTimer()
    {
        isPaused = true;
    }

    // Method to resume the timer
    public void ResumeTimer()
    {
        isPaused = false;
    }
}
