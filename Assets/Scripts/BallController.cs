using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField]
    private float   yMultiplier = 5f,
                    xZMultiplier = 5f;

    private Rigidbody myRigidbody;
    private Transform target;
    private Vector3 throwDirection;
    private Vector3 localStartPosition;

    private void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        target = GameObject.FindGameObjectWithTag("Target").transform;
        CalculateThrowDirection();
        localStartPosition = transform.localPosition;
    }

    private void CalculateThrowDirection()
    {
        throwDirection = Vector3.ProjectOnPlane(target.position - transform.position, Vector3.up);
        throwDirection.Normalize();
    }

    public void ResetPosition()
    {
        transform.localPosition = localStartPosition;
        myRigidbody.constraints = RigidbodyConstraints.FreezePosition;
        CalculateThrowDirection();
    }

    public void ThrowBall(float power)
    {
        myRigidbody.constraints = RigidbodyConstraints.None;
        Vector3 force = throwDirection * power * xZMultiplier + Vector3.up * yMultiplier;
        myRigidbody.AddForce(force, ForceMode.Impulse);
    }
}
