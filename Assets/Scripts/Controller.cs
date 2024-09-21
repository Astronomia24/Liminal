using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Controller : MonoBehaviour
{
    private float yaw = 0.0f, pitch = 0.0f;
    private Rigidbody rb;

    public float walkSpeed = 5.0f, sensitivity = 2.0f;

    public Camera camera;
    public bool cd;
    nLaptop nl;
    PickUpClass pick;

    public Transform originalPos;
    public Vector3 mousePos;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = gameObject.GetComponent<Rigidbody>();
        nl = FindObjectOfType<nLaptop>();
        pick = FindObjectOfType<PickUpClass>();
        cd = true;
        originalPos = GameObject.Find("Hand").transform;
    }

    void Awake()
    {

    }
    void ResetCd()
    {
        cd = true;
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.Space) && rb.gameObject.transform.position.y <= 1.2f)
        {
            rb.velocity = new Vector3(rb.velocity.x, 5.0f, rb.velocity.z);
            cd = false;
            Invoke("ResetCd", 0.3f);
        }
        if (nl.isPause == false)
        {
            Look();
        }
        Application.targetFrameRate = -1;
    }

    private void FixedUpdate()
    {
        Movement();
    }
    
    void Look()
    {
        {
            GameObject.Find("Hand").transform.position = originalPos.position;
            pitch -= Input.GetAxisRaw("Mouse Y") * sensitivity;
            pitch = Mathf.Clamp(pitch, -90.0f, 90.0f);
            yaw += Input.GetAxisRaw("Mouse X") * sensitivity;
            Camera.main.transform.localRotation = Quaternion.Euler(pitch, yaw, 0);
        }
    }

    void Movement()
    {
        Vector2 axis = new Vector2(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal")) * walkSpeed;
        Vector3 forward = new Vector3(-Camera.main.transform.right.z, 0.0f, Camera.main.transform.right.x);
        Vector3 wishDirection = (forward * axis.x + Camera.main.transform.right * axis.y + Vector3.up * rb.velocity.y);
        rb.velocity = wishDirection;
    }
}
