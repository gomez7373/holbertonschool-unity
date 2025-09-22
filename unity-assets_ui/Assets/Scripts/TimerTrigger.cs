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
            Timer timer = other.GetComponent<Timer>();
            if (timer != null)
            {
                timer.enabled = true;   // Enable the script
                timer.StartTimer();     // Start counting
                Destroy(gameObject);    // Remove trigger
            }
        }
    }
}
