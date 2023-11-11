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
    

    void Start()
    {
        inputScore.text = "" + GameScore.score;
    }
    public void SubmitScore()
    {
        submitScoreEvent.Invoke(inputName.text, int.Parse(inputScore.text));
    }

}
