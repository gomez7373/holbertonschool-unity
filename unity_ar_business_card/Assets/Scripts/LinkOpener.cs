using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Abre enlaces (mailto y http/https) y da feedback visual/sonoro al pulsar.
/// </summary>
public class LinkOpener : MonoBehaviour
{
    [Header("Audio feedback")]
    [Tooltip("Sonido corto de click al pulsar un botón")]
    public AudioSource clickAudio;

    // === MÉTODOS ESPECÍFICOS ===

    /// <summary>
    /// Abre tu perfil de Medium.
    /// </summary>
    public void OpenMedium()
    {
        Application.OpenURL("https://medium.com/@sgc.holberton");
        PlayClick();
    }

    /// <summary>
    /// Abre tu perfil de GitHub.
    /// </summary>
    public void OpenGithub()
    {
        Application.OpenURL("https://github.com/gomez7373");
        PlayClick();
    }

    /// <summary>
    /// Abre tu perfil de LinkedIn.
    /// </summary>
    public void OpenLinkedIn()
    {
        Application.OpenURL("https://www.linkedin.com/in/sheilagomezcubero?utm_source=share&utm_campaign=share_via&utm_content=profile&utm_medium=android_app");
        PlayClick();
    }

    /// <summary>
    /// Abre el cliente de correo con tu dirección.
    /// </summary>
    public void OpenEmail()
    {
        Application.OpenURL("mailto:se.gomez.sheila@gmail.com");
        PlayClick();
    }

    // === MÉTODOS GENÉRICOS (opcionales si quieres reutilizar) ===

    public void OpenEmail(string email)
    {
        if (string.IsNullOrEmpty(email)) return;
        Application.OpenURL($"mailto:{email}");
        PlayClick();
    }

    public void OpenUrl(string url)
    {
        if (string.IsNullOrEmpty(url)) return;
        if (!url.StartsWith("http")) url = "https://" + url;
        Application.OpenURL(url);
        PlayClick();
    }

    // === REPRODUCIR AUDIO ===

    private void PlayClick()
    {
        if (clickAudio != null) clickAudio.Play();
    }
}
