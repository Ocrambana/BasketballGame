using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    private EndGameUI endUI;
    private ScoreUI scoreUI;

    void Start()
    {
        scoreUI = FindObjectOfType<ScoreUI>();

        endUI = FindObjectOfType<EndGameUI>();
        endUI.restartButton.onClick.AddListener(OnRestartClick);
        endUI.gameObject.SetActive(false);

    }

    public void UpdateScore(int score)
    {
        scoreUI.scoreText.text = score.ToString();
    }

    public void OnRestartClick()
    {
        endUI.gameObject.SetActive(false);
        SendMessage("StartRound");
    }

    public void ShowEndGameUI(int score)
    {
        endUI.endGameScoreText.text = score.ToString();
        endUI.gameObject.SetActive(true);
    }
}
