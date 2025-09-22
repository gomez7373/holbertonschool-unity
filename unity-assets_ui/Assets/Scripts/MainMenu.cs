using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Load level scenes
    public void LevelSelect(int level)
    {
        switch (level)
        {
            case 1:
                SceneManager.LoadScene("Level01");
                break;
            case 2:
                SceneManager.LoadScene("Level02");
                break;
            case 3:
                SceneManager.LoadScene("Level03");
                break;
        }
    }

    // Load Options scene
    public void Options()
    {
        SceneManager.LoadScene("Options");
    }

    // Exit game
    public void Exit()
    {
        Debug.Log("Exited");
        Application.Quit();
    }
}
