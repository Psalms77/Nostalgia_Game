using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KToolkit;

public class TopdownPlayerMovements : Observer
{
    //camera
    public Camera cam;


    // movement
    public float moveSpeed;
    Vector2 movement;
    Rigidbody2D _rb2d;


    // mouse pointing
    Vector2 mousePos;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        cam = Camera.main;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

    }
    private void FixedUpdate()
    {
        _rb2d.MovePosition(_rb2d.position + movement * moveSpeed * Time.fixedDeltaTime);
        Vector2 pointingDir = mousePos - _rb2d.position;
        float angle = Mathf.Atan2(pointingDir.y, pointingDir.x) * Mathf.Rad2Deg - 90f; // gun pointing downwards by default
        //waterGunOnHand.transform.rotation = Quaternion.Euler(0, 0, angle);
        //Debug.DrawRay(_rb2d.position, pointingDir);
    }

}
