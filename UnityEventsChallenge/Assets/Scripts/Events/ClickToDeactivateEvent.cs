using UnityEngine;
using UnityEngine.Events;

public class ClickToDeactivateEvent : MonoBehaviour
{
    public UnityEvent onClick;

    private void Start()
    {
        if (onClick == null)
            onClick = new UnityEvent();

        onClick.AddListener(DeactivateObject);
    }

    private void OnMouseDown()
    {
        onClick.Invoke();
    }
    
    private void DeactivateObject()
    {
        gameObject.SetActive(false);
    }
}