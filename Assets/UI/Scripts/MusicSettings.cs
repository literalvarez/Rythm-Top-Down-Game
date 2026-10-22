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
        // Load saved settings, apply them, and update the mixer whenever a slider moves
        SetupSlider(masterSlider, "MasterVolume");
        SetupSlider(sfxSlider, "SFXVolume");
        SetupSlider(musicSlider, "MusicVolume");
    }

    private void SetupSlider(Slider slider, string parameterName)
    {
        slider.SetValueWithoutNotify(PlayerPrefs.GetFloat(parameterName, 1f));
        SetVolume(parameterName, slider.value);

        slider.onValueChanged.AddListener(volume =>
        {
            SetVolume(parameterName, volume);

            // Save on every change: WebGL builds never call OnApplicationQuit
            PlayerPrefs.SetFloat(parameterName, volume);
            PlayerPrefs.Save();
        });
    }

    // Function to set the volume in the Audio Mixer
    private void SetVolume(string parameterName, float volume)
    {
        audioMixer.SetFloat(parameterName, MixerControl.ToDecibels(volume));
    }
}
