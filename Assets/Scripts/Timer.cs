using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private float gameDuration = 60f;
    [SerializeField]
    private Image outsideTimer;
    [SerializeField]
    private TextMeshProUGUI timerCounter;

    private void Start()
    {
        StartCoroutine(GameCountdown());
    }

    public IEnumerator GameCountdown()
    {
        float remaning = gameDuration;

        while(remaning > 0f)
        {
            yield return new WaitForEndOfFrame();
            remaning -= Time.deltaTime;
            timerCounter.text = Mathf.FloorToInt(remaning).ToString();
            outsideTimer.fillAmount = remaning / gameDuration;
        }

    }
}
