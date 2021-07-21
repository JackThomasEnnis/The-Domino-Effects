using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DominoBoard : MonoBehaviour
{
    public GameObject aDomino;
    private List<List<Domino>> board = new List<List<Domino>>();

    private RoundManager rm;

    private int WIDTH = 4;
    private int HEIGHT = 3;
    private int boardWins = 0;
    private int timeLeft = 0;

    void Awake()
    {
        rm = GameObject.Find("Round Manager").GetComponent<RoundManager>();
        timeLeft = 30;

        for(int x = 0; x < WIDTH; x++)
        {
            List<Domino> row = new List<Domino>();

            for(int y = 0; y < HEIGHT; y++)
            {
                GameObject domino = Instantiate(aDomino, new Vector3(x * 1.4f, y * 2.8f, 0), Quaternion.identity);
                domino.transform.parent = transform;
                Domino dominoScript = domino.GetComponent<Domino>();
                dominoScript.SetCoords(x,y);
                row.Add(dominoScript);
            }
            board.Add(row);
        }
        if(PlayerPrefs.GetInt("gamemode") == 1)
        {
            Randomize(100);
        }
        else
        {
            Randomize(boardWins);
        }
        
    }

    void Randomize(int score)
    {
        for (int x = 0; x < WIDTH; x++)
        {
            for (int y = 0; y < HEIGHT; y++)
            {
                board[x][y].Define(boardWins);    
            }
        }

        for (int x = 0; x < WIDTH; x++)
        {
            for(int y = 0; y < HEIGHT; y++)
            {
                int randomizeLikelihood = 6 - score;
                if(score < 1) { score = 1; }
                if(Random.Range(0,score) == 0)
                {
                    board[x][y].OnMouseDown();
                }
            }
        }
    }

    public void AffectBoardAccordingTo(int x, int y, string special, int affectsUp, int affectsLeft, int affectsDown, int affectsRight)
    {
        if(special == "N")
        {
            board[x][y].Flip(false);
            if (affectsUp == 1 && y + 1 < board[0].Count) { board[x][y + 1].Flip(false); }
            if (affectsLeft == 1 && x - 1 >= 0) { board[x - 1][y].Flip(false); }
            if (affectsDown == 1 && y - 1 >= 0) { board[x][y - 1].Flip(false); }
            if (affectsRight == 1 && x + 1 < board.Count) { board[x + 1][y].Flip(false); }
        }

        else if(special == "L")
        {
            int iteratingX = x;
            while(iteratingX >= 0)
            {
                board[iteratingX][y].Flip(false);
                iteratingX -= 1;
            }
        }

        else if(special == "R")
        {
            int iteratingX = x;
            while (iteratingX < board.Count)
            {
                board[iteratingX][y].Flip(false);
                iteratingX += 1;
            }
        }

        else if(special == "S")
        {
            board[x][y].Flip(true);
            if (affectsUp == 1 && y + 1 < board[0].Count) { board[x][y + 1].Flip(true); }
            if (affectsLeft == 1 && x - 1 >= 0) { board[x - 1][y].Flip(true); }
            if (affectsDown == 1 && y - 1 >= 0) { board[x][y - 1].Flip(true); }
            if (affectsRight == 1 && x + 1 < board.Count) { board[x + 1][y].Flip(true); }
        }


        if (GetWinStatus())
        {
            boardWins += 1;
            rm.IncrementLevel();
            rm.AddTime();
            while (GetWinStatus())
            {
                if(PlayerPrefs.GetInt("gamemode") == 1)
                {
                    Randomize(100);
                }
                else
                {
                    Randomize(boardWins);
                }
                
            }
        }
    }

    private bool GetWinStatus() {
        for (int x = 0; x < WIDTH; x++) { 
            for(int y = 0; y < HEIGHT; y++)
            {
                if (!board[x][y].IsOn()) { return false; }
            }
        }
        return true;
    }

    private void AddAdditionalTime()
    {
        timeLeft += 15;
        Debug.Log("15 seconds awarded!");
    }

    public void TerminateBoard()
    {
        foreach (Transform child in transform)
        {
            if (child != transform)
            {
                Destroy(child.gameObject);
            }
        }
    }
}
