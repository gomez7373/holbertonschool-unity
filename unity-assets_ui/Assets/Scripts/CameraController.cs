using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;            // Reference to the player
    public Vector3 offset;              // Camera offset
    public float rotationSpeed = 5.0f;  // Speed of rotation
    public float smoothSpeed = 0.125f;  // Speed of smoothing
    public bool isInverted = false;     // Invert Y-axis flag

    private float yaw;   // Horizontal rotation
    private float pitch; // Vertical rotation

    void Start()
    {
        // Align yaw to player initial Y rotation
        yaw = player.eulerAngles.y;
        pitch = 0f;

        // Set initial camera position
        Vector3 initialPosition = player.position + player.TransformDirection(offset);
        transform.position = initialPosition;
        transform.LookAt(player);

        // Load saved invert Y-axis setting
        isInverted = PlayerPrefs.GetInt("InvertY", 0) == 1;
    }

    void LateUpdate()
    {
        // Stop camera movement if game is paused
        if (Time.timeScale == 0f) return;

        // Get mouse input for rotation
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed * (isInverted ? -1 : 1);

        // Update yaw and pitch
        yaw += mouseX;
        pitch -= mouseY;

        // Clamp pitch to avoid extreme rotation
        pitch = Mathf.Clamp(pitch, -30f, 45f);

        // Calculate rotation
        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);

        // Smooth follow movement
        Vector3 desiredPosition = player.position + rotation * offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Keep looking at the player
        transform.LookAt(player);
    }

    // Method to update invert Y-axis setting from OptionsMenu
    public void SetInvertY(bool invert)
    {
        isInverted = invert;

        // Save change so it persists across scenes
        PlayerPrefs.SetInt("InvertY", invert ? 1 : 0);
        PlayerPrefs.Save();
    }
}
