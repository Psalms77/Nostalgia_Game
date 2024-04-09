using KToolkit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCam : Observer
{
    [Header("ref")]
    public Transform orientation;
    public Transform player;
    public Transform playermodel;
    public Rigidbody rb;

    public float rotationSpeed;



    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        // 旋转方向 
        Vector3 viewDir = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        orientation.forward = viewDir.normalized;


        // 旋转模型
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 inputDir = orientation.forward * verticalInput + orientation.right * horizontalInput;
        if (inputDir != Vector3.zero)
        {
            playermodel.forward = Vector3.Slerp(playermodel.forward, inputDir.normalized, Time.deltaTime * rotationSpeed);
        }

    }
}
