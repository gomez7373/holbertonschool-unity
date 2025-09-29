using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    [Header("UI Elements")]
    public Toggle InvertYToggle;
    public Slider BGMSlider;
    public Slider SFXSlider;

    private CameraController cameraController;

    void Start()
    {
        // Load saved values
        InvertYToggle.isOn = PlayerPrefs.GetInt("InvertY", 0) == 1;
        BGMSlider.value = PlayerPrefs.GetFloat("BGMVolume", 1f);
        SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume", 1f);

        // Find CameraController
        cameraController = FindObjectOfType<CameraController>();
        if (cameraController != null)
            cameraController.SetInvertY(InvertYToggle.isOn);

        // Apply BGM volume globally
        AudioListener.volume = BGMSlider.value;
    }

    // Save settings and return
    public void Apply()
    {
        PlayerPrefs.SetInt("InvertY", InvertYToggle.isOn ? 1 : 0);
        PlayerPrefs.SetFloat("BGMVolume", BGMSlider.value);
        PlayerPrefs.SetFloat("SFXVolume", SFXSlider.value);
        PlayerPrefs.Save();

        if (cameraController != null)
            cameraController.SetInvertY(InvertYToggle.isOn);

        // Load previous scene (default = MainMenu)
        string previousScene = PlayerPrefs.GetString("PreviousScene", "MainMenu");
        SceneManager.LoadScene(previousScene);
    }

    // Return without saving
    public void Back()
    {
        string previousScene = PlayerPrefs.GetString("PreviousScene", "MainMenu");
        SceneManager.LoadScene(previousScene);
    }
}
