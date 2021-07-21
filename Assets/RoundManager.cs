using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using PlayFab;
using PlayFab.ClientModels;

public class RoundManager : MonoBehaviour
{
    private TMP_Text timeText;
    private TMP_Text levelText;
    private DominoBoard db;

    private int currentLevel;
    private double timeLeft;

    private bool scoreSent = false;

    public GameObject gameOverMenu;

    void Awake()
    {
        currentLevel = 0;
        timeLeft = 30;

        if(PlayerPrefs.GetInt("gamemode") == 1)
        {
            timeLeft = 999999999999;
        }


        levelText = GameObject.Find("Level Text").GetComponent<TMP_Text>();
        timeText = GameObject.Find("Time Text").GetComponent<TMP_Text>();
        db = GameObject.Find("Domino Board").GetComponent<DominoBoard>();
        
        IncrementLevel();


    }

    // Start is called before the first frame update
    void Start()
    {
        Login();
    }

    // Update is called once per frame
    void Update()
    {
        if (!scoreSent)
        {
            if (timeLeft >= 0)
            {
                
                timeLeft -= Time.deltaTime;
                //Debug.Log(((int)timeLeft).ToString());
                timeText.text = ((int)timeLeft).ToString();
            }
            else
            {
                scoreSent = true;
                db.TerminateBoard();
                GameObject.Find("Menu").SetActive(false);

                Instantiate(gameOverMenu, new Vector3(0, 0, 0), Quaternion.identity);
                gameOverMenu.SetActive(true);

                gameOverMenu.GetComponent<GameOverScreen>().SetScore(GetLevel());
                Debug.Log("This happens once.");


                if(PlayerPrefs.GetInt("Personal Best") < currentLevel)
                {
                    PlayerPrefs.SetInt("Personal Best", currentLevel);
                }
                //Send score.
                SendLeaderboard(GetLevel());
                GetLeaderboard();
            }
        }
    }

    public int GetLevel()
    {
        return currentLevel;
    }

    public void IncrementLevel()
    {
        currentLevel += 1;
        levelText.text = "Level: " + currentLevel.ToString();
    }

    //To be later changed according to increasing difficulty.
    public void AddTime()
    {
        timeLeft += 5;
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

    public void GetLeaderboard()
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = "BoardScore",
            StartPosition = 0,
            MaxResultsCount = 10
        };
        PlayFabClientAPI.GetLeaderboard(request, OnLeaderboardGet, OnError);
    }

    void OnLeaderboardGet(GetLeaderboardResult result)
    {
        foreach(var item in result.Leaderboard)
        {
            Debug.Log(item.Position + " " + item.PlayFabId + " " + item.StatValue);
        }
    }
}
