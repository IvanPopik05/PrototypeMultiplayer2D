using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AgentUI : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] GameObject gamePanel;
    [SerializeField] GameObject timerPanel;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject pausedPanel;
    [Header("WhoPlayerWon")]
    [SerializeField] Text whoPlayer;
    public static bool canPlay;

    private void InitializeGame() 
    {
        Timer.timerRemaining = 5;
        Timer.isTimer = true;
        canPlay = false;
        SetActivePanels(false,true,false,false);
    }
    private void Start()
    {
        InitializeGame();
    }
    private void Update()
    {
        WonPlayer();
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            SetActivePanels(false,false,false,true);
            canPlay = !canPlay;
        }
        if (canPlay) 
        {
            SetActivePanels(true, false, false, false);
        }
    }

    private void WonPlayer() 
    {
        if (CounterWin.Counter == 5)
        {
            GameOver("Blue");
        }
        else if (CounterWin2.Counter == 5) 
        {
            GameOver("Red");
        }
    }

    private void GameOver(string whichPlayerWon) 
    {
        SetActivePanels(false, false, true, false);
        whoPlayer.color = whichPlayerWon == "Red" ? Color.red : Color.cyan;
        whoPlayer.text = $"{whichPlayerWon} победил!";
        CounterWin.Counter = 0;
        CounterWin2.Counter = 0;
        canPlay = false;
    }

    private void SetActivePanels(bool isGame, bool isTimer, bool isGameOver,bool isPaused) 
    {
        gamePanel.SetActive(isGame);
        timerPanel.SetActive(isTimer);
        gameOverPanel.SetActive(isGameOver);
        pausedPanel.SetActive(isPaused);
    }

    public void StartAgainBtn() 
    {
        GetActiveScene();
        InitializeGame();
    }

    private void GetActiveScene(int index = 0) 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - index);
    }

    public void MenuBtn() 
    {
        GetActiveScene(1);
    }
    public void RestartBtn() 
    {
        GetActiveScene();
    }
    public void ContinueBtn() 
    {
        SetActivePanels(true,false,false,false);
        canPlay = true;
    }

}
