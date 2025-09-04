using UnityEngine;
using Vuforia;

/// <summary>
/// Lanza animaciones Show/Hide según estado del marcador.
/// </summary>
[RequireComponent(typeof(ObserverBehaviour))]
public class TargetAnimator : MonoBehaviour
{
    [Tooltip("Animator del objeto padre con CanvasGroup")]
    public Animator animator;

    private ObserverBehaviour observer;

    void Awake()
    {
        observer = GetComponent<ObserverBehaviour>();
        if (observer != null)
            observer.OnTargetStatusChanged += OnTargetStatusChanged;
    }

    private void OnTargetStatusChanged(ObserverBehaviour behaviour, TargetStatus status)
    {
        if (animator == null) return;

        if (status.Status == Status.TRACKED)
            animator.SetTrigger("Show");
        else
            animator.SetTrigger("Hide");
    }
}
