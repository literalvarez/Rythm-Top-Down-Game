using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class FinalScoreManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI inputScore;
    [SerializeField]
    private TMP_InputField inputName;
    [SerializeField]
    private ScoreManager GameScore;

    public UnityEvent<string, int> submitScoreEvent;

    private const int MaxNameLength = 16;

    void OnEnable()
    {
        // Refresh every time the end screen opens, not only the first time
        inputScore.text = "" + GameScore.score;
    }
    public void SubmitScore()
    {
        string playerName = inputName.text.Trim();
        if (playerName.Length == 0)
        {
            // No name typed: keep the player on the input field instead of submitting
            inputName.ActivateInputField();
            return;
        }
        if (playerName.Length > MaxNameLength)
        {
            playerName = playerName.Substring(0, MaxNameLength);
        }

        submitScoreEvent.Invoke(playerName, GameScore.score);
    }

}
