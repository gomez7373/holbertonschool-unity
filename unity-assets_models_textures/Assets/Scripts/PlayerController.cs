using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls player movement and jumping.
/// </summary>
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;

    private Rigidbody rb;
    private bool isGrounded = true;
    private Vector3 moveInput;
    private Vector3 moveVelocity;
    private Vector3 respawnPosition; // Respawn position

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        respawnPosition = transform.position; // Save initial position for respawn
    }

    void Update()
    {
        // Player movement input
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        moveInput = new Vector3(moveX, 0f, moveZ).normalized;
        moveVelocity = moveInput * moveSpeed;

        // Jumping input
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        // Fall detection & respawn
        if (transform.position.y < -10f)
        {
            transform.position = respawnPosition;
            rb.velocity = Vector3.zero;
        }
    }

    void FixedUpdate()
    {
        // Apply movement in physics update
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }

    void OnCollisionEnter(Collision other)
    {
        // Ground detection: only set grounded if colliding from above
        foreach (ContactPoint contact in other.contacts)
        {
            if (contact.normal.y > 0.5f)
            {
                isGrounded = true;
                break;
            }
        }
    }
}
