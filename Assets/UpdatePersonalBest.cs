using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdatePersonalBest : MonoBehaviour
{
    void Awake()
    {
        int personalBest = PlayerPrefs.GetInt("Personal Best");
        TMP_Text personalBestText = GetComponent<TMP_Text>();
        personalBestText.text = "Personal Best: " + personalBest.ToString();
        //GameObject.Find("Personal Best").GetComponent<TMP_Text>().text = ("Personal Best: " + PlayerPrefs.GetInt("personalBest").ToString());
        //Debug.Log();
    }
}
