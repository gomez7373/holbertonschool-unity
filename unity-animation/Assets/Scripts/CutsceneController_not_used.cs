using UnityEngine;
using System.Collections;

public class CutsceneController : MonoBehaviour
{
    public Camera mainCamera;       // Main camera for gameplay
    public Camera cutsceneCamera;   // Intro camera
    public GameObject player;       // Player object
    public GameObject timerCanvas;  // Timer canvas UI

    private Animator animator;      // Animator on CutsceneCamera
    private bool isSwitching = false;

    void Start()
    {
        animator = GetComponent<Animator>();

        // Disable gameplay while intro plays
        if (mainCamera != null)
            mainCamera.enabled = false;

        if (player != null)
        {
            var controller = player.GetComponent<PlayerController>();
            if (controller != null)
                controller.enabled = false;
        }

        if (timerCanvas != null)
            timerCanvas.SetActive(false);

        // Slow down animation a bit
        if (animator != null)
            animator.speed = 0.5f; // 0.5 = half speed (you can change this)
    }

    void Update()
    {
        if (animator == null || isSwitching)
            return;

        AnimatorStateInfo state = animator.GetCurrentAnimatorStateInfo(0);

        // Wait until animation "Intro01" is almost done
        if (state.IsName("Intro01") && state.normalizedTime >= 0.98f)
        {
            StartCoroutine(SwitchCameras());
        }
    }

    private IEnumerator SwitchCameras()
    {
        isSwitching = true;

        // Wait for the end of the current frame (fixes Display 1 issue)
        yield return new WaitForEndOfFrame();

        if (mainCamera != null)
            mainCamera.enabled = true;

        if (cutsceneCamera != null)
            cutsceneCamera.enabled = false;

        if (player != null)
        {
            var controller = player.GetComponent<PlayerController>();
            if (controller != null)
                controller.enabled = true;
        }

        if (timerCanvas != null)
            timerCanvas.SetActive(true);

        // Disable this script (done)
        this.enabled = false;
    }


}
