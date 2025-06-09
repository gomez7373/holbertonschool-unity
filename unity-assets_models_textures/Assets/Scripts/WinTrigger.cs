using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Stops timer and updates timer text when Player reaches WinFlag.
/// </summary>
public class WinTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("🏁 Player reached WinFlag!");

            Timer timer = other.GetComponent<Timer>();
            if (timer != null)
            {
                timer.enabled = false;
            }

            // Get the TimerText from the Timer script
            Text timerText = timer.timerText;
            if (timerText != null)
            {
                timerText.fontSize = 60; // Make it bigger
                timerText.color = Color.green; // Make it green
            }

            // Optional: disable movement
            PlayerController controller = other.GetComponent<PlayerController>();
            if (controller != null)
            {
                controller.enabled = false;
            }
        }
    }
}
