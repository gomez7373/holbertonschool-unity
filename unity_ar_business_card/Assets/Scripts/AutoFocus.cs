#if VUFORIA_PRESENT
using UnityEngine;
using Vuforia;

/// <summary>
/// Activo el autoenfoque continuo cuando arranca Vuforia
/// y lo reaplico al volver de pausa o cuando se reanuda el render.
/// </summary>
[DisallowMultipleComponent]
public class AutoFocus : MonoBehaviour
{
    void OnEnable()
    {
        VuforiaApplication.Instance.OnVuforiaStarted += SetAutoFocus;
        Application.onBeforeRender += OnBeforeRender;
    }

    void OnDisable()
    {
        VuforiaApplication.Instance.OnVuforiaStarted -= SetAutoFocus;
        Application.onBeforeRender -= OnBeforeRender;
    }

    void OnDestroy()
    {
        // por si el objeto se destruye sin pasar por OnDisable
        VuforiaApplication.Instance.OnVuforiaStarted -= SetAutoFocus;
        Application.onBeforeRender -= OnBeforeRender;
    }

    void OnApplicationPause(bool paused)
    {
        if (!paused) SetAutoFocus(); // reaplica al volver de pausa
    }

    void OnBeforeRender()
    {
        // útil en algunos dispositivos que “pierden” el modo de foco
        SetAutoFocus();
    }

    private void SetAutoFocus()
    {
        var cam = VuforiaBehaviour.Instance?.CameraDevice;
        if (cam == null) return;

        // En Vuforia 11.x el enum es CONTINUOUSAUTO
        bool ok = cam.SetFocusMode(FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
#if UNITY_EDITOR
        if (!ok) Debug.LogWarning("AutoFocus: no se pudo activar FOCUS_MODE_CONTINUOUSAUTO.");
#endif
    }
}
#else
using UnityEngine;

/// <summary>
/// Stub cuando Vuforia no está instalado. Evita errores de compilación.
/// </summary>
public class AutoFocus : MonoBehaviour { }
#endif
