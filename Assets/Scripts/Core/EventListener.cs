using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventListener : MonoBehaviour
{
    public EventObject gEvent;
    public UnityEvent response; 

    private void OnEnable() {
        gEvent.Register(this);
    }

    private void OnDisable() {
        gEvent.UnRegister(this);
    }

    public void InvokeResponses()
    {
        response.Invoke();
    }
}
