using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    public Toggle InvertYToggle;
    public Slider BGMSlider;
    public Slider SFXSlider;

    private CameraController cameraController;

    void Start()
    {
        // Load saved values safely
        if (InvertYToggle != null)
        {
            InvertYToggle.isOn = PlayerPrefs.GetInt("InvertY", 0) == 1;
        }

        if (BGMSlider != null)
        {
            BGMSlider.value = PlayerPrefs.GetFloat("BGMVolume", 1f);
        }

        if (SFXSlider != null)
        {
            SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume", 1f);
        }

        // Find camera
        cameraController = FindObjectOfType<CameraController>();
        if (cameraController != null && InvertYToggle != null)
        {
            cameraController.SetInvertY(InvertYToggle.isOn);
        }

        // Apply BGM volume globally if available
        if (BGMSlider != null)
        {
            AudioListener.volume = BGMSlider.value;
        }
    }

    public void Apply()
    {
        // Save settings
        if (InvertYToggle != null)
        {
            PlayerPrefs.SetInt("InvertY", InvertYToggle.isOn ? 1 : 0);
        }

        if (BGMSlider != null)
        {
            PlayerPrefs.SetFloat("BGMVolume", BGMSlider.value);
            AudioListener.volume = BGMSlider.value;
        }

        if (SFXSlider != null)
        {
            PlayerPrefs.SetFloat("SFXVolume", SFXSlider.value);
        }

        PlayerPrefs.Save();

        // Update camera inversion
        if (cameraController != null && InvertYToggle != null)
        {
            cameraController.SetInvertY(InvertYToggle.isOn);
        }

        // Go back to previous scene
        SceneManager.LoadScene(PlayerPrefs.GetString("PreviousScene", "MainMenu"));
    }

    public void Back()
    {
        // Return without saving
        SceneManager.LoadScene(PlayerPrefs.GetString("PreviousScene", "MainMenu"));
    }
}
