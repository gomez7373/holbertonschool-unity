using UnityEngine;

/// <summary>
/// Activates WinCanvas and stops the timer when player reaches WinFlag.
/// </summary>
public class WinTrigger : MonoBehaviour
{
    public GameObject winCanvas; // Drag WinCanvas here in Inspector

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player reached WinFlag!");

            // Show WinCanvas
            if (winCanvas != null)
                winCanvas.SetActive(true);

            // Stop timer and update FinalTime text
            Timer timer = FindObjectOfType<Timer>();
            if (timer != null)
            {
                Debug.Log("Timer found, stopping...");
                timer.Win();
            }

            // Disable player movement
            PlayerController controller = other.GetComponent<PlayerController>();
            if (controller != null)
                controller.enabled = false;
        }
    }
}
