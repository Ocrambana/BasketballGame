using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private float timeForAThrow = 4f;

    private Player player;
    private List<Vector3> positions;

    void Start()
    {
        PositionContainer pos = GetComponentInChildren<PositionContainer>();
        positions = pos?.Positions;
        Destroy(pos.gameObject);

        player = GetComponentInChildren<Player>();
        Reposition();
    }

    public void Reposition()
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
    }

}
