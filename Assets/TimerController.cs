using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class TimerController : MonoBehaviour
{
    public float totalTimeInSeconds = 300f; // Total time in seconds (5 minutes)
    private float currentTimeInSeconds;
    public TMP_Text timerText;
    public UnityEvent MinuteTransition;
    public UnityEvent on1MinutePassed;
    public UnityEvent on2MinutesPassed;
    public UnityEvent on3MinutesPassed;
    public UnityEvent on4MinutesPassed;
    public UnityEvent on5MinutesPassed;

    private bool isPaused = false;

    private bool minuteEventInvoked = false;
    private bool minute1EventInvoked = false;
    private bool minute2EventInvoked = false;
    private bool minute3EventInvoked = false;
    private bool minute4EventInvoked = false;

    private bool minuteTransition55EventInvoked = false;
    private bool minuteTransition115EventInvoked = false;
    private bool minuteTransition175EventInvoked = false;
    private bool minuteTransition235EventInvoked = false;

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
            if (currentTimeInSeconds <= totalTimeInSeconds - 60f && !minuteEventInvoked)
            {
                on1MinutePassed.Invoke();
                minuteEventInvoked = true;
            }

            if (currentTimeInSeconds <= totalTimeInSeconds - 120f && !minute1EventInvoked)
            {
                on2MinutesPassed.Invoke();
                minute1EventInvoked = true;
            }

            if (currentTimeInSeconds <= totalTimeInSeconds - 180f && !minute2EventInvoked)
            {
                on3MinutesPassed.Invoke();
                minute2EventInvoked = true;
            }

            if (currentTimeInSeconds <= totalTimeInSeconds - 240f && !minute3EventInvoked)
            {
                on4MinutesPassed.Invoke();
                minute3EventInvoked = true;
            }

            if (currentTimeInSeconds <= 0f && !minute4EventInvoked)
            {
                on5MinutesPassed.Invoke();
                minute4EventInvoked = true;
                // Timer has reached zero, you can handle the timer completion logic here
                Debug.Log("Time's up!");
            }

            if (currentTimeInSeconds <= totalTimeInSeconds - 55f)
            {
                MinuteTransition.Invoke();
            }

            if (currentTimeInSeconds <= totalTimeInSeconds - 55f && !minuteTransition55EventInvoked)
            {
                MinuteTransition.Invoke();
                minuteTransition55EventInvoked = true;
            }

            if (currentTimeInSeconds <= totalTimeInSeconds - 115f && !minuteTransition115EventInvoked)
            {
                MinuteTransition.Invoke();
                minuteTransition115EventInvoked = true;
            }

            if (currentTimeInSeconds <= totalTimeInSeconds - 175f && !minuteTransition175EventInvoked)
            {
                MinuteTransition.Invoke();
                minuteTransition175EventInvoked = true;
            }

            if (currentTimeInSeconds <= totalTimeInSeconds - 235f && !minuteTransition235EventInvoked)
            {
                MinuteTransition.Invoke();
                minuteTransition235EventInvoked = true;
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
