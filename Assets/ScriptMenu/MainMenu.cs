using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static MainMenu Instance;

    // void Start()
    // {
    //     if (!SceneManager.GetSceneByName("LeaderboardScene").isLoaded)
    //     {
    //         SceneManager.LoadScene("LeaderboardScene", LoadSceneMode.Additive);
    //     }
    // }
    
    public void PlayGame(){
        Timer.IsPaused = false;
        Timer.IsGameEnd = false;
        SceneManager.LoadSceneAsync(1);
    }

    public void QuitGame(){
        Application.Quit();
    }
}
