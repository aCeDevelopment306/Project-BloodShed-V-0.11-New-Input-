using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] float mouseSensitivityX = 8f;
    [SerializeField] float mouseSensitivityY = 2f;
    [SerializeField] float stickSensitivityX = 5f;
    [SerializeField] float stickSensitivityY = 2f;
    [SerializeField] Transform camera;
    [SerializeField] float xClamp = 85f;

    float xRotation = 0f;

    float mouseX;
    float mouseY;
    float stickX;
    float stickY;

    private void Update()
    {
        transform.Rotate(Vector3.up, mouseX);

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -xClamp, xClamp);
        Vector3 targetRotation = transform.eulerAngles;
        targetRotation.x = xRotation;
        camera.eulerAngles = targetRotation;
    }

    public void RecieveInput(Vector2 mouseInput)
    {
        mouseX = mouseInput.x * mouseSensitivityX;
        mouseY = mouseInput.y * mouseSensitivityY;
        stickX = mouseInput.x * stickSensitivityX;
        stickY = mouseInput.y * stickSensitivityY;

    }
}
