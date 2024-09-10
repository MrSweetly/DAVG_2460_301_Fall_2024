using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class DraggableBehavior : MonoBehaviour
{
    private Camera cameraObj;
    public bool draggable;
    public Vector3 position, offset;
    public UnityEvent startDragEvent, endDragEvent;

    private void Start()
    {
        cameraObj = Camera.main;
    }

    public IEnumerator OnMouseDown()
    {
        offset = transform.position - cameraObj.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cameraObj.WorldToScreenPoint(transform.position).z));
        yield return new WaitForFixedUpdate();
        draggable = true;
        startDragEvent.Invoke();
        while (draggable)
        {
            yield return new WaitForFixedUpdate();
            
            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, cameraObj.WorldToScreenPoint(transform.position).z);
            Vector3 worldPosition = cameraObj.ScreenToWorldPoint(mousePosition) + offset;
            
            position = new Vector3(worldPosition.x, transform.position.y, worldPosition.z);

            transform.position = position;
        }
    }

    private void OnMouseUp()
    {
        draggable = false;
        endDragEvent.Invoke();
    }
}
