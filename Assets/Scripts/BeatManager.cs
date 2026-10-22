using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BeatManager : MonoBehaviour
{
    [SerializeField] private float _bpm;
    [SerializeField] private AudioSource _audioSource; 
    [SerializeField] private Intervals[] _intervals;

    private void Update()
    {
        // Song position minus the player's audio delay, so beats fire when the player hears them
        float songTime = (float)_audioSource.timeSamples / _audioSource.clip.frequency - AudioOffset.Seconds;
        if (songTime < 0f) return; // The first beat hasn't reached the player's ears yet

        foreach (Intervals interval in _intervals)
        {
            float sampledTime = songTime / interval.GetIntervalLength(_bpm);
            interval.CheckForNewInterval(sampledTime);
        }
    }
        [System.Serializable]
    public class Intervals
    {
        [SerializeField] private float _steps; [SerializeField] private UnityEvent _trigger; private int _lastInterval;
        public float GetIntervalLength(float bpm)
        {
            return 60f / (bpm * _steps);
        }

        public void CheckForNewInterval(float interval)
        {
            if (Mathf.FloorToInt(interval) != _lastInterval)
            {
                _lastInterval = Mathf.FloorToInt(interval);
                _trigger.Invoke();
            }
        }

    }
}
