using UnityEngine;

/// <summary>
/// Handles third-person camera movement and Y-axis inversion.
/// </summary>
public class CameraController : MonoBehaviour
{
    [Header("Target")]
    public Transform player; // Reference to the player

    [Header("Camera Settings")]
    public Vector3 offset = new Vector3(0, 3, -6); // Default offset (behind player)
    public float rotationSpeed = 5f;               // Rotation sensitivity
    public float smoothSpeed = 0.125f;             // Smoothing factor
    public bool isInverted = false;                // Invert Y-axis

    private float yaw;   // Horizontal rotation
    private float pitch; // Vertical rotation

    void Start()
    {
        if (player == null)
        {
            Debug.LogError("CameraController: No player assigned!");
            return;
        }

        // Initialize yaw based on player rotation
        yaw = player.eulerAngles.y;
        pitch = 10f; // Small tilt down for better view

        // Place camera directly behind the player at start
        Vector3 initialPosition = player.position + offset;
        transform.position = initialPosition;
        transform.LookAt(player);

        // Load saved invert Y-axis setting
        isInverted = PlayerPrefs.GetInt("InvertY", 0) == 1;
    }

    void LateUpdate()
    {
        if (Time.timeScale == 0f || player == null) return;

        // Mouse input
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed * (isInverted ? -1 : 1);

        // Update yaw and pitch
        yaw += mouseX;
        pitch -= mouseY;

        // Clamp vertical rotation
        pitch = Mathf.Clamp(pitch, -10f, 45f);

        // Apply rotation
        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);

        // Smooth follow
        Vector3 desiredPosition = player.position + rotation * offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Always look at the player
        transform.LookAt(player);
    }

    /// <summary>
    /// Set Y-axis inversion from OptionsMenu.
    /// </summary>
    public void SetInvertY(bool invert)
    {
        isInverted = invert;
        PlayerPrefs.SetInt("InvertY", invert ? 1 : 0);
        PlayerPrefs.Save();
    }
}
