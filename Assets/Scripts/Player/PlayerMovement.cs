using KToolkit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Observer
{
    [Header("Movement")]
    public float moveSpeed;
    public float groundDrag;
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump;
    public bool isJumping;

    [HideInInspector] public float walkSpeed;
    [HideInInspector] public float sprintSpeed;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode attackKey = KeyCode.Mouse0;

    [Header("Ground Check")]
    public float playerHeight;
    public bool grounded;
    public LayerMask whatIsGround;



    [Header("References")]
    public Transform orientation;
    public Animator animator;
    float horizontalInput;
    float verticalInput;

    public Vector3 moveDirection;
    public Vector3 velocity;
    public float currentSpeed;
    Rigidbody rb;



    private void Awake()
    {

        //Debug.Log(transform.GetChild(0).name);
        //animator = transform.GetChild(0).GetComponent<Animator>();
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        readyToJump = true;
        isJumping = false;
    }

    private void Update()
    {
        currentSpeed = new Vector3(rb.velocity.x, 0f, rb.velocity.z).magnitude;
        velocity = rb.velocity;
        PlayerMovementInput();
        JumpInput();
        GroundCheck();
        SpeedControl();
        GroundDrag();
        AnimationControl();
    }

    private void FixedUpdate()
    {

        MovePlayer();
    }


    public void GroundCheck()
    {
        // ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.3f, whatIsGround);
    }

    public void GroundDrag()
    {
        // handle drag
        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;
    }


    public void PlayerMovementInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    public void JumpInput()
    {
        
        // when to jump
        if (Input.GetKey(jumpKey) && readyToJump && grounded && !isJumping)
        {
            readyToJump = false;
            isJumping = true;
            Jump();
            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }


    public void MovePlayer()
    {
        // calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        // on ground
        if (grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

        // in air
        else if (!grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
    }

    public void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        // limit velocity if needed
        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    public void AnimationControl()
    {
        animator.SetFloat("Speed", currentSpeed);

    }


    public void Jump()
    {
        // reset y velocity
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    public void ResetJump()
    {
        readyToJump = true;
        isJumping = false;
    }
}
