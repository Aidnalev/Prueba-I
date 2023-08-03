using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraF : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset = new Vector3(0, 1.67f, 0.3f);
    public float mouseSensitivity = 3.0f;
    public float verticalClampAngle = 80.0f;

    private float rotationX = 0.0f;

    void LateUpdate()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        player.transform.Rotate(Vector3.up * mouseX);

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -verticalClampAngle, verticalClampAngle);

        Quaternion playerRotation = Quaternion.Euler(0, player.transform.eulerAngles.y, 0);
        Quaternion cameraRotation = Quaternion.Euler(rotationX, player.transform.eulerAngles.y, 0);
        transform.rotation = cameraRotation;

        transform.position = player.transform.position + (playerRotation * offset);
    }
}
