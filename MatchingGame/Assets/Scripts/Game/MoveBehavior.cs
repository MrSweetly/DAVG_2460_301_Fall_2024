using UnityEngine;

public class MoveBehavior : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        transform.Translate(0, 0, -speed * Time.deltaTime);
    }
}
