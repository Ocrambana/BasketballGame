﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreChecker : MonoBehaviour
{
    public enum Positions
    {
        Top, Net, Other, Bilboard, End
    };

    private bool    hasTopCollided = false,
                    hasNetCollided = false,
                    hasOthersCollided = false,
                    hasBillboardCollided = false;

    private GameManager gm;
    private ScoreManager sm;

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        sm = GameObject.FindGameObjectWithTag("GameController").GetComponent<ScoreManager>();
    }

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
            hasOthersCollided = true;
        }

        if(p == Positions.Bilboard)
        {
            hasOthersCollided = true;
            hasBillboardCollided = true;
        }

        if(hasTopCollided && hasNetCollided)
        {
            if(hasOthersCollided)
            {
                sm.AddNormalScore();
            }
            else
            {
                sm.AddPerfectScore();
            }

            if(hasBillboardCollided)
            {
                sm.AddBilboardBonus();
            }

            Reset();
        }

        if(p == Positions.End)
        {
            gm.FinishThrow();
            Reset();
        }
    }

    public void Reset()
    {
        hasNetCollided = false;
        hasTopCollided = false;
        hasBillboardCollided = false;
        hasOthersCollided = false;
    }
}
