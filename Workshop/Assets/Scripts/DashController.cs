using UnityEngine;

public class DashController : MonoBehaviour
{
    private CharacterController controller;

    public float dashSpeed = 20f;
    public float dashDuration = 0.2f;
    public float cooldownTime = 1f;

    private bool isDashing = false;
    private float dashTime;
    private float cooldownTimer = 0f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
        }

        if (Input.GetMouseButtonDown(1) && !isDashing && cooldownTimer <= 0)
        {
            StartDash();
        }

        if (isDashing)
        {
            Dash();
        }
    }

    private void StartDash()
    {
        isDashing = true;
        dashTime = dashDuration;
        cooldownTimer = cooldownTime;
    }

    private void Dash()
    {
        if (dashTime > 0)
        {
            Vector3 dashDirection = transform.forward * dashSpeed;
            controller.Move(dashDirection * Time.deltaTime);
            dashTime -= Time.deltaTime;
        }
        else
        {
            isDashing = false;
        }
    }

    // Public method to check if the player is dashing
    public bool IsDashing()
    {
        return isDashing;
    }
}