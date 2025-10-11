using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Start()
    {
        //  Make cursor visible in the main menu
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Load level scenes
    public void LevelSelect(int level)
    {
        string sceneName = $"Level0{level}";
        SceneManager.LoadScene(sceneName);
    }

    // Load Options scene and save current scene as "PreviousScene"
    public void Options()
    {
        PlayerPrefs.SetString("PreviousScene", SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("Options");
    }

    // Exit game
    public void Exit()
    {
        Debug.Log("Exited");
        Application.Quit();
    }
}
