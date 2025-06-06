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

    private Vector3 respawnPosition; // posición de respawn

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        respawnPosition = transform.position; // guarda la posición inicial como respawn
    }

    void Update()
    {
        // Movimiento
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        moveInput = new Vector3(moveX, 0f, moveZ).normalized;
        moveVelocity = moveInput * moveSpeed;

        // Salto
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        // Chequeo de caída: si se cae por debajo de cierto nivel, reaparece
        if (transform.position.y < -10f)
        {
            transform.position = respawnPosition;
            rb.velocity = Vector3.zero; // reinicia movimiento
        }
    }

    void FixedUpdate()
    {
        // Movimiento sin impulso físico
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Untagged") || other.gameObject.CompareTag("Platform"))
        {
            isGrounded = true;
        }
    }
}
