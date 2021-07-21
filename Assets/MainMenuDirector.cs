using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuDirector : MonoBehaviour
{
    public void LoadCompetitivePlay() {
        PlayerPrefs.SetInt("gamemode", 0);
        SceneManager.LoadScene("Play Scene");
    }
    
    public void LoadFreePlay() {
        PlayerPrefs.SetInt("gamemode", 1);
        SceneManager.LoadScene("Play Scene");
    }

    public void Reload() {
        SceneManager.LoadScene("Main Menu");
    }
}
