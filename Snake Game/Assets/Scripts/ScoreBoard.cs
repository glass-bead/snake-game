using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreGUI;
    [SerializeField] TextMeshProUGUI highGUI;

    private int score = 0, highScore = 0;

    private void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highGUI.text = highScore.ToString();
    }

    internal void UpdateScore(int value)
    {
        score += value;
        scoreGUI.text = score.ToString();
    }

    internal void UpdateHighScore()
    {
        if (score > highScore)
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScore = PlayerPrefs.GetInt("HighScore", 0);
            highGUI.text = highScore.ToString();
        }   
    }

    internal void ResetScore()
    {
        UpdateHighScore();
        score = 0;
        scoreGUI.text = score.ToString();
    }
}
