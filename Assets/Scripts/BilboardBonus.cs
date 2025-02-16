﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BilboardBonus : MonoBehaviour
{
    [SerializeField]
    private float duration = 5f;

    private int bonusPoints = 0;
    private Canvas canvas;
    private TextMeshProUGUI bonusScoreText;

    public int BonusPoints => bonusPoints;

    private void Awake()
    {
        canvas = GetComponent<Canvas>();
    }

    void Start()
    {
        bonusScoreText = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void StartBonusCountdown()
    {
        StartCoroutine(CountdownToNextBonus());
    }

    public IEnumerator CountdownToNextBonus()
    {
        float sleepTime = Random.Range(3f,8f);
        yield return new WaitForSeconds(sleepTime);
        BonusActivation();
    }

    public void BonusActivation()
    {
        float randomValue = Random.value;

        if (!canvas.enabled)
        {
            if (randomValue > 0.8f)
            {
                SetBilboardBonus(5);
            }
            else
            {
                SetBilboardBonus(4);
            }

            canvas.enabled = true;
            StartCoroutine(BonusDuration());
        }
    }

    private void SetBilboardBonus(int value)
    {
        bonusScoreText.text = "+" + value.ToString();
        bonusPoints = value;
    }

    public void BonusTaken()
    {
        Deactivate();
        StartBonusCountdown();
    }

    public IEnumerator BonusDuration()
    {
        yield return new WaitForSeconds(duration);
        canvas.enabled = false;
        StartBonusCountdown();
    }

    public void Deactivate()
    {
        StopAllCoroutines();
        canvas.enabled = false;
    }
}
