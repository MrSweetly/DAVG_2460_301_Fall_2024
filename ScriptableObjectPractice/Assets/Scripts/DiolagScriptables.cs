using UnityEngine;

[CreateAssetMenu]
public class DiolagScriptables : ScriptableObject
{
    public DiolagActors[] actors;

    [Tooltip("Only if Actor is random")] 
    [Header("Random Actor Info")]
    public string randomActorName;
    public Sprite randomActorSprite;

    [Header("Diolag")] 
    [TextArea]
    public string[] dialog;

    [Tooltip("Words that will be on option buttons")]
    public string[] optionText;

    public DiolagScriptables option0;
    public DiolagScriptables option1;
    public DiolagScriptables option2;
    public DiolagScriptables option3;

}
