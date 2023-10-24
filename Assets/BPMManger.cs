using UnityEngine;

public class BPMManager : MonoBehaviour
{
    public float bpm = 120f; // Beats per minute
    public float BeatInterval { get; private set; } // Time interval between beats
    private float nextBeatTime; // Time of the next beat

    public delegate void BeatAction();
    public static event BeatAction OnBeatEvent; // Event to notify other scripts when it's a beat

    void Start()
    {
        BeatInterval = 60f / bpm;
        nextBeatTime = Time.time + BeatInterval; // Schedule the first beat
    }

    void Update()
    {
        // Check for the next beat
        if (Time.time >= nextBeatTime)
        {
            nextBeatTime += BeatInterval; // Schedule the next beat
            OnBeat(); // Notify other scripts that it's a beat
        }
    }

    void OnBeat()
    {
        // Trigger the beat event
        if (OnBeatEvent != null)
        {
            OnBeatEvent();
        }
    }

    // Function to check if the current time is within the shooting window around the beat
    public bool IsOnBeat(float targetTime, float shootingWindow)
    {
        float windowStart = targetTime - shootingWindow / 2f;
        float windowEnd = targetTime + shootingWindow / 2f;
        return Time.time >= windowStart && Time.time <= windowEnd;
    }

    // Public property to access the next beat time
    public float NextBeatTime
    {
        get { return nextBeatTime; }
    }
}
