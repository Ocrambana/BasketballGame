using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovements : MonoBehaviour
{
    [SerializeField]
    private Transform destination;
    [SerializeField]
    private Transform target;
    [SerializeField]
    private float smoothTime = 1f;

    private bool isFollowing = false;
    private bool isFlipped = false;
    private Vector3 velocity = Vector3.zero;
    private Vector3 startPosition;
    private Quaternion startRotation;

    private void Start()
    {
        startPosition = transform.localPosition;
        startRotation = transform.localRotation;
    }

    private void LateUpdate()
    {
        if(isFollowing)
        {
            transform.localPosition = Vector3.SmoothDamp (transform.localPosition, destination.localPosition, 
                ref velocity, smoothTime);
            transform.LookAt(target);
        }
    }

    public void FlipCamera()
    {
        isFlipped = !isFlipped;
        FlippedStartingPosition();
    }

    private void FlippedStartingPosition()
    {
        transform.localPosition = new Vector3(-startPosition.x, startPosition.y, startPosition.z);
        transform.localRotation = new Quaternion(startRotation.x, -startRotation.y, startRotation.z, startRotation.w);
    }

    public void FollowBall()
    {
        isFollowing = true;
    }

    public void ResetPosition()
    {
        isFollowing = false;

        if(isFlipped)
        {
            FlippedStartingPosition();
        }
        else
        {
            UnflippedStartingPosition();
        }
    }

    private void UnflippedStartingPosition()
    {
        transform.localPosition = startPosition;
        transform.localRotation = startRotation;
    }
}
