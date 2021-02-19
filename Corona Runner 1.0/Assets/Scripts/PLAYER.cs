using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLAYER : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    public float forwardSpeed;
    public float maxSpeed;

    //3 lane ; 0:left ,1:middle, 2:right
    private int desiredLane = 1;

    //Distance between 2 lane
    public float laneDistance = 4;

    public bool isGrounded;
  // public LayerMask groundLayer;
    public Transform groundCheck;

    //for jump
    public float jumpForce;

    //for player garvity
    public float Gravity = -20;

    public Animator animator;


    void Start()
    {
        controller = GetComponent<CharacterController>();

    }


    void Update()
    {
        if (!PlayerManager.isGameStarted)
            return;
        //increasing the speed
        if(forwardSpeed<maxSpeed)
          forwardSpeed += 0.1f * Time.deltaTime;

        animator.SetBool("isGameStarted", true);
        direction.z = forwardSpeed;

        //for jump

       // isGrounded = Physics.CheckSphere(groundCheck.position, 0.15f, groundLayer);
        animator.SetBool("isGrounded", isGrounded);
        if (controller.isGrounded)
        {

            direction.y = -2;
            if (SwipeManager.swipeUp)
            {

                Jump();
            }

        }

        //Gather the input on which lane we should be

        if (SwipeManager.swipeRight)
        {
            desiredLane++;
            if (desiredLane == 3)
                desiredLane = 2;
        }

        if (SwipeManager.swipeLeft)
        {
            desiredLane--;
            if (desiredLane == -1)
                desiredLane = 0;
        }

        //calculate where we should be in future
        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
        if (desiredLane == 0)
        {
            targetPosition += Vector3.left * laneDistance;

        }
        else if (desiredLane == 2)
        {
            targetPosition += Vector3.right * laneDistance;
        }


        transform.position = Vector3.Lerp(transform.position, targetPosition, 70 * Time.deltaTime);


        direction.y += Gravity * Time.deltaTime;

       

       

        controller.center = controller.center;
    }



    private void FixedUpdate()
    {
        if (!PlayerManager.isGameStarted)
            return;
        controller.Move(direction * Time.fixedDeltaTime);
    }

    //for jumping
    private void Jump()
    {
        direction.y = jumpForce;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag == "Obstacles")
        {
            PlayerManager.gameOver = true;
            //FindObjectOfType<AudioManager>(). 
        }
    }

}

