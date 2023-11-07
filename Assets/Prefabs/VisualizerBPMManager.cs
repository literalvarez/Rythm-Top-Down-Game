using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class VisualizerBPMManager : MonoBehaviour
{
    public TextMeshProUGUI bpmText; // Reference to the TextMeshProUGUI element displaying the BPM
    public Button increaseButton; // Reference to the + button
    public Button decreaseButton; // Reference to the - button

    public int currentBpm = 130; // Initial BPM value
    [SerializeField]
    private List<OscillatingMotionWithBPM> oscillatingScripts = new List<OscillatingMotionWithBPM>();

    private void Start()
    {
        UpdateBpmText();

        //// Add click listeners to the buttons
        //increaseButton.onClick.AddListener(IncreaseBpm);
        //decreaseButton.onClick.AddListener(DecreaseBpm);

        // Find all OscillatingMotionWithBPM instances and add them to the list
        oscillatingScripts.AddRange(FindObjectsOfType<OscillatingMotionWithBPM>());
    }

    private void UpdateBpmText()
    {
        bpmText.text = currentBpm.ToString();
    }

    private void UpdateAllOscillatingScriptsBpm()
    {
        foreach (var script in oscillatingScripts)
        {
            script.bpm = currentBpm;
        }
    }

    private void IncreaseBpm()
    {
        currentBpm++;
        UpdateBpmText();
        UpdateAllOscillatingScriptsBpm();
    }

    private void DecreaseBpm()
    {
        currentBpm--;
        if (currentBpm < 1)
            currentBpm = 1; // Ensure BPM doesn't go below 1
        UpdateBpmText();
        UpdateAllOscillatingScriptsBpm();
    }
    public void SetBpm(int SongBPM)
    {
        currentBpm = SongBPM;
    }
}
