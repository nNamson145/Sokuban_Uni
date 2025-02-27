using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIingame : MonoBehaviour
{
    public GameObject pauseButton;
    
    public GameObject pausePanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickPauseGame()
    {
        pauseButton.SetActive(false);
        pausePanel.SetActive(true);
    }

    public void OnClickResume()
    {
        pauseButton.SetActive(true);
        pausePanel.SetActive(false);
    }

    public void OnClickRestart()
    {
        pauseButton.SetActive(true);
        pausePanel.SetActive(false);
    }

    public void OnClickQuitToMainMenu()
    {
        pauseButton.SetActive(true);
        pausePanel.SetActive(false);
    }
}
