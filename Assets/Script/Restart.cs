using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
	public void RestartButton()
	{
		Timer.IsGameEnd = false;
		Timer.IsPaused = false;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}