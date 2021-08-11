using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // zmienne

    [Header("Ustawienia Gracza")]
    [Header("")]
    public float speed = 4f;
    public float jumpHeight = 4f;
    
    [Header("Inne Ustawienia")]
    [Header("")]
    public GameObject camera;

    public Vector3 velocity;
    public float gravity = 18f;

    public CharacterController controller;

    public GameObject groundCheck;
    public float groundDistance = 0.5f;
    public LayerMask ground;
    public bool isGrounded;
    
    void Start()
    {
        camera = GameObject.FindWithTag("Camera");
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.transform.position, groundDistance, ground);

        if (isGrounded || velocity.y > 0)
        {
            velocity.y = 0;
        }

        float z = Input.GetAxis("Vertical");
        float x = Input.GetAxis("Horizontal");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);
    }
}
