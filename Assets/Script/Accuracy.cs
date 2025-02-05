using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Accuracy : MonoBehaviour
{
    public static Accuracy Instance;
    public TMP_Text accuracyText;
    private int totalShoot = 0;
    private int succesShoot = 0;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        AccuracyText();
    }

    public void Hit()
    {
        succesShoot++;
        totalShoot++;
        AccuracyText();
    }

    public void Miss(){
        totalShoot++;
        AccuracyText();
    }

    public void AccuracyText(){
    float accuracy = (float)succesShoot / (float)totalShoot * 100;
    if (totalShoot == 0 || accuracy == 100f){
        accuracyText.text = $"Accuracy : {accuracy:0}%";
    }else{
        accuracyText.text = $"Accuracy : {accuracy:0.00}%";
    }
}


    public float FinalAccuracy()
    {
        if (totalShoot == 0) {
            return 0f;
        }
        return (float)succesShoot / (float)totalShoot * 100;
    }
}
