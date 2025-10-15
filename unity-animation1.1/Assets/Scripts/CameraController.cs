using UnityEngine;

/// <summary>
/// Handles third-person camera movement and Y-axis inversion.
/// Follows player position, but does NOT rotate with player rotation.
/// Camera rotates only with mouse movement.
/// </summary>
public class CameraController : MonoBehaviour
{
    [Header("Target")]
    public Transform player; // Reference to the player

    [Header("Camera Settings")]
    public Vector3 offset = new Vector3(0, 3, -6); // Default offset (behind player)
    public float rotationSpeed = 5f;               // Mouse sensitivity
    public float smoothSpeed = 0.125f;             // Follow smoothness
    public bool isInverted = false;                // Invert Y-axis toggle

    private float yaw;   // Horizontal rotation
    private float pitch; // Vertical rotation

    void Start()
    {
        if (player == null)
        {
            Debug.LogError("CameraController: No player assigned!");
            return;
        }

        // Initialize yaw and pitch
        yaw = transform.eulerAngles.y;
        pitch = 10f; // Slight downward tilt

        // Position camera behind player
        Vector3 startPos = player.position + offset;
        transform.position = startPos;
        transform.LookAt(player.position + Vector3.up * 1.5f);

        // Load inversion preference
        isInverted = PlayerPrefs.GetInt("InvertY", 0) == 1;

        // Lock cursor to center
        Cursor.lockState = CursorLockMode.Locked;
    }

    void LateUpdate()
    {
        if (Time.timeScale == 0f || player == null)
            return;

        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed * (isInverted ? -1 : 1);

        // Update rotation angles
        yaw += mouseX;
        pitch -= mouseY;
        pitch = Mathf.Clamp(pitch, -10f, 45f);

        // Camera rotation from mouse only
        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);

        // Follow player smoothly (position only)
        Vector3 targetPos = player.position + rotation * offset;
        transform.position = Vector3.Lerp(transform.position, targetPos, smoothSpeed);

        // Apply camera rotation
        transform.rotation = rotation;

        // NOTE: We do NOT modify player's rotation here!
        // Player rotation is now fully handled by PlayerController (A/D keys).
    }

    /// <summary>
    /// Allows external UI (like Options Menu) to set Y-axis inversion.
    /// </summary>
    public void SetInvertY(bool invert)
    {
        isInverted = invert;
        PlayerPrefs.SetInt("InvertY", invert ? 1 : 0);
        PlayerPrefs.Save();
    }
}
