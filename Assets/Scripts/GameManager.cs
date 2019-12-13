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
            uiManager.ShowEndGameUI();
        }
    }

    public void EndRound()
    {
        gameState = GameStatus.Stopped;
        SendMessage("DeactivateInput");
        SendMessage("StopBilboard");
        uiManager.ShowEndGameUI();
    }

    public void StartRound()
    {
        gameState = GameStatus.Running;
        Reposition();
        SendMessage("Reset");
        SendMessage("ActivateInput");
    }
}
