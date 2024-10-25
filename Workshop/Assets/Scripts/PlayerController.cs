using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    
    public float speed;
    public float gravity;
    public float jump;

    private float yHold;
    
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Inputs
        var horizontalInput = Input.GetAxis("Horizontal");
        var verticalInput = Input.GetAxis("Vertical");
        
        var movement = new Vector3(horizontalInput, 0, verticalInput);

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
            }
        }
        
        // Gravity
        yHold -= gravity * Time.deltaTime;
        
        movement.y = yHold;

        // Movement
        var moveSpeed = movement * (speed * Time.deltaTime);
        controller.Move(moveSpeed);
    }
}