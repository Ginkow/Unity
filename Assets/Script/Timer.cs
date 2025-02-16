using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    private float time = 10f;
    public TMP_Text timerText;
    public static Action GameEnd;
    public static bool IsGameEnd = false;
    public static bool IsPaused = false;

    void Start()
    {
        IsGameEnd = false;
        IsPaused = false;
        time = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsGameEnd || IsPaused)
        {
            return;
        }
        
        
        if (time > 0)
        {
            time -= Time.deltaTime;
            TimerMinuteSeconde(time);
        }
        else
        {
            time = 0;
            FinishTimer();
        }
        
    }

    void TimerMinuteSeconde(float time)
    {
        int minute = Mathf.FloorToInt(time / 60);
        int seconde = Mathf.FloorToInt(time % 60);
        timerText.text = $"{minute:00}:{seconde:00}";
    }

    public void FinishTimer()
    {
        timerText.text = "00:00";
        if (Score.Instance != null){
            Score.Instance.FinalScore();
        }
        if (GameEnd != null){
            IsGameEnd = true;
            GameEnd.Invoke();
        }
    }
}
