using System.Collections;
using UnityEngine;

public class PlatformTimer : MonoBehaviour
{
    public Animator animator;         // Reference to the Animator component
    public float toggleInterval = 2f; // Interval in seconds between toggling the boolean
    private static readonly int PlatformRight = Animator.StringToHash("Platform_Right");

    private void Start()
    {
        // Ensure that the animator is assigned
        if (animator == null)
        {
            Debug.LogError("Animator not assigned.");
            return;
        }

        // Start the coroutine to toggle the boolean value
        StartCoroutine(MovePlatform());
    }

    private IEnumerator MovePlatform()
    {
        while (true)
        {
            // Set the boolean to true, causing the animation to play
            animator.SetBool(PlatformRight, true);

            // Wait for the current animation to complete before turning it off
            yield return new WaitForSeconds(toggleInterval);

            // Set the boolean to false after the animation is done
            animator.SetBool(PlatformRight, false);

            // Wait for the specified interval before starting the next cycle
            yield return new WaitForSeconds(toggleInterval);
        }
    }
}