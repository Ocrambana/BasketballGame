using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private float timeForAThrow = 4f;

    private Player player;
    private List<Vector3> positions;
    private int score = 0;
    private ScoreUIController scoreUI;

    void Start()
    {
        PositionContainer pos = GetComponentInChildren<PositionContainer>();
        positions = pos?.Positions;
        Destroy(pos.gameObject);

        player = GetComponentInChildren<Player>();
        Reposition();

        scoreUI = FindObjectOfType<ScoreUIController>();
    }

    private void Reposition()
    {
        int randomPos = UnityEngine.Random.Range(0, positions.Count);
        player.RepositionPlayerAndBall( positions[randomPos]);
    }

    public void ThrowBall(float power)
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
}
