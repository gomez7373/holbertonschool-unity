using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Tracks and displays elapsed time.
/// </summary>
public class Timer : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private Text timerText;     // In-game timer text (top of screen)
    [SerializeField] private Text finalTimeText; // WinCanvas "FinalTime" text

    private float elapsedTime = 0f;
    private bool isRunning = false;

    void Update()
    {
        if (!isRunning) return;

        elapsedTime += Time.deltaTime;
        UpdateTimerUI(timerText, elapsedTime);
    }

    /// <summary>
    /// Starts the timer.
    /// </summary>
    public void StartTimer()
    {
        isRunning = true;
        elapsedTime = 0f;
    }

    /// <summary>
    /// Stops the timer and updates the WinCanvas UI.
    /// </summary>
    public void Win()
    {
        isRunning = false;

        // Format final time
        string finalTime = FormatTime(elapsedTime);

        // Change in-game timer to green
        if (timerText != null)
        {
            timerText.color = Color.green;
        }

        // Update WinCanvas "FinalTime" text
        if (finalTimeText != null)
        {
            finalTimeText.text = finalTime;
            finalTimeText.color = Color.white;
            finalTimeText.fontSize = 100;
        }
    }

    /// <summary>
    /// Returns elapsed time in seconds.
    /// </summary>
    public float GetElapsedTime()
    {
        return elapsedTime;
    }

    /// <summary>
    /// Helper: update a Text component with formatted time.
    /// </summary>
    private void UpdateTimerUI(Text textComponent, float time)
    {
        if (textComponent == null) return;
        textComponent.text = FormatTime(time);
    }

    /// <summary>
    /// Helper: format time into mm:ss.ff
    /// </summary>
    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60f);
        float seconds = time % 60f;
        return string.Format("{0:0}:{1:00.00}", minutes, seconds);
    }
}
