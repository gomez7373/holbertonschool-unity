using UnityEngine;
using System.Collections;

public class CutsceneManager : MonoBehaviour
{
    public Camera mainCamera;
    public Camera cutsceneCamera;
    public GameObject player;
    public GameObject timerCanvas;
    public CutsceneCameraController cameraController;

    void Start()
    {
        if (cameraController != null)
            cameraController.OnCutsceneEnd += HandleCutsceneEnd;

        if (mainCamera != null)
            mainCamera.enabled = false;

        if (player != null)
        {
            var ctrl = player.GetComponent<PlayerController>();
            if (ctrl != null)
                ctrl.enabled = false;
        }

        if (timerCanvas != null)
            timerCanvas.SetActive(false);
    }

    private void HandleCutsceneEnd()
    {
        StartCoroutine(SwitchCameras());
    }

    private IEnumerator SwitchCameras()
    {
        yield return new WaitForEndOfFrame();

        if (mainCamera != null)
            mainCamera.enabled = true;

        if (cutsceneCamera != null)
            cutsceneCamera.enabled = false;

        if (player != null)
        {
            var ctrl = player.GetComponent<PlayerController>();
            if (ctrl != null)
                ctrl.enabled = true;
        }

        if (timerCanvas != null)
            timerCanvas.SetActive(true);

        Debug.Log(" Gameplay active — Cutscene finished");
    }
}
