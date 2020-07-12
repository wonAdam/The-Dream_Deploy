using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "New Event", fileName = "Event", order = 1)]
public class EventObject : ScriptableObject
{
    public List<EventListener> listeners =  new List<EventListener>();

    public void Register(EventListener elistener)
    {
        listeners.Add(elistener);
    }

    public void UnRegister(EventListener elistener)
    {
        listeners.Remove(elistener);
    }

    public void OnOccure()
    {
        foreach(EventListener e in listeners)
        {
            e.InvokeResponses();
        }
    }
}
