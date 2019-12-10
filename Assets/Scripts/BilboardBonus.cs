using System.Collections;
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

    void Start()
    {
        bonusScoreText = GetComponentInChildren<TextMeshProUGUI>();
        canvas = GetComponent<Canvas>();
    }

    private void StartBonusCountdown()
    {
        StartCoroutine(CountdownToNextBonus());
    }

    public IEnumerator CountdownToNextBonus()
    {
        float sleepTime = Random.Range(3f,8f);
        Debug.Log("Sleep for " + sleepTime);
        yield return new WaitForSeconds(sleepTime);
        Debug.Log("Awake");
        BonusActivation();
    }

    public void BonusActivation()
    {
        float randomValue = Random.value;

        if (!canvas.enabled)
        {
            if (randomValue > 0.8f)  
            {
                bonusScoreText.text = "+5";
                bonusPoints = 5;
            }
            else
            {
                bonusScoreText.text = "+4";
                bonusPoints = 4;
            }

            canvas.enabled = true;
            StartCoroutine(BonusDuration());
        }
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
        StartBonusCountdown();
    }
}
