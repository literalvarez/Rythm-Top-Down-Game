using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Settings slider for AudioOffset (0-300 ms). The label shows the current value.
public class AudioOffsetSlider : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private TMP_Text label; // Optional
    [SerializeField] private string labelPrefix = "Audio Offset";

    private const int StepMilliseconds = 5;

    private void Start()
    {
        slider.minValue = 0;
        slider.maxValue = AudioOffset.MaxMilliseconds;
        slider.wholeNumbers = true;
        slider.SetValueWithoutNotify(AudioOffset.Milliseconds);
        UpdateLabel();

        slider.onValueChanged.AddListener(OnSliderChanged);
    }

    private void OnSliderChanged(float value)
    {
        // Snap to 5 ms steps so the value is easy to read and remember
        int milliseconds = Mathf.RoundToInt(value / StepMilliseconds) * StepMilliseconds;
        AudioOffset.Set(milliseconds);
        UpdateLabel();
    }

    private void UpdateLabel()
    {
        if (label != null)
        {
            label.text = labelPrefix + ": " + AudioOffset.Milliseconds + " ms";
        }
    }
}
