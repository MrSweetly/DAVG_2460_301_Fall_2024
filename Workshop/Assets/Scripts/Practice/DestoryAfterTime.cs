using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    public float destroyTime = 5f;  // Time after which the object will be destroyed

    private void Start()
    {
        // Start the destroy process when the object is initialized
        Destroy(gameObject, destroyTime);
    }
}