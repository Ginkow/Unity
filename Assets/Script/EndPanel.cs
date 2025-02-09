using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndPanel : MonoBehaviour
{
    public GameObject endpanel;
    public TMP_Text scoreText;
    public TMP_Text accuracyText;
    private int scoreFinal;
    private float accuracyFinal;
    private bool ShowPanel = false;

    void Update()
    {
        if (Timer.IsGameEnd && !ShowPanel)
        {
            GameEnd();
            ShowPanel = true;
        }
    }
    void OnEnable()
    {
        Timer.GameEnd += GameEnd;
    }

    void OnDisable()
    {
        Timer.GameEnd -= GameEnd;
    }

    public void GameEnd()
    {
        if (Timer.IsGameEnd)
        {
            endpanel.SetActive(true);
            GameOver();
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }else{
            endpanel.SetActive(false);
        }
    }

    void GameOver(){
        scoreFinal = PlayerPrefs.GetInt("FinalScore", 0);
        accuracyFinal = Accuracy.Instance.FinalAccuracy();

        scoreText.text = $"Score: {scoreFinal}";
        accuracyText.text = "Accuracy : " + accuracyFinal.ToString("0.00") + "%";
    }
}
