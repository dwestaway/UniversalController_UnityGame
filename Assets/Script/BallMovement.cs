﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class BallMovement : MonoBehaviour
{

    public float movementSpeed;
    private Rigidbody rb;
    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {   
        float moveHorizontal = Input.GetAxis("Horizontal");
       
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 1.0f, moveVertical);
        rb.AddForce(movement * movementSpeed);



        /*
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.position += transform.forward * Time.deltaTime * movementSpeed;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            transform.position -= transform.forward * Time.deltaTime * movementSpeed;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position += Vector3.left * Time.deltaTime * movementSpeed;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position += Vector3.right * Time.deltaTime * movementSpeed;
        }

        */
    }
}