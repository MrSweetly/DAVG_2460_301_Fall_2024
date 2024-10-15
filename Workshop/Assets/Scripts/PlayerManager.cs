using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;

    private void Awake() 
    {
        Instance = this; 
    }
    
    public GameObject player;
}

