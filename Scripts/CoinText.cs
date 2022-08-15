using UnityEngine;
using UnityEngine.UI;

public class CoinText : MonoBehaviour
{
    private int score;
    
    void Start()
    {
        PlayerCollision.CoinPicked += AddCoinScore;
        Manager.RestartScene += ScoreToZero;
        score = 0;
    }

    private void AddCoinScore()
    {
        score += 1;
        GetComponent<Text>().text = score.ToString();
    }

    private void ScoreToZero()
    {
        score = 0;
        GetComponent<Text>().text = score.ToString();
    }
}
