using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pauseCanvas;

    void Start()
    {
        // Ensure pause menu is hidden at start
        if (pauseCanvas != null)
            pauseCanvas.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                Resume();
            else
                Pause();
        }
    }

    public void Pause()
    {
        if (pauseCanvas == null) return;

        isPaused = true;
        pauseCanvas.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        if (pauseCanvas == null) return;

        isPaused = false;
        pauseCanvas.SetActive(false);
        ResumeTime();
    }

    public void Restart()
    {
        isPaused = false;
        ResumeTime();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        isPaused = false;
        ResumeTime();
        SceneManager.LoadScene("MainMenu");
    }

    public void Options()
    {
        isPaused = false;
        ResumeTime();
        SceneManager.LoadScene("Options");
    }

    private void ResumeTime()
    {
        Time.timeScale = 1f;
    }
}
