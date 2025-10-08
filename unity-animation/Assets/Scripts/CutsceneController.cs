using UnityEngine;
using System.Collections;

public class CutsceneController : MonoBehaviour
{
    public Camera mainCamera;              // Main camera of gameplay
    public Camera cutsceneCamera;          // This camera (for intro)
    public GameObject player;              // Player object
    public GameObject timerCanvas;         // Timer canvas UI

    private Animator animator;             // Animator on the CutsceneCamera

    void Start()
    {
        animator = GetComponent<Animator>();

        // Disable gameplay controls and UI during the intro
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
    }

    void Update()
    {
        if (animator == null) return;

        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        // Detect if the current animation is Intro01 and has finished
        if (stateInfo.IsName("Intro01") && stateInfo.normalizedTime >= 0.99f)
        {
            Debug.Log("[Cutscene] Intro finished — preparing to switch cameras");
            StartCoroutine(SwitchCameras());
        }
    }

    private IEnumerator SwitchCameras()
    {
        // Wait until the end of the current frame to avoid "No cameras rendering"
        yield return new WaitForEndOfFrame();

        if (mainCamera != null)
        {
            mainCamera.enabled = true;
            Debug.Log("[Cutscene] Main Camera enabled");
        }

        if (cutsceneCamera != null)
        {
            cutsceneCamera.enabled = false;
            Debug.Log("[Cutscene] Cutscene Camera disabled");
        }

        if (player != null)
        {
            var controller = player.GetComponent<PlayerController>();
            if (controller != null)
            {
                controller.enabled = true;
                Debug.Log("[Cutscene] Player control re-enabled");
            }
        }

        if (timerCanvas != null)
        {
            timerCanvas.SetActive(true);
            Debug.Log("[Cutscene] Timer Canvas active");
        }

        // Disable this script once the intro is over.
        this.enabled = false;
    }
}
