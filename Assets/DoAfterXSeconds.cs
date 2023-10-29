using UnityEngine;
using UnityEngine.Events;

public class DoAfterXSeconds : MonoBehaviour
{
    public float delayInSeconds = 2f; // Time in seconds after which the event should be invoked
    private bool hasInvoked = false; // Flag to ensure the event is invoked only once

    public UnityEvent onTimerComplete; // UnityEvent that will be invoked after X seconds

    private void Start()
    {
        // Invoke the DoAfterXSeconds method after the specified delayInSeconds
        Invoke("InvokeEvent", delayInSeconds);
    }

    private void InvokeEvent()
    {
        // Check if the event has not been invoked yet
        if (!hasInvoked)
        {
            // Invoke the UnityEvent
            onTimerComplete.Invoke();
            hasInvoked = true; // Set the flag to true to prevent multiple invocations
        }
    }
}
