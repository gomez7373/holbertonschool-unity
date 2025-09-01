using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Reproduce un sonido al hacer click en un botón UI.
/// </summary>
[RequireComponent(typeof(Button))]
public class UIButtonSound : MonoBehaviour
{
    /// <summary>
    /// Clip de audio a reproducir.
    /// </summary>
    public AudioClip clickSound;

    private Button button;
    private AudioSource audioSource;

    private void Awake()
    {
        button = GetComponent<Button>();
        audioSource = FindObjectOfType<AudioSource>();

        if (button != null && audioSource != null && clickSound != null)
            button.onClick.AddListener(PlayClick);
    }

    private void PlayClick()
    {
        audioSource.PlayOneShot(clickSound);
    }
}
