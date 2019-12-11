using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private BallController ball;
    private CameraMovements camMov;

    private void Start()
    {
        ball = GetComponentInChildren<BallController>();
        camMov = GetComponentInChildren<CameraMovements>();
    }

    public void RepositionPlayerAndBall(Vector3 newPosition)
    {
        camMov.ResetPosition();

        if (Mathf.Sign(newPosition.x) != Mathf.Sign(transform.position.x))
        {
            FlipCamera();
        }

        transform.position = newPosition;
        ball.ResetPosition();

        Vector3 toLookAt = Vector3.ProjectOnPlane(ball.TargetPosition, Vector3.up);
        transform.LookAt(toLookAt);
    }

    private void FlipCamera()
    {
        camMov.FlipCamera();
    }

    public void ThrowBall(Vector3 power)
    {
        camMov.FollowBall();
        ball.ThrowBall(power);
    }
}
