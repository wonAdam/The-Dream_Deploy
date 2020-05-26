using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventListener : MonoBehaviour
{
    public EventObject gEvent;
    public UnityEvent response; 

    private void OnEnable() {
        if(gEvent != null)
            gEvent.Register(this);
    }

    private void OnDisable() {
        if(gEvent != null)
            gEvent.UnRegister(this);
    }

    public void InvokeResponses()
    {
        response.Invoke();
    }
}
