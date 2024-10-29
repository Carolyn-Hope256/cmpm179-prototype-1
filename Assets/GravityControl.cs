using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GravityControl : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] GameObject cam;
    Vector2 mousePos;

    [SerializeField] float mouseSensitivity = 1000000;
    [SerializeField] float playerAcceleration;
    [SerializeField] float initialForce;
    [SerializeField] float maxSpeed;
    [SerializeField] AudioSource collisionSFX;

    bool m1Pressed = false;
    bool m1Released = false;

    bool falling = false;
    
    Vector3 fallDirection;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")).normalized;
        cam.transform.Rotate(new Vector2(-mousePos.y * mouseSensitivity * Time.deltaTime, 0));
        gameObject.transform.Rotate(new Vector2(0, mousePos.x * mouseSensitivity * Time.deltaTime));

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            m1Pressed = true;
        }

        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            m1Pressed = false;
        }
    }

    void FixedUpdate()
    {
        if (falling)
        {
            if (rb.linearVelocity.magnitude < maxSpeed)
            {
                rb.AddForce(fallDirection * playerAcceleration);
            }
            fallDirection = Camera.main.transform.forward.normalized;
            rb.linearVelocity = fallDirection * rb.linearVelocity.magnitude;
            m1Pressed = false;
        }
        else
        {
            if (m1Pressed)
            {
                falling = true;
                m1Pressed = false;
                fallDirection = Camera.main.transform.forward.normalized;
                rb.AddForce(fallDirection * initialForce, ForceMode.Impulse);
            }
        }
    }

    void OnCollisionEnter (Collision collision)
    {
        falling = false;
        rb.linearVelocity = Vector3.zero;
        collisionSFX.Play();
    }
}
