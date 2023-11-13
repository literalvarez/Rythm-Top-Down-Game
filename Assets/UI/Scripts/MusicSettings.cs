using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicSettings : MonoBehaviour
{
    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private Slider musicSlider;

    private void Start()
    {
        masterSlider.value = AudioListener.volume;
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume", 1f);
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1f);
    }
    private void Update()
    {
        AudioListener.volume = masterSlider.value;
        PlayerPrefs.SetFloat("SFXVolume", sfxSlider.value);
        PlayerPrefs.SetFloat("MusicVolume", musicSlider.value);
    }
}
