using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MixerControl : MonoBehaviour
{
    public AudioMixer mixer; // Reference to your Audio Mixer
    public Slider volumeSlider; // Reference to your Slider UI element

    // Exposed mixer parameter to control. Also used as the PlayerPrefs key,
    // so it shares the saved value with the Home settings menu (MusicSettings).
    [SerializeField] private string parameterName = "MusicVolume";

    private void Start()
    {
        // Show the saved volume, then apply it
        volumeSlider.SetValueWithoutNotify(PlayerPrefs.GetFloat(parameterName, 1f));
        SetVolume(volumeSlider.value);

        // Subscribe to the slider's value change event
        volumeSlider.onValueChanged.AddListener(OnSliderChanged);
    }

    private void OnSliderChanged(float volume)
    {
        SetVolume(volume);

        // Save right away: WebGL builds never call OnApplicationQuit
        PlayerPrefs.SetFloat(parameterName, volume);
        PlayerPrefs.Save();
    }

    private void SetVolume(float volume)
    {
        mixer.SetFloat(parameterName, ToDecibels(volume));
    }

    // Converts a 0-1 slider value to decibels. 0 maps to -80 dB (silent) instead of -Infinity.
    public static float ToDecibels(float volume)
    {
        return Mathf.Log10(Mathf.Max(volume, 0.0001f)) * 20f;
    }
}
