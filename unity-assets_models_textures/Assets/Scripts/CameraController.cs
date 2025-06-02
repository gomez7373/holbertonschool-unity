using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;           // Referencia al jugador
    public Vector3 offset = new Vector3(0, 2.5f, -6.25f);
    public float sensitivity = 100f;   // Sensibilidad del mouse
    public bool holdToRotate = true;   // Solo rota si presionas clic derecho

    float rotationY = 0f;

    void LateUpdate()
    {
        if (player == null)
            return;

        // Movimiento de cámara con offset
        transform.position = player.position + offset;

        // Rotación de cámara con mouse (sólo si se presiona clic derecho)
        if (!holdToRotate || Input.GetMouseButton(1))
        {
            float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
            rotationY += mouseX;
            transform.RotateAround(player.position, Vector3.up, mouseX);
        }
    }
}
