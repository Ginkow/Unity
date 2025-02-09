using UnityEngine;

public class Continue : MonoBehaviour
{
    public GameObject Pause;

    public void Continuer()
    {
        Pause.SetActive(false);
        Timer.IsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void PauseGame()
    {
        Pause.SetActive(true);
        Timer.IsPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
