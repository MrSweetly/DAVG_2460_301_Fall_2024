using System.Collections;
using UnityEngine;

public class PlatformTimer : MonoBehaviour
{
    public Animator animator;         
    public float toggleDelay = 2f;
    private static readonly int PlatformRight = Animator.StringToHash("Platform_Right");

    private void Start()
    {
        if (animator == null)
        {
            Debug.LogError("Animator not assigned.");
            return;
        }
        // End of if

        StartCoroutine(MovePlatform());
    }
    // End of Start

    private IEnumerator MovePlatform()
    {
        while (true)
        {
            animator.SetBool(PlatformRight, true);

            yield return new WaitForSeconds(toggleDelay);

            animator.SetBool(PlatformRight, false);

            yield return new WaitForSeconds(toggleDelay);
        }
        // End of while
    }
    // End of MovePlatform
}