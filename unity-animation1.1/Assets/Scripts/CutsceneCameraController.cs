using UnityEngine;

public class CutsceneCameraController : MonoBehaviour
{
    public Animator animator;
    public float speed = 0.5f; // Ajusta velocidad de la animacion
    public System.Action OnCutsceneEnd; // Evento que avisará al otro script

    private bool finished = false;

    void Start()
    {
        if (animator == null)
            animator = GetComponent<Animator>();

        animator.speed = speed;
    }

    void Update()
    {
        if (animator == null || finished)
            return;

        AnimatorStateInfo state = animator.GetCurrentAnimatorStateInfo(0);
        if (state.IsName("Intro01") && state.normalizedTime >= 0.98f)
        {
            finished = true;
            OnCutsceneEnd?.Invoke(); //  Avisar que termino la animacion
        }
    }
}
