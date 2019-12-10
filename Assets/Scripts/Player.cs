using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private BallController ball;

    private void Start()
    {
        ball = GetComponentInChildren<BallController>();
    }

    public void RepositionPlayerAndBall(Vector3 newPosition)
    {
        transform.position = newPosition;
        ball.ResetPosition();

        Vector3 toLookAt = Vector3.ProjectOnPlane(ball.TargetPosition, Vector3.up);
        transform.LookAt(toLookAt);
    }

    public void ThrowBall(Vector3 power)
    {
        ball.ThrowBall(power);
    }
}
