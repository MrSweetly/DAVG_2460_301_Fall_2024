using UnityEngine;
using UnityEngine.Events;

public class MatchBehavior : MonoBehaviour
{
    public ID idObj;
    public UnityEvent matchEvent, noMatchEvent, noMatchDelayedEvent;
    private void OnTriggerEnter(Collider other)
    {
        var tempObj = other.GetComponent<IDContainerBehavior>();
        if (tempObj == null) 
            return;
        
        var otherId = tempObj.idObj;
        if (otherId == idObj) {
            matchEvent.Invoke(); }
        else {
            noMatchEvent.Invoke();
            noMatchDelayedEvent.Invoke();
        }
    }
}
