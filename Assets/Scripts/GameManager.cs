using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameStatus
    { Running, Stopped }

    private float timeForAThrow = 10f;

    private Player player;
    private List<Vector3> positions;
    private int score = 0;
    private UIManager uiManager;
    private BilboardBonus bilboardBonus;
    private GameStatus gameState = GameStatus.Stopped;

    public GameStatus GameState => gameState;

    void Start()
    {
        PositionContainer pos = GetComponentInChildren<PositionContainer>();
        positions = pos?.Positions;
        Destroy(pos.gameObject);

        player = GetComponentInChildren<Player>();

        uiManager = GetComponent<UIManager>();
        bilboardBonus = FindObjectOfType<BilboardBonus>();
        bilboardBonus.Deactivate();
        uiManager.UpdateScore(score);
    }

    private void Reposition()
    {
        int randomPos = UnityEngine.Random.Range(0, positions.Count);
        player.RepositionPlayerAndBall( positions[randomPos]);
    }

    public void ThrowBall(Vector3 power)
    {
        player.ThrowBall(power);
        StartCoroutine(CountdownToReset());
    }

    public IEnumerator CountdownToReset()
    {
        yield return new WaitForSeconds(timeForAThrow);
        Reposition();
        SendMessage("Reset");
    }

    public void AddPerfectScore()
    {
        score += 3;
        uiManager.UpdateScore(score);
    }

    public void AddNormalScore()
    {
        score += 2;
        uiManager.UpdateScore(score);
    }

    public void AddBilboardBonus()
    {
        if(bilboardBonus.enabled)
        {
            score += bilboardBonus.BonusPoints;
            bilboardBonus.BonusTaken();
            uiManager.UpdateScore(score);
        }
    }

    public void FinishThrow()
    {
        StopAllCoroutines();
        if(gameState == GameStatus.Running)
        {
            Reposition();
            SendMessage("Reset");
        }
        else
        {
            uiManager.ShowEndGameUI(score);
        }
    }

    public void EndRound()
    {
        gameState = GameStatus.Stopped;
        bilboardBonus.Deactivate();
        SendMessage("DeactivateInput");
        uiManager.ShowEndGameUI(score);
    }

    public void StartRound()
    {
        gameState = GameStatus.Running;
        bilboardBonus.StartBonusCountdown();
        score = 0;
        uiManager.UpdateScore(score);
        Reposition();
        SendMessage("Reset");
        SendMessage("ActivateInput");
    }
}
