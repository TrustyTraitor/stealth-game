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

    private ObjectSuspicion suspicion;

    Vector3 velocity;
    //bool isGrounded;
    bool isMoving;

    bool isCrouching = false;

    private RaycastHit groundCheckRay;

    private Vector3 lastPosition = new Vector3(0f, 0f, 0f);

    public float height;

    public Vector3 standingHeight = new Vector3(1f,1f,1f);
    public Vector3 crouchHeight = new Vector3(1f,0.5f,1f);

    public GameManager gameManager;

    public PlayerSkills skills;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        suspicion = GetComponent<ObjectSuspicion>();
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
        if (gameManager.IsInteractingWithUI == false)
        {
            if (Input.GetButtonDown("Crouch") && !isCrouching)
            {
                controller.height = 1.0f;
                groundCheck.position = new Vector3(groundCheck.position.x, groundCheck.position.y + 0.5f, groundCheck.position.z);
                isCrouching = true;

            }
            else if (Input.GetButtonDown("Crouch") && isCrouching)
            {
                controller.height = 2.0f;
                groundCheck.position = new Vector3(groundCheck.position.x, groundCheck.position.y - 0.5f, groundCheck.position.z);
                isCrouching = false;


            }

            if (isCrouching)
            {
                suspicion.Suspicion = suspicion.baseSuspicion;
            }
            else
            {
                suspicion.Suspicion = suspicion.standingSuspicion;
            }

            // stop y velocity
            if (isGrounded() && velocity.y < 0)
            {
                velocity.y = -2f;
            }

            if (Input.GetButton("Sprint"))
            {
                currentSpeed = (baseSpeed * ((skills.moveSpeedMod/100.0f)+1.0f)) * sprintMult;
            }
            else
            {
                currentSpeed = baseSpeed * ((skills.moveSpeedMod / 100.0f) + 1.0f);
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
            }
            else
            {
                isMoving = false;
            }

            lastPosition = gameObject.transform.position;
        }
    }
}
