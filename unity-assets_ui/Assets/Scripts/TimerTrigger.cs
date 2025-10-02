using UnityEngine;

/// <summary>
/// Activates the timer when the player exits the trigger zone.
/// </summary>
public class TimerTrigger : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Find Timer in the scene (not only inside Player)
            Timer timer = FindObjectOfType<Timer>();
            if (timer != null)
            {
                timer.enabled = true;   // Ensure it is active
                timer.StartTimer();     // Start counting
                Destroy(gameObject);    // Remove trigger so it runs once
            }
        }
    }
}
