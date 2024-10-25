using UnityEngine;

[CreateAssetMenu(menuName = "Character/Character Config")]
public class CharacterConfig : ScriptableObject
{
    public float speed = 5f;
    public float gravity = 9.8f;
    public float jump = 10f;
}
