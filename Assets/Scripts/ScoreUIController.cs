using UnityEngine;
using TMPro;

public class ScoreUIController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreText;
    
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "0"; 
    }

    public void UpdateScore(int val)
    {
        scoreText.text = val.ToString();
    }
}
