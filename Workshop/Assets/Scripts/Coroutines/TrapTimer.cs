using System.Collections;
using UnityEngine;

public class TrapTimer : MonoBehaviour
{
    public Animator animator;
    public float downDelay = 3f;
    private static readonly int SpikeUp = Animator.StringToHash("Spike_Up");

    private void Start()
    {
        Debug.Log("Working");
    }
    // End of Start

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(ActivateSpikeTrap());
            Debug.Log("Trap");
        }
        // End of if
    }
    // End of OnTriggerEnter

    IEnumerator ActivateSpikeTrap()
    {
        animator.SetBool(SpikeUp, true);
        
        yield return new WaitForSeconds(downDelay);
        animator.SetBool(SpikeUp, false);
    }
    // End of ActivateSpikeTrap
}