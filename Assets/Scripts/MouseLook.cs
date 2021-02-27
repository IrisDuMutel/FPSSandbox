using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    // Start is called before the first frame update

    public float mouseSensitivity = 100f;
    public Transform playerBody;
    float xRotation = 0f;

    void Start()
    {
        //Look the cursor at the middle of the script
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X")* mouseSensitivity*Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y")* mouseSensitivity*Time.deltaTime;
       

        xRotation -= mouseY;

        // Limit rotation to 180 deg so the player cant look behind their head
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        playerBody.Rotate(Vector3.up*mouseX);
    }
}
