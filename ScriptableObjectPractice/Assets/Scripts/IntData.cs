using UnityEngine;

[CreateAssetMenu(menuName = "Classes/Create NPC data", fileName = "NPC", order = 0)]
public class IntData : ScriptableObject
{
    // NPC stats 
    [Range(0, 10)] public int strength;
    [Range(0, 10)] public int dexterity;
    [Range(0, 10)] public int intellegence;
}
