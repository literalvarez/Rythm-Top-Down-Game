using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FPSController : MonoBehaviour
{
    private int targetFPS = 120;

    public TMP_Text fpsValueText;
    public Slider fpsSlider;

    void Start()
    {
        Application.targetFrameRate = targetFPS;

        if (fpsSlider != null)
        {
            fpsSlider.minValue = 60;
            fpsSlider.maxValue = 240; // You can adjust the maximum FPS value if needed
            fpsSlider.value = targetFPS;
            fpsSlider.onValueChanged.AddListener(ChangeFPS);
        }
    }

    void ChangeFPS(float value)
    {
        targetFPS = Mathf.RoundToInt(value);
        Application.targetFrameRate = targetFPS;

        if (fpsValueText != null)
        {
            fpsValueText.text = targetFPS.ToString();
        }
    }
}
