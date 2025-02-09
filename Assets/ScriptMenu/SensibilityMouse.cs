using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SensibilityMouse : MonoBehaviour
{
    public Slider sensitivitySlider;
    public static SensibilityMouse Instance;
    public TMP_InputField Sensibilty;
    public float mouseSensitivity = 1.0f;
    public GameObject MainMenu;  // Référence au menu principal
    public GameObject optionsMenu;  // Référence au menu des options

    void Start()
    {
        sensitivitySlider.value = mouseSensitivity;
        Sensibilty.text = mouseSensitivity.ToString("0.0");

        sensitivitySlider.onValueChanged.AddListener(OnSliderChanged);
        Sensibilty.onEndEdit.AddListener(OnInputChanged);
    }

    void Update()
    {
        // Si la touche Échap est pressée, revenir au menu principal
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ShowMainMenu();
        }
    }

    void OnSliderChanged(float value)
    {
        mouseSensitivity = value;
        Sensibilty.text = value.ToString("0.0");
        UpdateMouseSensitivity();
    }

    void OnInputChanged(string value)
    {
        if (float.TryParse(value, out float newSensitivity))
        {
            mouseSensitivity = Mathf.Clamp(newSensitivity, sensitivitySlider.minValue, sensitivitySlider.maxValue);
            sensitivitySlider.value = mouseSensitivity;
            UpdateMouseSensitivity();
        }
    }

    void UpdateMouseSensitivity()
    {
        // Met ici le code pour modifier la sensibilité de ta caméra/mouvement de souris
        Debug.Log("Nouvelle sensibilité de la souris : " + mouseSensitivity);
    }

    // Méthode pour revenir au menu principal
    void ShowMainMenu()
    {
        MainMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }
}
