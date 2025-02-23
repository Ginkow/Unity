using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SensibilityMouse : MonoBehaviour
{
    public Slider sensibilitySlider;
    public static SensibilityMouse Instance;
    public TMP_InputField Sensibilty;
    public static float mouseSensibility = 1.0f;
    public GameObject MainMenu;
    public GameObject optionsMenu;

    void Start()
    {
        sensibilitySlider.value = mouseSensibility;
        Sensibilty.text = mouseSensibility.ToString("0.0");

        sensibilitySlider.onValueChanged.AddListener(OnSliderChanged);
        Sensibilty.onEndEdit.AddListener(OnInputChanged);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ShowMainMenu();
        }
    }

    void OnSliderChanged(float value)
    {
        mouseSensibility = value;
        Sensibilty.text = value.ToString("0.0");
        UpdateMouseSensitivity();
    }

    void OnInputChanged(string value)
    {
        if (float.TryParse(value, out float newSensitivity))
        {
            mouseSensibility = Mathf.Clamp(newSensitivity, sensibilitySlider.minValue, sensibilitySlider.maxValue);
            sensibilitySlider.value = mouseSensibility;
            UpdateMouseSensitivity();
        }
    }

    void UpdateMouseSensitivity()
    {
        Debug.Log("Nouvelle sensibilité de la souris : " + mouseSensibility);
    }

    void ShowMainMenu()
    {
        MainMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }
}
