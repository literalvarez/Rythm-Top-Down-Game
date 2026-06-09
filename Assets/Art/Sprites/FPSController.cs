using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FPSController : MonoBehaviour
{
    private int targetFPS = 120;
    private const string PlayerPrefsKey = "TargetFPS";

    public TMP_Text fpsValueText;
    public Slider fpsSlider;

    void Start()
    {
        // Load the target FPS from PlayerPrefs or use the default value (60)
        targetFPS = PlayerPrefs.GetInt(PlayerPrefsKey, 120);
        Application.targetFrameRate = targetFPS;

        if (fpsSlider != null)
        {
            fpsSlider.minValue = 60;
            fpsSlider.maxValue = 240; // You can adjust the maximum FPS value if needed
            fpsSlider.value = targetFPS;
            fpsSlider.onValueChanged.AddListener(ChangeFPS);
        }

        if (fpsValueText != null)
        {
            fpsValueText.text = targetFPS.ToString();
        }
    }

    void Update()
    {
        // Update the FPS value text in real-time
        if (fpsValueText != null)
        {
            fpsValueText.text = targetFPS.ToString();
        }
    }

    void ChangeFPS(float value)
    {
        targetFPS = Mathf.RoundToInt(value);
        Application.targetFrameRate = targetFPS;

        // Save the target FPS to PlayerPrefs
        PlayerPrefs.SetInt(PlayerPrefsKey, targetFPS);
    }

    public void OnInputChange(string value)
    {
        if (int.TryParse(value, out int newFPS))
        {
            targetFPS = Mathf.Clamp(newFPS, 1, 240); // Adjust the maximum FPS value if needed
            if (fpsSlider != null)
            {
                fpsSlider.value = targetFPS;
            }
            Application.targetFrameRate = targetFPS;

            // Save the target FPS to PlayerPrefs
            PlayerPrefs.SetInt(PlayerPrefsKey, targetFPS);
        }
    }
}
