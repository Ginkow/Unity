using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public static Score Instance;
    public TMP_Text scoreText;
    public int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        ScoreText();
    }

    void Awake()
    {
        Instance = this;
    }

    public void AddScore(int point)
    {
        score += point;
        ScoreText();
    }

    void ScoreText()
    {
        scoreText.text = $"Score : {score}";
    }

    public void FinalScore()
    {
        PlayerPrefs.SetInt("FinalScore", score);
        PlayerPrefs.Save();
    }
}
