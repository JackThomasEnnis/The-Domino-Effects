using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Domino : MonoBehaviour
{
    private string special;
    private int affectsUp = 0;
    private int affectsLeft = 0;
    private int affectsDown = 0;
    private int affectsRight = 0;
    private bool isOn = true;
    private bool playAnimation = false;
    private bool isLocked = false;

    public int x;
    public int y;

    private SkinManager skinManager;
    private DominoBoard dominoBoard;

    private Color onColor = new Color(0, 255, 255, 255);
    private Color offColor = new Color(191, 91, 0, 255);
    private Color offLockColor = new Color(255, 0, 0, 1);
    private Color onLockColor = new Color(0, 116, 0, 1);

    private float endTime;
    private SpriteRenderer sr;
    private string[] possibleSpecials;

    void Awake()
    {
        skinManager = GameObject.Find("Skin Manager").GetComponent<SkinManager>();
        sr = GetComponent<SpriteRenderer>();

        possibleSpecials = new string[] { "N", "N", "N", "S", "S", "L", "R"};

        Define(0);

        dominoBoard = GameObject.Find("Domino Board").GetComponent<DominoBoard>();

    }

    public void Define(int score)
    {

        possibleSpecials = SpecialScaler(score);
        special = possibleSpecials[Random.Range(0, possibleSpecials.Length)];

        affectsUp = 0;
        affectsLeft = 0;
        affectsDown = 0;
        affectsRight = 0;

        if (special != "L" && special != "R")
        {
            affectsUp = AffectScaler(score);
            affectsLeft = AffectScaler(score);
            affectsDown = AffectScaler(score);
            affectsRight = AffectScaler(score);
        }

        Debug.Log(GetIdentity());
        sr.sprite = skinManager.GetSkin(GetIdentity());
    }

    int AffectScaler(int score)
    {
        if(score < 4) { 
            if(Random.Range(0,99) <= 33) { return 1; }
        }
        else if(score < 7)
        {
            if(Random.Range(0,99) <= 55) { return 1; }
        }
        else
        {
            if(Random.Range(0,99) <= 75) { return 1; }
        }
        return 0;
    }

    string[] SpecialScaler(int score)
    {
        if(score < 3) { return new string[] { "L", "R" }; }
        else if(score < 5) { return new string[] { "N", "N", "L", "R", "N", "N" }; }
        else if(score < 8) { return new string[] { "N", "N", "L", "R", "S" }; }
        else if(score < 10) { return new string[] { "L", "R", "S", "S", "N", "N", "N" }; }
        else { return new string[] { "S", "S", "S", "N", "N" }; }
    }


    void Update()
    {
    }

    public string GetIdentity()
    {
        return special + affectsUp.ToString() + affectsLeft.ToString() + affectsDown.ToString() + affectsRight.ToString();   
    }

    public void SetCoords(int givenX, int givenY)
    {
        x = givenX;
        y = givenY;
    }

    public void Flip(bool isComingFromSecureTile)
    {
        if (isComingFromSecureTile)
        {
            isOn = !isOn;
            isLocked = !isLocked;
            endTime = 0.5f;
            //Debug.Log("Coming From Secure Tile: " + x.ToString() + ", " + y.ToString() + " " + isLocked.ToString());
            PlayAnimation();
        }
        else if (!isLocked)
        {
            //Debug.Log(x.ToString() + ", " + y.ToString() + " " + isLocked.ToString());
            isOn = !isOn;
            endTime = 0.5f;
            PlayAnimation();
        }
        else
        {
        }

    }

    public void OnMouseDown()
    {
        if (!isLocked || special == "S")
        {
            dominoBoard.AffectBoardAccordingTo(x, y, special, affectsUp, affectsLeft, affectsDown, affectsRight);
        }
    }

    //TODO: Retread animation.
    void PlayAnimation()
    {
        if (isOn && isLocked)
        {
            sr.color = onLockColor;
        }
        else if (isOn && !isLocked)
        {
            sr.color = onColor;
        }
        else if (!isOn && isLocked)
        {
            sr.color = offLockColor;
        }
        else if (!isOn && !isLocked)
        {
            sr.color = offColor;
        }
        
    }

    public bool IsOn()
    {
        return isOn;
    }

}
