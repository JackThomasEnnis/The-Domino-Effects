using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class GameOverScreen : MonoBehaviour
{
    public void SetScore(int val)
    {
        GameObject.Find("End Screen Score Text").GetComponent<TMP_Text>().text = val.ToString();
    }

    public void Retry()
    {
        SceneManager.LoadScene("Play Scene");
    }

    public void Quit()
    {
        SceneManager.LoadScene("Main Menu");
    }


}
