using UnityEngine;

public class MoveCam : MonoBehaviour
{
    public float RotationSpeed;
    public float maxRotationAngle = 90f;
    private float _currentXRotation = 0f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(-Input.GetAxis("Mouse Y") * RotationSpeed, 0, 0));

        _currentXRotation -= Input.GetAxis("Mouse Y");
        _currentXRotation = Mathf.Clamp(_currentXRotation, -maxRotationAngle, maxRotationAngle);
        transform.localEulerAngles = new Vector3(_currentXRotation, transform.localEulerAngles.y, transform.localEulerAngles.z);
    }
}
