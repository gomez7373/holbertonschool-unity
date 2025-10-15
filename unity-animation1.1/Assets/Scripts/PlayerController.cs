using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls player movement and jumping (Rigidbody-based).
/// Updated for Task 4: Player turns with A/D instead of strafing.
/// </summary>
public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;       // Speed for W/S movement
    public float rotationSpeed = 120f; // Speed for turning (A/D)
    public float jumpForce = 7f;       // Jump force

    private Rigidbody rb;
    private bool isGrounded = true;
    private Vector3 respawnPosition;   // Starting point for respawn

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        respawnPosition = transform.position;
    }

    void Update()
    {
        // --- ROTATION (A/D or arrow keys) ---
        float turn = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * turn * rotationSpeed * Time.deltaTime);

        // --- MOVEMENT (W/S) ---
        float moveZ = Input.GetAxis("Vertical");
        Vector3 moveDir = transform.forward * moveZ * moveSpeed;
        Vector3 newPos = rb.position + moveDir * Time.deltaTime;
        rb.MovePosition(newPos);

        // --- JUMP ---
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        // --- FALL & RESPAWN ---
        if (transform.position.y < -10f)
        {
            transform.position = respawnPosition;
            rb.velocity = Vector3.zero;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        // Detect landing (only if touching from above)
        foreach (ContactPoint contact in other.contacts)
        {
            if (contact.normal.y > 0.5f)
            {
                isGrounded = true;
                break;
            }
        }
    }

    // --- Animation helpers (for PlayerAnimatorController) ---
    public bool IsGrounded()
    {
        return isGrounded;
    }

    public bool IsJumping()
    {
        return !isGrounded;
    }
}