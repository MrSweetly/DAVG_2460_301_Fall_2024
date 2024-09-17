using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class CorutineBehavior : MonoBehaviour
{
    public UnityEvent startEvent, startCountEvent, repeatCountEvent, endCountEvent, repeatUntilFalseEvent;
    
    public bool canRun;
    public IntData counterNum;
    public float seconds = 3.0f;

    private WaitForSeconds wfsObj;
    private WaitForFixedUpdate wffuObj;

    private void Start()
    {
        startEvent.Invoke();
    }

    public void startCounting()
    {
        StartCoroutine(Counting());
    }

     IEnumerator Counting()
    {
        wfsObj = new WaitForSeconds(seconds);
        wffuObj = new WaitForFixedUpdate();

        startCountEvent.Invoke();

        yield return wfsObj;
        
        while (counterNum.value > 0) {
            repeatCountEvent.Invoke();
            counterNum.value--;
            yield return wfsObj; }
        
        endCountEvent.Invoke();
    }

    public void StartUntilFalse()
    {
        canRun = true;
        StartCoroutine(RepeatUntilFalse());
    }

    IEnumerator RepeatUntilFalse()
    {
        while (canRun) {
            yield return wfsObj;
            repeatUntilFalseEvent.Invoke(); }
    }
}
