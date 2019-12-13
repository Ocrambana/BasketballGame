using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    private EndGameUI endUI;
    private ScoreUI scoreUI;
    private StartGameUI startUI;

    void Start()
    {
        InitializeStartUI();
        scoreUI = FindObjectOfType<ScoreUI>();
        InitializeEndUI();
    }

    private void InitializeEndUI()
    {
        endUI = FindObjectOfType<EndGameUI>();
        endUI.restartButton.onClick.AddListener(OnRestartClick);
        endUI.gameObject.SetActive(false);
    }

    private void InitializeStartUI()
    {
        startUI = FindObjectOfType<StartGameUI>();
        startUI.startButton.onClick.AddListener(StartGame);
        startUI.quitButton.onClick.AddListener(QuitApplication);
    }

    public void StartGame()
    {
        startUI.gameObject.SetActive(false);
        SendMessage("StartRound");
    }

    public void QuitApplication()
    {
        Application.Quit();
    }

    public void UpdateScore(int score)
    {
        scoreUI.scoreText.text = score.ToString();
        endUI.endGameScoreText.text = score.ToString();
    }

    public void OnRestartClick()
    {
        endUI.gameObject.SetActive(false);
        SendMessage("StartRound");
    }

    public void ShowEndGameUI()
    {
        endUI.gameObject.SetActive(true);
    }
}
