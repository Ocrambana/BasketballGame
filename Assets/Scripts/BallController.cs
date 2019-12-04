using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField]
    private float   yMultiplier = 5f,
                    zMultiplier = 5f;
    private Rigidbody myRigidbody;

    private void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }

    public void ThrowBall(float power)
    {
        myRigidbody.constraints = RigidbodyConstraints.None;
        Vector3 force = new Vector3(0f, yMultiplier, power * zMultiplier);
        myRigidbody.AddForce(force, ForceMode.Impulse);
    }
}
