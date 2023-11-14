using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MusicSettings : MonoBehaviour
{
    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private Slider musicSlider;

    public AudioMixer audioMixer; // Reference to the Audio Mixer

    private void Start()
    {
        // Load saved volume settings from PlayerPrefs
        masterSlider.value = PlayerPrefs.GetFloat("MasterVolume", 1f);
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume", 1f);
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1f);

        // Set initial volumes
        SetVolume("MasterVolume", masterSlider.value);
        SetVolume("SFXVolume", sfxSlider.value);
        SetVolume("MusicVolume", musicSlider.value);
    }

    private void Update()
    {
        // Update volume levels in real-time
        SetVolume("MasterVolume", masterSlider.value);
        SetVolume("SFXVolume", sfxSlider.value);
        SetVolume("MusicVolume", musicSlider.value);
    }

    // Function to set the volume in the Audio Mixer
    private void SetVolume(string parameterName, float volume)
    {
        // If the volume is 0, set it to -80 dB (minimum value)
        float dBVolume = (volume > 0) ? Mathf.Log10(volume) * 20 : -80;
        audioMixer.SetFloat(parameterName, dBVolume);
    }

    // Save volume settings to PlayerPrefs when the application quits
    private void OnApplicationQuit()
    {
        PlayerPrefs.SetFloat("MasterVolume", masterSlider.value);
        PlayerPrefs.SetFloat("SFXVolume", sfxSlider.value);
        PlayerPrefs.SetFloat("MusicVolume", musicSlider.value);
        PlayerPrefs.Save();
    }
}
