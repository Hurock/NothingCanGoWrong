using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    public enum GameState { MainMenu, Paused, Playing, Winner, Credits, MatchingPuzzle };
    public GameState currentState;

    public GameObject mainMenuPanel, pauseMenuPanel, creditMenuPanel, matchingPuzzlePanel, winnerPanel;

    // Start is called before the first frame update

        void Awake()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            CheckGameState(GameState.MainMenu);
        }
        else
        {
            CheckGameState(GameState.Playing);
        }
    }
    public void CheckGameState(GameState newGameState)
    {
        currentState = newGameState;
        switch (currentState)
        {
            case GameState.MainMenu:
                MainMenuSetup();
                GameManager.gamePaused = true;
                Time.timeScale = 0f;
                break;

            case GameState.Paused:
                GamePaused();
                GameManager.gamePaused = true;
                Time.timeScale = 0f;
                break;

            case GameState.Playing:
                GameActive();
                GameManager.gamePaused = false;
                Time.timeScale = 1f;
                break;

            case GameState.Credits:
                MainMenuSetup();
                GameManager.gamePaused = true;
                Time.timeScale = 0f;
                break;

            case GameState.Winner:
                Winner();
                GameManager.gamePaused = true;
                Time.timeScale = 0f;
                break;

            case GameState.MatchingPuzzle:
                MatchingPuzzle();
                GameManager.gamePaused = true;
                Time.timeScale = 2f;
                break;
        }
    }

    public void MainMenuSetup()
    {
        mainMenuPanel.SetActive(true);
        pauseMenuPanel.SetActive(false);
        creditMenuPanel.SetActive(false);
        matchingPuzzlePanel.SetActive(false);
        winnerPanel.SetActive(false);
    }

    public void GameActive()
    {
        mainMenuPanel.SetActive(false);
        pauseMenuPanel.SetActive(false);
        creditMenuPanel.SetActive(false);
        matchingPuzzlePanel.SetActive(false);
        winnerPanel.SetActive(false);
    }
    public void GamePaused()
    {
        mainMenuPanel.SetActive(false);
        pauseMenuPanel.SetActive(true);
        creditMenuPanel.SetActive(false);
        matchingPuzzlePanel.SetActive(false);
        winnerPanel.SetActive(false);
    }
    public void Winner()
    {
        mainMenuPanel.SetActive(false);
        pauseMenuPanel.SetActive(false);
        creditMenuPanel.SetActive(false);
        matchingPuzzlePanel.SetActive(false);
        winnerPanel.SetActive(true);
    }

    public void CreditScene()
    {
        mainMenuPanel.SetActive(false);
        pauseMenuPanel.SetActive(false);
        creditMenuPanel.SetActive(true);
        matchingPuzzlePanel.SetActive(false);
        winnerPanel.SetActive(false);
    }

    public void MatchingPuzzle()
    {
        mainMenuPanel.SetActive(false);
        pauseMenuPanel.SetActive(false);
        creditMenuPanel.SetActive(false);
        matchingPuzzlePanel.SetActive(true);
        winnerPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
       
    }

    void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (currentState == GameState.Playing)
            {
                CheckGameState(GameState.Paused);
            }
            else if (currentState == GameState.Paused)
            {
                CheckGameState(GameState.Playing);
            }
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene("AntonioTest");
        CheckGameState(GameState.Playing);
    }

    public void PauseGame()
    {
        CheckGameState(GameState.Paused);
    }

    public void ResumeGame()
    {
        CheckGameState(GameState.Playing);
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        CheckGameState(GameState.MainMenu);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void WinnerMenu()

    {
        CheckGameState(GameState.Winner);
    }
    public void MatchingPuzzleMenu()

    {
        CheckGameState(GameState.MatchingPuzzle);
    }


}
