using System.Collections;
using UnityEngine;

public class TrapTimer : MonoBehaviour
{
    public Animator animator; // Assign the Animator component in the Inspector
    public float downDelay = 3f; // Delay in seconds before playing Spike_Down_Animation
    private static readonly int SpikeUp = Animator.StringToHash("Spike_Up");

    private void Start()
    {
        Debug.Log("Working");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Ensure only the player triggers the trap
        {
            StartCoroutine(ActivateSpikeTrap());
            Debug.Log("Trap");
        }
    }

    IEnumerator ActivateSpikeTrap()
    {
        // Play the Spike_Up_Animation
        animator.SetBool(SpikeUp, true);
        
        // Wait for the specified delay
        yield return new WaitForSeconds(downDelay);
        // Play the Spike_Down_Animation
        animator.SetBool(SpikeUp, false);
    }
}