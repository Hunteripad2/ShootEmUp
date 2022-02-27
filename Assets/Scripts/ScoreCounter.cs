using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    private int highScore;

    [SerializeField] private Text scoreUI;
    [SerializeField] private Text highScoreUI;

    static private int totalScore = 0;

    private void Start()
    {
        if (scoreUI != null)
        {
            scoreUI.text = "Score: " + totalScore.ToString();
        }

        highScore = PlayerPrefs.GetInt("highScore");

        if (highScore < totalScore)
        {
            highScore = totalScore;
        }
        PlayerPrefs.SetInt("highScore", highScore);

        highScoreUI.text = "Highscore: " + highScore.ToString();
    }

    public void AddScore(int score)
    {
        totalScore += score;
        scoreUI.text = "Score: " + totalScore.ToString();
    }

    public void ResetScore()
    {
        totalScore = 0;
    }
}
