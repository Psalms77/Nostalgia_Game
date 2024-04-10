using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KToolkit;

public class BitMovement : Observer
{


    private void Awake()
    {
        
    }


    private void Start()
    {
        
    }


    private void Update()
    {
        PlayerInputs();
    }


    private void FixedUpdate()
    {
        
    }


    private void PlayerInputs()
    {
        if (Input.GetKeyUp(KeyCode.W))
        {
            this.transform.position += new Vector3(0, 1, 0);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            this.transform.position += new Vector3(0, -1, 0);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            this.transform.position += new Vector3(-1, 0, 0);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            this.transform.position += new Vector3(1, 0, 0);
        }
    }



}
