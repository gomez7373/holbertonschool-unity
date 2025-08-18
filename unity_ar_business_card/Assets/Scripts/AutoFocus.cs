using UnityEngine;
using Vuforia;

public class AutoFocus : MonoBehaviour
{
    void OnEnable()
    {
        VuforiaApplication.Instance.OnVuforiaStarted += SetAutoFocus;
    }

    void OnDisable()
    {
        VuforiaApplication.Instance.OnVuforiaStarted -= SetAutoFocus;
    }

    void SetAutoFocus()
    {
        var cam = VuforiaBehaviour.Instance?.CameraDevice;
        if (cam == null) return;

        // Vuforia 11.x usa Vuforia.FocusMode con esta constante:
        cam.SetFocusMode(FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
    }

    void OnApplicationPause(bool pause)
    {
        if (!pause) SetAutoFocus(); // reaplica al volver de pausa
    }
}
