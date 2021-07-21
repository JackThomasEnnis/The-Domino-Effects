using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitMenu : MonoBehaviour
{
    int quitCounter;

    void Awake()
    {
        quitCounter = 0;
    }

    public void HandleQuitClick()
    {
        quitCounter += 1;
        if(quitCounter == 1) { GetComponent<UnityEngine.UI.Image>().color = new Color(255, 255, 0, 1); }
        if(quitCounter == 2) { GetComponent<UnityEngine.UI.Image>().color = new Color(255, 0, 0, 1); }
        else
        {
            SceneManager.LoadScene("Main Menu");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
