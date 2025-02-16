using System;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public GameObject Pause;
    public Continue continues;
    public float MoveSpeed = 25;
    // public float RotationSpeed = 0.5f;
    public static bool IsPaused = false; 

    void Start(){
        Cursor.lockState = CursorLockMode.Locked;

    }
    // Update is called once per frame
    void Update()
    {
        if (Timer.IsGameEnd)
        {
            return;
        }

        float RotationSpeed = SensibilityMouse.mouseSensibility;
        
        transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * RotationSpeed, 0));


        Vector3 CurrentSpeed = transform.forward* Input.GetAxis("Vertical") * MoveSpeed 
            + transform.right * Input.GetAxis("Horizontal") * MoveSpeed;
        CurrentSpeed.y = GetComponent<Rigidbody>().velocity.y;


        GetComponent<Rigidbody>().velocity = CurrentSpeed;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            continues.PauseGame();
        }
    }
}