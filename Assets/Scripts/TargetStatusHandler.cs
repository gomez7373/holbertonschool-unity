using UnityEngine;
using Vuforia;

/// <summary>
/// Enables or disables an object when the ImageTarget is visible.
/// Only accepts strict TRACKED status (ignores ExtendedTracked or Limited).
/// </summary>
[DisallowMultipleComponent]
public class TargetStatusHandler : MonoBehaviour
{
    [Tooltip("Object that becomes active only when the target is visible")]
    public GameObject contentToToggle;

    private ObserverBehaviour observer;

    void Awake()
    {
        observer = GetComponent<ObserverBehaviour>();
        if (observer != null)
            observer.OnTargetStatusChanged += OnTargetStatusChanged;

        // Start hidden
        if (contentToToggle != null)
            contentToToggle.SetActive(false);
    }

    private void OnTargetStatusChanged(ObserverBehaviour behaviour, TargetStatus status)
    {
        if (contentToToggle == null) return;

        // Show only if strictly TRACKED
        bool visible = (status.Status == Status.TRACKED);

        contentToToggle.SetActive(visible);

        UnityEngine.Debug.Log(
            $"[TargetStatusHandler] {behaviour.TargetName} => {status.Status} => visible={visible}"
        );
    }
}
