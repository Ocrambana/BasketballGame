using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class ScoreCheckerChild : MonoBehaviour
{
    [SerializeField]
    private ScoreChecker.Positions position;

    private ScoreChecker scoreChecker = null;

    private void Start()
    {
        scoreChecker = GameObject.FindObjectOfType<ScoreChecker>();
        if(! scoreChecker)
        {
            Debug.LogError("Score checker not found in children");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Ball"))
        {
            scoreChecker.hasCollided(position);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ball"))
        {
            scoreChecker.hasCollided(position);
        }
    }
}
