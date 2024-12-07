using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class ImageFillDepleteEffect : MonoBehaviour
{
    public ImageFillBehavior imageFillBehavior; // Reference to the ImageFillBehavior script
    public UnityEvent onFillAmountZero;        // Event triggered when fillAmount reaches 0
    public float resetDelay = 3f;              // Delay in seconds before resetting fillAmount

    private bool actionTriggered = false;     // Ensure action triggers only once

    private void Update()
    {
        if (imageFillBehavior && !actionTriggered && imageFillBehavior.fillAmount <= 0f)
        {
            actionTriggered = true;          // Mark the action as triggered
            onFillAmountZero?.Invoke();
            StartCoroutine(ResetFillAmountAfterDelay()); // Reset fillAmount after a delay
        }
        else if (imageFillBehavior && imageFillBehavior.fillAmount > 0f)
        {
            actionTriggered = false;         // Reset trigger when fillAmount is replenished
        }
    }

    private IEnumerator ResetFillAmountAfterDelay()
    {
        yield return new WaitForSeconds(resetDelay); // Wait for the specified delay
        if (imageFillBehavior)
        {
            imageFillBehavior.fillAmount = 1f; // Reset fillAmount
        }
    }
}



