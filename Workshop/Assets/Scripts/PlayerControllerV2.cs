using UnityEngine;

public class PlayerControllerV2 : MonoBehaviour
{
    private CharacterController controller;

    [SerializeField] private CharacterConfig characterConfig;

    private float yHold;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        if (characterConfig == null)
        {
            Debug.LogError("CharacterConfig is missing. Please assign it in the inspector.");
        }
    }

    void Update()
    {
        if (!characterConfig) return;  // Stop if no config is assigned

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
                yHold = characterConfig.jump;
            }
        }

        // Gravity
        yHold -= characterConfig.gravity * Time.deltaTime;

        movement.y = yHold;

        // Movement
        var moveSpeed = movement * (characterConfig.speed * Time.deltaTime);
        controller.Move(moveSpeed);
    }
}