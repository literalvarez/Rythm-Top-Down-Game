using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class UiVisualizerBPMManager : MonoBehaviour
{
    //public TextMeshProUGUI bpmText; // Reference to the TextMeshProUGUI element displaying the BPM
    //public Button increaseButton; // Reference to the + button
    //public Button decreaseButton; // Reference to the - button

    public int currentBpm = 130; // Initial BPM value
    [SerializeField]
    public List<UiOscillatingMotionWithBPM> UiOscillatingScripts = new List<UiOscillatingMotionWithBPM>();

    private void Start()
    {
        //UpdateBpmText();

        //// Add click listeners to the buttons
        //increaseButton.onClick.AddListener(IncreaseBpm);
        //decreaseButton.onClick.AddListener(DecreaseBpm);

        // Find all OscillatingMotionWithBPM instances and add them to the list
        UiOscillatingScripts.AddRange(FindObjectsOfType<UiOscillatingMotionWithBPM>());
    }

    //private void UpdateBpmText()
    //{
    //    bpmText.text = currentBpm.ToString();
    //}

    private void UpdateAllOscillatingScriptsBpm()
    {
        foreach (var script in UiOscillatingScripts)
        {
            script.bpm = currentBpm;
        }
    }

    private void IncreaseBpm()
    {
        currentBpm++;
        //UpdateBpmText();
        UpdateAllOscillatingScriptsBpm();
    }

    private void DecreaseBpm()
    {
        currentBpm--;
        if (currentBpm < 1)
            currentBpm = 1; // Ensure BPM doesn't go below 1
       // UpdateBpmText();
        UpdateAllOscillatingScriptsBpm();
    }
    public void SetBpm(int SongBPM)
    {
        currentBpm = SongBPM;
        foreach (var script in UiOscillatingScripts)
        {
            script.bpm = currentBpm;
            script.RestartInstrument();
        }
        
    }

    public void StopAll()
    {
       
        foreach (var script in UiOscillatingScripts)
        {
            script.StopInstrument();
        }

    }
}
