using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;

    public float baseSpeed = 12f;
    public float gravity = 9.81f * 2f;
    public float jumpHeight = 3f;
    public float sprintMult = 1.75f;

    private float currentSpeed = 0;

    public Transform groundCheck;
    public float groundDistance = 0.5f;
    public LayerMask groundLayer;

    public GameObject gunSlot;

    Vector3 velocity;
    //bool isGrounded;
    bool isMoving;

    bool isCrouching = false;

    private RaycastHit groundCheckRay;

    private Vector3 lastPosition = new Vector3(0f, 0f, 0f);

    public float height;

    public Vector3 standingHeight = new Vector3(1f,1f,1f);
    public Vector3 crouchHeight = new Vector3(1f,0.5f,1f);

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private bool isGrounded() 
    {
        if (Physics.Raycast(groundCheck.position, Vector3.down, out groundCheckRay, groundDistance, groundLayer))
        {
            //if (groundCheckRay.collider.CompareTag("Ground")) 
            return true;
        }
        return false;
    }

    void Update()
    {
        if (Input.GetButtonDown("Crouch") && !isCrouching)
        {
            transform.localScale = crouchHeight;
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z);
            isCrouching = true;

            //gunSlot.transform.localScale = new Vector3(0.07f, 0.07f,0.07f);
        }
        else if (Input.GetButtonDown("Crouch") && isCrouching)
        {
            transform.localScale = standingHeight;
            isCrouching = false;
            //gunSlot.transform.localScale = new Vector3(0.07f, 0.07f, 0.07f);

        }

        // stop y velocity
        if (isGrounded() && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (Input.GetButton("Sprint")) 
        { 
            currentSpeed = baseSpeed * sprintMult; 
        }
        else 
        { 
            currentSpeed = baseSpeed; 
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * currentSpeed * Time.deltaTime);


        if (Input.GetButtonDown("Jump") && isGrounded()) 
        {
            velocity.y = Mathf.Sqrt(jumpHeight * 2f * gravity);
        }

        velocity.y -= gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if (lastPosition != gameObject.transform.position && isGrounded()) 
        {
            isMoving = true;
        } else
        {
            isMoving = false;
        }

        lastPosition = gameObject.transform.position;
    }
}
