using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public StatData healthData;  // Reference to the health ScriptableObject

    private void Start()
    {
        healthData.ResetValue();  // Initialize health
    }

    public void TakeDamage(float amount)
    {
        healthData.ModifyValue(-amount);  // Decrease health
    }

    public void Heal(float amount)
    {
        healthData.ModifyValue(amount);  // Increase health
    }
}