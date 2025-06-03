using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Camera that follows and rotates around the player using mouse movement.
/// </summary>
public class CameraController : MonoBehaviour
{
    public Transform player; // The player to follow
    public Vector3 offset = new Vector3(0, 2.5f, -6.25f); // Default camera offset
    public float sensitivity = 3f; // Mouse rotation sensitivity
    public bool holdToRotate = true; // Require right-click to rotate

    private float yaw = 0f;

    void Start()
    {
        if (player == null)
        {
            Debug.LogWarning("Player not assigned to CameraController.");
        }

        // Initialize yaw from current rotation
        yaw = transform.eulerAngles.y;
    }

    void LateUpdate()
    {
        if (player == null) return;

        // Get mouse input
        bool canRotate = !holdToRotate || Input.GetMouseButton(1);
        if (canRotate)
        {
            float mouseX = Input.GetAxis("Mouse X");
            yaw += mouseX * sensitivity;
        }

        // Calculate camera rotation
        Quaternion rotation = Quaternion.Euler(0, yaw, 0);

        // Apply rotation to offset and update camera position
        Vector3 rotatedOffset = rotation * offset;
        transform.position = player.position + rotatedOffset;

        // Look at the player
        transform.LookAt(player.position + Vector3.up * 1.5f); // Slight vertical offset for better framing
    }
}
