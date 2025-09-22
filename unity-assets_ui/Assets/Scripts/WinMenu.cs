using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
    public void MainMenu()
    {
        // Load the MainMenu scene
        SceneManager.LoadScene("MainMenu");
    }

    public void Next()
    {
        // Get current scene index
        int currentIndex = SceneManager.GetActiveScene().buildIndex;

        // If not the last scene, load the next one
        if (currentIndex + 1 < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(currentIndex + 1);
        }
        else
        {
            // If it is the last scene, return to MainMenu
            SceneManager.LoadScene("MainMenu");
        }
    }
}
