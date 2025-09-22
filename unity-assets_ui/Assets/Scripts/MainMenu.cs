using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // This function loads the selected level based on the input parameter
    public void LevelSelect(int level)
    {
        Debug.Log("Button pressed: Level " + level); // Verification

        switch (level)
        {
            case 1:
                Debug.Log("Trying to load Level01");
                SceneManager.LoadScene("Level01");
                break;
            case 2:
                Debug.Log("Trying to load Level02");
                SceneManager.LoadScene("Level02");
                break;
            case 3:
                Debug.Log("Trying to load Level03");
                SceneManager.LoadScene("Level03");
                break;
            default:
                Debug.LogWarning("Invalid level number!");
                break;
        }
    }

    // This function loads the Options scene
    public void Options()
    {
        Debug.Log("Button pressed: Options"); // Verification

        // Save the current scene name as the previous scene
        PlayerPrefs.SetString("PreviousScene", "MainMenu");
        SceneManager.LoadScene("Options");
    }

    // This function closes the game and prints to console
    public void Exit()
    {
        Debug.Log("Button pressed: Exit"); // Verification
        Application.Quit();
    }
}
