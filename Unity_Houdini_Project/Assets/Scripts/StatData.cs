using UnityEngine;
using UnityEngine.Events;
// Ai made; reference only
[CreateAssetMenu]
public class StatData : ScriptableObject
{
    public float maxValue = 100f;
    public float currentValue;

    // Event to notify when the value changes
    public UnityEvent<float> onValueChanged;

    private void OnEnable()
    {
        ResetValue();
    }

    // Resets the stat to max value when enabled
    public void ResetValue()
    {
        currentValue = maxValue;
        TriggerValueChanged();
    }

    // Method to modify the value
    public void ModifyValue(float amount)
    {
        currentValue += amount;
        currentValue = Mathf.Clamp(currentValue, 0, maxValue);  // Ensure value stays between 0 and maxValue
        TriggerValueChanged();
    }

    // Invokes the event to notify listeners about the change
    private void TriggerValueChanged()
    {
        if (onValueChanged != null)
        {
            onValueChanged.Invoke(currentValue / maxValue);  // Send normalized value (between 0 and 1)
        }
    }
}
