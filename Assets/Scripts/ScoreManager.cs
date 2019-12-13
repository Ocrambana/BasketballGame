using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private int perfectScore = 3, 
                normalScore = 2;

    private int score = 0;
    private BilboardBonus bilboardBonus;

    void Start()
    {
        UpdateScoreMessage();
        bilboardBonus = FindObjectOfType<BilboardBonus>();
        bilboardBonus.Deactivate();
    }

    private void UpdateScoreMessage()
    {
        SendMessage("UpdateScore", score);
    }

    public void AddPerfectScore()
    {
        score += perfectScore;
        UpdateScoreMessage();
    }

    public void AddNormalScore()
    {
        score += normalScore;
        UpdateScoreMessage();
    }

    public void AddBilboardBonus()
    {
        if (bilboardBonus.enabled)
        {
            score += bilboardBonus.BonusPoints;
            bilboardBonus.BonusTaken();
            UpdateScoreMessage();
        }
    }

    public void StartRound()
    {
        score = 0;
        UpdateScoreMessage();
        bilboardBonus.StartBonusCountdown();
    }

    public void StopBilboard()
    {
        bilboardBonus.Deactivate();
    }
}
