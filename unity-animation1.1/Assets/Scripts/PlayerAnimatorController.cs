using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{
    [Header("References")]
    public Animator animator;              // Drag "ty" (the model)
    public Rigidbody playerRigidbody;      // Drag the Player object (with Rigidbody)
    public PlayerController playerController; // Optional: link for jump detection

    [Header("Animation Settings")]
    public float speedThreshold = 0.1f;    // When Speed > this, play Running
    public float fallThreshold = -2f;      // Y velocity to detect Falling

    private bool wasGrounded = true;
    private bool isFalling = false;

    void Update()
    {
        if (animator == null || playerRigidbody == null)
            return;

        // Horizontal velocity magnitude (ignore vertical)
        Vector3 flatVel = new Vector3(playerRigidbody.velocity.x, 0, playerRigidbody.velocity.z);
        float speed = flatVel.magnitude;

        // Update Animator Speed (Idle <-> Run)
        animator.SetFloat("Speed", speed);

        // Detect Falling
        bool currentlyFalling = playerRigidbody.velocity.y < fallThreshold;
        if (currentlyFalling && !isFalling)
        {
            isFalling = true;
            animator.SetBool("isFalling", true);
        }

        // Detect Landing
        if (!currentlyFalling && isFalling)
        {
            isFalling = false;
            animator.SetBool("isFalling", false);
        }

        // Jump trigger from PlayerController
        if (playerController != null && playerController.IsJumping())
        {
            animator.SetBool("isJumping", true);
        }
        else if (playerController != null && playerController.IsGrounded())
        {
            animator.SetBool("isJumping", false);
        }
    }

    // Optional triggers for later tasks (not active yet)
    public void TriggerImpact()
    {
        if (animator != null)
            animator.SetTrigger("Impact");
    }

    public void TriggerGetUp()
    {
        if (animator != null)
            animator.SetTrigger("GetUp");
    }
}
