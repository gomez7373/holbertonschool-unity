using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Tracks and displays elapsed time.
/// </summary>
public class Timer : MonoBehaviour
{
    public Text timerText;
    private float elapsedTime = 0f;
    private bool isRunning = false;

    void Update()
    {
        if (!isRunning) return;

        elapsedTime += Time.deltaTime;

        int minutes = Mathf.FloorToInt(elapsedTime / 60f);
        float seconds = elapsedTime % 60f;

        timerText.text = string.Format("{0:0}:{1:00.00}", minutes, seconds);
    }

    public void StartTimer()
    {
        isRunning = true;
    }

    public float GetElapsedTime()
    {
        return elapsedTime;
    }
}
