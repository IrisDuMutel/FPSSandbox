using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.81f;
    Vector3 velocity;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    bool isGrounded;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Press to create cube
        bool c = Input.GetKeyDown(KeyCode.C);

        // Press to create
        if (c == true)
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.position = groundCheck.transform.position;
        }
        
            // CReates a shpere based on the groundcheck.position,groundDistance as radius
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        // True if collision happens

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; 
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move*speed*Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity*Time.deltaTime);
    }
}
