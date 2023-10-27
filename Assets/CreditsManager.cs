using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CreditsManager : MonoBehaviour
{
    public UnityEvent firstEvent;
    public UnityEvent secondEvent;
    public UnityEvent thirdEvent;

    public float TimeToFirstEvent = 5f;
    public float TimeToSecondEvent = 5f;
    public float TimeToThirdEvent = 5f;


    void Start()
    {
        // Start the event sequence
        StartCoroutine(CallEventsWithDelay());
    }

    IEnumerator CallEventsWithDelay()
    {
        // Wait for 5 seconds
        yield return new WaitForSeconds(TimeToFirstEvent);

        // Call the first event after waiting for 5 seconds
        firstEvent.Invoke();

        // Wait for another 5 seconds
        yield return new WaitForSeconds(TimeToSecondEvent);

        // Call the second event
        secondEvent.Invoke();

        // Wait for another 5 seconds
        yield return new WaitForSeconds(TimeToThirdEvent);

        // Call the third event
        thirdEvent.Invoke();
    }
    
}

