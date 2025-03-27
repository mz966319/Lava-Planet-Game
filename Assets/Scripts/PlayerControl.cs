using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    [SerializeField] GameObject player;


    [SerializeField] float movementSpeed = 6f;
    [SerializeField] float jumbForce = 10f;
    [SerializeField] float gravityScale = 1f;
    public CharacterController characterController;
    private Vector3 moveDirection;

    private string animationStatus = "idle";

    public float knockBackForce;
    public float knockBackTime;
    [SerializeField] private float knockBackCounter;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {

        if (knockBackCounter <= 0)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            float yCopy = moveDirection.y; //copy of y 
            moveDirection = (transform.right * horizontalInput) + (transform.forward * verticalInput); //move left right up and down
            moveDirection = moveDirection.normalized * movementSpeed; //walk same speed when up/down inputted with left/right
            moveDirection.y = yCopy;
            if (characterController.isGrounded) //check if the player is on the ground
            {
                moveDirection.y = 0f;
                if (Input.GetKey("space")) //jump once when space button inputted

                {
                    moveDirection.y = jumbForce;
                }
            }
        }
        else {
            knockBackCounter -= Time.deltaTime;
        }
        moveDirection.y += Physics.gravity.y * gravityScale * Time.deltaTime; //add gravity value and frame speed

        characterController.Move(moveDirection * Time.deltaTime); //move player based on input

    }


    private void FixedUpdate()
    {

        //change player animation based on key clicked and change status
        if (Input.GetKey("space") && !animationStatus.Equals("jump"))//jump animation
        {
            player.GetComponent<Animation>().Play("jump");
            animationStatus = "jump";
        }
        else if ((Input.GetKey("up") || Input.GetKey("down")) && Input.GetKey("space") && !animationStatus.Equals("jump"))//walk and jump animation
        {
            player.GetComponent<Animation>().Play("jump");
            animationStatus = "jump";

        }
        else if ( (Input.GetKey("up") || Input.GetKey("down")) && !animationStatus.Equals("walk") && characterController.isGrounded)//walk animation
        {
            player.GetComponent<Animation>().Play("walk");

        }

        else if(!Input.GetKey("space") && (!Input.GetKey("up") && !Input.GetKey("down")) && characterController.isGrounded) //idle animation
        {
            player.GetComponent<Animation>().Play("idle");
            animationStatus = "idle";

        }
    }

}

