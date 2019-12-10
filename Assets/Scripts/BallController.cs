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

    public Vector3 TargetPosition => target.position;

    private void Awake()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Target").transform;
        localStartPosition = transform.localPosition;
    }

    public void ResetPosition()
    {
        transform.localPosition = localStartPosition;
        myRigidbody.constraints = RigidbodyConstraints.FreezePosition;
        CalculateThrowDirection();
    }

    private void CalculateThrowDirection()
    {
        throwDirection = Vector3.ProjectOnPlane(target.position - transform.position, Vector3.up);
        throwDirection.Normalize();
    }

    public void ThrowBall(Vector3 power)
    {
        myRigidbody.constraints = RigidbodyConstraints.None;

        Vector3 force = new Vector3 
        ( 
            throwDirection.x * power.x * xZMultiplier, 
            yMultiplier,
            throwDirection.z * power.z * xZMultiplier 
        );

        myRigidbody.AddForce(force, ForceMode.Impulse);
    }
}
