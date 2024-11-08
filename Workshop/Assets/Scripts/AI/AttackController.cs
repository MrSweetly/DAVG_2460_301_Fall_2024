using UnityEngine;
using System.Collections.Generic;

public class AttackController : MonoBehaviour
{
    public float attackCooldown = 1.5f; // Time between attacks
    public List<TagFillChange> tagFillChanges; // List of tag-damage values

    private float lastAttackTime = 0f;

    private void OnTriggerEnter(Collider other)
    {
        if (Time.time >= lastAttackTime + attackCooldown)
        {
            lastAttackTime = Time.time; // Reset the attack cooldown

            // Check each tag in tagFillChange list, then send tag data to player's fillAmount if matched
            foreach (var tagFillChange in tagFillChanges)
            {
                if (other.CompareTag(tagFillChange.tag))
                {
                    ImageFillBehavior playerFillBehavior = other.GetComponent<ImageFillBehavior>();
                    break;
                }
            }
        }
    }

    // Define TagFillChange class for this script as well
    [System.Serializable]
    public class TagFillChange
    {
        public string tag;
    }
}