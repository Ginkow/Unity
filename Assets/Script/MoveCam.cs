using UnityEngine;

public class MoveCam : MonoBehaviour
{
    public float maxRotationAngle = 90f;
    private float _currentXRotation = 0f;

    // Update is called once per frame
    void Update()
    {
        if (Timer.IsGameEnd)
        {
            return;
        }

        float RotationSpeed = SensibilityMouse.mouseSensibility;
        float mouseY = Input.GetAxis("Mouse Y") * RotationSpeed;
        transform.Rotate(new Vector3(-mouseY, 0, 0));

        _currentXRotation -= mouseY;
        _currentXRotation = Mathf.Clamp(_currentXRotation, -maxRotationAngle, maxRotationAngle);
        transform.localEulerAngles = new Vector3(_currentXRotation, transform.localEulerAngles.y, transform.localEulerAngles.z);
    }
}
