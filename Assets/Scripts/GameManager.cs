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
    private ScoreUIController scoreUI;
    private BilboardBonus bilboardBonus;
    private GameStatus gameState = GameStatus.Stopped;

    public GameStatus GameState => gameState;

    void Start()
    {
        PositionContainer pos = GetComponentInChildren<PositionContainer>();
        positions = pos?.Positions;
        Destroy(pos.gameObject);

        player = GetComponentInChildren<Player>();

        scoreUI = FindObjectOfType<ScoreUIController>();
        bilboardBonus = FindObjectOfType<BilboardBonus>();
        bilboardBonus.Deactivate();
        Reposition();
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
        scoreUI.UpdateScore(score);
    }

    public void AddNormalScore()
    {
        score += 2;
        scoreUI.UpdateScore(score);
    }

    public void AddBilboardBonus()
    {
        if(bilboardBonus.enabled)
        {
            score += bilboardBonus.BonusPoints;
            scoreUI.UpdateScore(score);
        }
    }

    public void FinishThrow()
    {
        StopAllCoroutines();
        Reposition();
        SendMessage("Reset");
    }
}
