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

    private GameManager gm;
    float actualTimeRemaining;

    private void Start()
    {
        actualTimeRemaining = gameDuration;
        gm = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if(actualTimeRemaining > Mathf.Epsilon && gm.GameState == GameManager.GameStatus.Running)
        {
            UpdateTimerFrame();
        }
        else if(!(actualTimeRemaining > 0f))
        {
            EndRound();
        }
    }

    private void UpdateTimerFrame()
    {
        timerCounter.text = Mathf.FloorToInt(actualTimeRemaining).ToString();
        actualTimeRemaining -= Time.deltaTime;
        outsideTimer.fillAmount = actualTimeRemaining / gameDuration;
    }

    private void EndRound()
    {
        gm.EndRound();
        actualTimeRemaining = gameDuration;
    }
}
