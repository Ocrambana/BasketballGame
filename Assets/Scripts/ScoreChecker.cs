using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreChecker : MonoBehaviour
{
    public enum Positions
    {
        Top, Net, Other
    };

    private bool    hasTopCollided = false,
                    hasNetCollided = false,
                    hasOtherscollided = false;

    public void hasCollided(Positions p)
    {
        if (p == Positions.Top || hasTopCollided)
        {
            hasTopCollided = true;
            if (p == Positions.Net)
            {
                hasNetCollided = true;
            }
        }

        if(p == Positions.Other)
        {
            hasOtherscollided = true;
        }

        if(hasTopCollided && hasNetCollided)
        {
            //TODO SCORE
            if(hasOtherscollided)
            {
                //min
                Debug.Log("Min Score");
            }
            else
            {
                //perfect score
                Debug.Log("Perfect Score");
            }

            Reset();
        }
    }

    public void Reset()
    {
        hasNetCollided = false;
        hasTopCollided = false;
        hasOtherscollided = false;
    }
}
