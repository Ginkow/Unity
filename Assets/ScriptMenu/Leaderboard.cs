using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Leaderboard : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject leaderboardMenu;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ShowMainMenu();
        }
    }

    void ShowMainMenu()
    {
        MainMenu.SetActive(true);
        leaderboardMenu.SetActive(false);
    }
}
