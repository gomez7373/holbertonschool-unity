using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseCanvas; // Drag in Inspector
    public static bool isPaused; // Global pause flag

    void Start()
    {
        // Ensure canvas starts hidden
        if (pauseCanvas != null)
            pauseCanvas.SetActive(false);

        isPaused = false;

        // Lock cursor at game start
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
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
        isPaused = true;

        //  UNLOCK MOUSE FOR MENU
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Resume()
    {
        if (pauseCanvas == null) return;

        pauseCanvas.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;

        //  LOCK MOUSE BACK FOR GAMEPLAY
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Restart()
    {
        Resume(); // Unpause first
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

    private bool IsPaused()
    {
        return pauseCanvas != null && pauseCanvas.activeSelf;
    }
}
