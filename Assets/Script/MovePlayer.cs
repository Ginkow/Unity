using System;
using UnityEngine;

public class MoveePlayer : MonoBehaviour
{

    public float MoveSpeed = 25;
    public float RotationSpeed = 0.5f;

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
        
        transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * RotationSpeed, 0));


        Vector3 CurrentSpeed = transform.forward* Input.GetAxis("Vertical") * MoveSpeed 
            + transform.right * Input.GetAxis("Horizontal") * MoveSpeed;
        CurrentSpeed.y = GetComponent<Rigidbody>().velocity.y;


        GetComponent<Rigidbody>().velocity = CurrentSpeed;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}