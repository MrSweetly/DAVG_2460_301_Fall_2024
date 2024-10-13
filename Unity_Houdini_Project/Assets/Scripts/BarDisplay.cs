using UnityEngine;
using UnityEngine.UI;
// Ai made; reference only
public class BarDisplay : MonoBehaviour
{
    public Image barFillImage;  // The image that shows the fill
    
    public StatData statData;  // Reference to the ScriptableObject

    private void OnEnable()
    {
        // Subscribe to the ScriptableObject's onValueChanged event
        statData.onValueChanged.AddListener(UpdateBar);
        
        // Initialize the bar at the current value
        UpdateBar(statData.currentValue / statData.maxValue);
    }

    private void OnDisable()
    {
        // Unsubscribe from the event when disabled to prevent memory leaks
        statData.onValueChanged.RemoveListener(UpdateBar);
    }

    // This method updates the bar fill amount based on the value from StatData
    private void UpdateBar(float normalizedValue)
    {
        if (barFillImage != null)
        {
            barFillImage.fillAmount = normalizedValue;  // Update the UI Image fill
        }
    }
}
