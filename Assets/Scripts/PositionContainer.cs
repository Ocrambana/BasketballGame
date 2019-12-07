using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionContainer : MonoBehaviour
{
    public List<Vector3> Positions => GetCourtPositions();

    private List<Vector3> GetCourtPositions()
    {
        List<Vector3> result = new List<Vector3>();

        foreach(Transform child in transform)
        {
            result.Add(child.position);
        }

        return result;
    }
}
