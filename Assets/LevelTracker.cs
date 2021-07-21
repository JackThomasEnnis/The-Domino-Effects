using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelTracker : MonoBehaviour
{

    //This keeps track of the levels in the text.

    private TMP_Text levelText;
    private int currentLevel = 0;

    void Awake()
    {
        levelText = GetComponent<TMP_Text>();
        IncrementLevel();
    }

    public void IncrementLevel()
    {
        currentLevel += 1;
        levelText.text = "Level: " + currentLevel.ToString();
    }

    public int GetLevel()
    {
        return currentLevel;
    }
}
