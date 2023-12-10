using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 6f;
    public float gravity = -10f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    bool canSprint = true;


    //sprint duration
    public float sprintDuration;
    

    //Cooldown
    public float coolDown = 1;
    public float coolDownTimer;

    private void Start()
    {
        sprintDuration = 2;
    }
    void Update()
    {
        

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if ((isGrounded && velocity.y <0))
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.LeftShift) && canSprint == true || Input.GetKeyDown(KeyCode.LeftShift) && sprintDuration >0)
        {
            speed = 10f;

            coolDownTimer = coolDown;
            canSprint = false;
            
        }

        if (Input.GetKeyUp(KeyCode.LeftShift) || sprintDuration <= 0)
        {
            speed = 6f;

            
        }

        //cooldown
        if (coolDownTimer > 0)
        {
            coolDownTimer -= Time.deltaTime;
        }

        if (coolDownTimer < 0)
        {
            coolDownTimer = 0;
            canSprint = true;

            sprintDuration = 2;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            sprintCounter();

        }

        //sprintduration
        void sprintCounter()
        {
            sprintDuration -= Time.deltaTime;
        }
    }

    
}
