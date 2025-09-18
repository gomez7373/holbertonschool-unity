using UnityEngine;
using System;   // Para Uri.EscapeDataString

/// <summary>
/// Uso este script para abrir mis enlaces (Medium, GitHub, LinkedIn) y
/// para mostrar la ventana de redacci�n de correo al pulsar el bot�n de Email.
/// Tambi�n reproduzco un click corto como feedback.
/// </summary>
public class LinkOpener : MonoBehaviour
{
    [Header("Audio / Feedback")]
    [Tooltip("Asigno aqu� un AudioSource con un sonido corto de click")]
    [SerializeField] private AudioSource clickAudio;

    [Header("Mis enlaces")]
    [SerializeField] private string mediumUrl = "https://medium.com/@sgc.holberton";
    [SerializeField] private string githubUrl = "https://github.com/gomez7373";
    [SerializeField] private string linkedinUrl = "https://www.linkedin.com/in/sheilagomezcubero?utm_source=share&utm_campaign=share_via&utm_content=profile&utm_medium=android_app";

    [Header("Email (Gmail Compose por defecto)")]
    [Tooltip("Correo al que quiero que me escriban")]
    [SerializeField] private string emailTo = "se.gomez.sheila@gmail.com";

    [Tooltip("Asunto por defecto (puede ir vac�o)")]
    [SerializeField] private string defaultSubject = ""; // Ej: "Consulta"

    [Tooltip("Cuerpo del mensaje por defecto (puede ir vac�o)")]
    [TextArea(3, 6)]
    [SerializeField] private string defaultBody = "";    // Ej: "Hola Sheila..."

    [Tooltip("Si lo activo, adem�s de Gmail intento abrir 'mailto:' como plan B")]
    [SerializeField] private bool alsoTryMailtoFallback = false;

    // ==========================
    // Botones espec�ficos
    // ==========================

    /// <summary>Abro mi perfil de Medium.</summary>
    public void OpenMedium()
    {
        OpenUrlSafe(mediumUrl);
    }

    /// <summary>Abro mi perfil de GitHub.</summary>
    public void OpenGithub()
    {
        OpenUrlSafe(githubUrl);
    }

    /// <summary>Abro mi perfil de LinkedIn.</summary>
    public void OpenLinkedIn()
    {
        OpenUrlSafe(linkedinUrl);
    }

    /// <summary>
    /// Abro directamente la ventana de redacci�n de Gmail con mi correo en "Para".
    /// Si el usuario no tiene sesi�n en Gmail, el navegador le pedir� iniciar sesi�n.
    /// Puedo activar un fallback con mailto si quiero cubrir clientes instalados.
    /// </summary>
    public void OpenEmail()
    {
        string gmailUrl = BuildGmailCompose(emailTo, defaultSubject, defaultBody);
        Application.OpenURL(gmailUrl);

        if (alsoTryMailtoFallback)
        {
            string mailto = BuildMailto(emailTo, defaultSubject, defaultBody);
            Application.OpenURL(mailto);
        }

        PlayClick();
    }

    // ==========================
    // Gen�ricos / Utilidades
    // ==========================

    /// <summary>Abro cualquier URL. Si no empieza con http, le antepongo https://</summary>
    public void OpenUrl(string url)
    {
        OpenUrlSafe(url);
    }

    /// <summary>Construyo la URL oficial de Gmail Compose con to/su/body codificados.</summary>
    private string BuildGmailCompose(string to, string subject, string body)
    {
        string su = Uri.EscapeDataString(subject ?? "");
        string bo = Uri.EscapeDataString(body ?? "");
        return $"https://mail.google.com/mail/?view=cm&fs=1&to={to}&su={su}&body={bo}";
    }

    /// <summary>Construyo un mailto con asunto y cuerpo (para fallback opcional).</summary>
    private string BuildMailto(string to, string subject, string body)
    {
        string su = Uri.EscapeDataString(subject ?? "");
        string bo = Uri.EscapeDataString(body ?? "");
        return $"mailto:{to}?subject={su}&body={bo}";
    }

    /// <summary>Abro una URL de forma segura (corrijo prefijo y doy feedback).</summary>
    private void OpenUrlSafe(string url)
    {
        if (string.IsNullOrWhiteSpace(url)) return;
        if (!url.StartsWith("http", StringComparison.OrdinalIgnoreCase))
            url = "https://" + url;

        Application.OpenURL(url);
        PlayClick();
    }

    /// <summary>Reproduzco el sonido de click si lo tengo asignado.</summary>
    private void PlayClick()
    {
        if (clickAudio != null) clickAudio.Play();
    }
}
