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
        if(Mathf.Sign(newPosition.x) != Mathf.Sign(transform.position.x))
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
        Vector3 cameraPos = Camera.main.transform.localPosition;
        Camera.main.transform.localPosition = new Vector3(-cameraPos.x, cameraPos.y, cameraPos.z);

        Quaternion cameraRot = Camera.main.transform.localRotation;
        Camera.main.transform.localRotation = new Quaternion(cameraRot.x,-cameraRot.y, cameraRot.z, cameraRot.w);
    }

    public void ThrowBall(Vector3 power)
    {
        ball.ThrowBall(power);
    }
}
