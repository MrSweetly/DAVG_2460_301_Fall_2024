using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private static readonly int IsRunning = Animator.StringToHash("IsRunning");
    private static readonly int IsJumping = Animator.StringToHash("IsJumping");
    private Animator animator;
    private CharacterController controller;
    
    public float speed;
    public float gravity;
    public float jump;

    private float yHold;
    private bool isJumping = false;
    
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Inputs
        var horizontalInput = Input.GetAxis("Horizontal");
        var verticalInput = Input.GetAxis("Vertical");
        
        var movement = new Vector3(horizontalInput, 0, verticalInput);

        // If moving, rotate the player
        if (movement.magnitude > 0.1f)
        {
            FaceMovementDirection(movement);
            animator.SetBool(IsRunning, true);
        }
        else
        {
            animator.SetBool(IsRunning, false);
        }
        
        // If grounded, reset vertical speed
        if (controller.isGrounded)
        {
            if (yHold < 0)
            {
                yHold = -1f; // Fall
            }

            // Jump
            if (Input.GetKeyDown(KeyCode.Space))
            {
                yHold = jump;
                isJumping = true;
            }
            else
            {
                isJumping = false;
            }
        }

        if (isJumping)
        {
            animator.SetBool(IsJumping, true);
        }
        else
        {
            animator.SetBool(IsJumping, false);
        }
        
        // Gravity
        yHold -= gravity * Time.deltaTime;
        
        movement.y = yHold;

        // Movement
        var moveSpeed = movement * (speed * Time.deltaTime);
        controller.Move(moveSpeed);
    }
    
    // Rotation
    private void FaceMovementDirection(Vector3 movement)
    {
        Vector3 flatMovement = new Vector3(movement.x, 0, movement.z);
        
        Quaternion targetRotation = Quaternion.LookRotation(flatMovement);
        
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
    }
}