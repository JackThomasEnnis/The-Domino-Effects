using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using PlayFab;
using PlayFab.ClientModels;

public class TimeTracker : MonoBehaviour
{
    private TMP_Text timeText;
    private double timeLeft;
    private bool scoreSent = false;

    void Awake()
    {
        timeText = GetComponent<TMP_Text>();
        timeLeft = 30;
    }

    //To be later changed according to increasing difficulty.
    public void AddTime()
    {
        timeLeft += 15;
    }

    void Update()
    {
        if (!scoreSent)
        {
            if (timeLeft >= 0)
            {
                timeLeft -= Time.deltaTime;
                timeText.text = ((int)timeLeft).ToString();
            }
            else
            {
                scoreSent = true;
                Debug.Log("This happens once.");
                //Send score.
                SendLeaderboard(GameObject.Find("Level Text").GetComponent<LevelTracker>().GetLevel());
            }
        }
    }



    void Start()
    {
        Login();
    }

    void Login()
    {
        var request = new LoginWithCustomIDRequest
        {
            CustomId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true
        };
        PlayFabClientAPI.LoginWithCustomID(request, OnSuccess, OnError);
    }

    void OnSuccess(LoginResult result)
    {
        Debug.Log("Successful login/account created!");
    }

    void OnError(PlayFabError error)
    {
        Debug.Log("Error while logging in/creating an account!");
        Debug.Log(error.GenerateErrorReport());
    }


    public void SendLeaderboard(int score)
    {
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate{
                    StatisticName = "BoardScore",
                    Value = score
                }
            }

        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboardUpdate, OnError);
    }

    void OnLeaderboardUpdate(UpdatePlayerStatisticsResult result)
    {
        Debug.Log("Success!");
    }

}
