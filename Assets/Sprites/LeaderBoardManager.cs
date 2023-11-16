using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dan.Main;
using TMPro;
using System;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.Events;

public class LeaderBoardManager : MonoBehaviour
{
    //public string publicKey;
    //public bool isInAscendingOrder;

    [SerializeField] private List<TextMeshProUGUI> names;
    [SerializeField] private List<TextMeshProUGUI> scores;
    public UnityEvent DoUpload;
    public UnityEvent DoFailedUpload;

    private string publicLeaderboardKey = "aa2d952612d3150c787a7ce8f1dea56d5a6c0fba44d34596f840aec5334f67ee";

    //private void Start()
    //{
    //    GetLeaderboard();
    //}

    public void GetLeaderboard()
    {
        LeaderboardCreator.GetLeaderboard(publicLeaderboardKey, ((msg) =>
        {

            for (int i = 0; i < names.Count; ++i)
            {
                names[i].text = msg[i].Username;
                scores[i].text = msg[i].Score.ToString();
            }

        }));
    }



    public void SetLeaderboardEntry(string username, int score)
    {
        LeaderboardCreator.UploadNewEntry(publicLeaderboardKey, username, score, isSuccessful  =>
        {
            if (isSuccessful)
            {
                GetLeaderboard();
                DoUpload.Invoke();

            }
            if (isSuccessful)
            {
                DoFailedUpload.Invoke();
            }
                //username.Substring(1,8);

        });
    }
}
