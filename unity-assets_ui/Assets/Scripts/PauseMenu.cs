using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseCanvas; // drag in Inspector

    void Start()
    {
        // Ensure canvas starts hidden
        if (pauseCanvas != null)
            pauseCanvas.SetActive(false);

        // Sync flag with actual canvas state
        isPaused = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("ESC pressed | isPaused = " + isPaused);

            if (IsPaused()) Resume();
            else Pause();
        }
    }

    public void Pause()
    {
        if (pauseCanvas == null) return;

        pauseCanvas.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        if (pauseCanvas == null) return;

        pauseCanvas.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Restart()
    {
        Resume(); // unpause first
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        Resume();
        SceneManager.LoadScene("MainMenu");
    }

    public void Options()
    {
        Resume();
        SceneManager.LoadScene("Options");
    }

    // Helper: check directly if menu is active
    private bool IsPaused()
    {
        return pauseCanvas != null && pauseCanvas.activeSelf;
    }

    // Backwards compatibility if something else checks it
    public static bool isPaused;
}
