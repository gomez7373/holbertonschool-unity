using UnityEngine;
using Vuforia;

/// <summary>
/// Show or hide a layout when the marker is visible or not.
/// Works together with SequentialReveal for staggered appearance.
/// </summary>
[RequireComponent(typeof(ObserverBehaviour))]
public class TargetVisibility : MonoBehaviour
{
    [Tooltip("Layout object to show or hide")]
    public GameObject targetLayout;

    private ObserverBehaviour observer;
    private SequentialReveal reveal;

    void Awake()
    {
        observer = GetComponent<ObserverBehaviour>();
        if (observer != null)
            observer.OnTargetStatusChanged += OnTargetStatusChanged;

        if (targetLayout != null)
            reveal = targetLayout.GetComponentInChildren<SequentialReveal>();
    }

    private void OnTargetStatusChanged(ObserverBehaviour behaviour, TargetStatus status)
    {
        if (targetLayout == null) return;

        bool visible = status.Status == Status.TRACKED;

        targetLayout.SetActive(visible);

        if (visible)
        {
            if (reveal != null)
                reveal.StartReveal();
        }
        else
        {
            if (reveal != null)
                reveal.HideAll();
        }
    }
}
