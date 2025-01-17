﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;

[RequireComponent(typeof(CharacterController))]
public class FirstPersonController : NetworkBehaviour
{
    /// <summary>
    /// Move the player charactercontroller based on horizontal and vertical axis input
    /// </summary>

    public GameObject character;

    float yVelocity = 0f;

    [Range(5f,25f)]
    public float gravity = 15f;

    [Range(5f,50f)]
    public float movementSpeed = 10f;

    [Range(5f,15f)]
    public float jumpSpeed = 10f;

    public float sprintSpeedMultiplier = 2f;

    //now the camera so we can move it up and down
    Transform cameraTransform;
    float pitch = 0f;
    [Range(1f,90f)]
    public float maxPitch = 85f;
    [Range(-1f, -90f)]
    public float minPitch = -85f;
    [Range(0.5f, 5f)]
    public float mouseSensitivity = 2f;

    //the charachtercompononet for moving us
    CharacterController cc;

    private void Start()
    {
        cameraTransform = GetComponentInChildren<Camera>().transform;

        // sync player character rotation to camera rotation
        // character.transform.forward = cameraTransform.forward; 

        if (IsLocalPlayer)
        {
            cc = GetComponent<CharacterController>();
        }
        else
        {
            cameraTransform.gameObject.SetActive(false);
        }

        if (IsHost)
        {
            // player 1 should spawn in front of the labyrinth
            // y = 2, to ensure player doesnt fall through floor
            character.transform.position = new Vector3(-4, 2, 32);
        }
        else
        {
            // player 2 should spawn in front of the labyrinth
            character.transform.position = new Vector3(82, 2, 32);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (IsLocalPlayer)
        {
            Look();
            Move();
        }
    }

    void Look()
    {
        //get the mouse inpuit axis values
        float xInput = Input.GetAxis("Mouse X") * mouseSensitivity;
        float yInput = Input.GetAxis("Mouse Y") * mouseSensitivity;
        //turn the whole object based on the x input
        transform.Rotate(0, xInput, 0);
        //now add on y input to pitch, and clamp it
        pitch -= yInput;
        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);
        //create the local rotation value for the camera and set it
        //temporarily changed from Quaternion rot = Quaternion.Euler(pitch, 0, 0); to fix camera/player model rotation
        Quaternion rot = Quaternion.Euler(pitch, 0, 0);
        cameraTransform.localRotation = rot;
    }

    void Move()
    {
        float speed = movementSpeed;

        //update speed based on the input
        Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        input = Vector3.ClampMagnitude(input, 1f);

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            speed = movementSpeed * sprintSpeedMultiplier;
        }

        //transform it based off the player transform and scale it by movement speed
        Vector3 move = transform.TransformVector(input) * speed;
        //is it on the ground
        if (cc.isGrounded)
        {
            yVelocity = -gravity * Time.deltaTime;
            //check for jump here
            if (Input.GetKeyDown(KeyCode.Space))
            {
                yVelocity = jumpSpeed;
            }
        }
        //now add the gravity to the yvelocity
        yVelocity -= gravity * Time.deltaTime;
        move.y = yVelocity;
        //and finally move
        
        cc.Move(move * Time.deltaTime);
    }
}
