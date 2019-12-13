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
        ResetCameraPosition();

        if (HasChangedSide(newPosition))
        {
            FlipCamera();
        }

        transform.position = newPosition;
        ResetBallPosition();
        LookAtTarget();
    }

    private void ResetCameraPosition()
    {
        camMov.ResetPosition();
    }

    private void ResetBallPosition()
    {
        ball.ResetPosition();
    }

    private void LookAtTarget()
    {
        Vector3 toLookAt = Vector3.ProjectOnPlane(ball.TargetPosition, Vector3.up);
        transform.LookAt(toLookAt);
    }

    private bool HasChangedSide(Vector3 newPosition)
    {
        return Mathf.Sign(newPosition.x) != Mathf.Sign(transform.position.x);
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
