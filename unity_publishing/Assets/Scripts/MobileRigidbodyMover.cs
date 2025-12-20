using UnityEngine;

public class MobileRigidbodyMover : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 700f;
    public SimpleJoystick joystick;
    public GameObject mobileControlsUI;

    void Awake()
    {
        bool isMobile = Application.isMobilePlatform;

        if (mobileControlsUI != null)
            mobileControlsUI.SetActive(isMobile);

        enabled = isMobile; // solo corre en móvil

        if (rb == null) rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (rb == null || joystick == null) return;

        float h = joystick.Horizontal(); // X
        float v = joystick.Vertical();   // Z

        Vector3 move = new Vector3(h, 0f, v);
        rb.AddForce(move * speed * Time.deltaTime);
    }
}
