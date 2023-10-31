using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MixerControl : MonoBehaviour
{
    public AudioMixer mixer; // Reference to your Audio Mixer
    public Slider volumeSlider; // Reference to your Slider UI element

    private void Start()
    {
        // Subscribe to the slider's value change event
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    // Called when the slider value changes
    private void SetVolume(float volume)
    {
        // Set the volume of the entire Audio Mixer using the slider value
        mixer.SetFloat("Volume", Mathf.Log10(volume) * 20);

        // Log the received volume value to the console for debugging purposes
        Debug.Log("Received Volume: " + volume);

        // Optional: You can update UI elements or perform other actions here
    }
}
