using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventController : MonoBehaviour
{
    [SerializeField]
    EventObject[] events;
    
    private void Awake() {
        events = LoadScriptableObjectsOnFileController.LoadEvents();
    }

    public Event GetRandomEvent(){
        EventObject selectedEvent = events[Random.Range(0, events.Length)];
        Event selected = null;
        for (int i = 0; i < events.Length; i++)
        {
            if(Random.Range(0.000f, 1.000f) < events[i].chance){
                selected = new Event(selectedEvent.eventName, selectedEvent.description, selectedEvent.sprite, selectedEvent.answer);
            }
        }
        if(selected == null){
            return GetNormalEvent();
        }
        return selected;
    }

    public Event GetNormalEvent(){
        Event selected = null;
        foreach (var _event in events)
        {
            if(_event.eventName == "Sem problemas"){
                selected = new Event(_event.eventName, _event.description, _event.sprite, _event.answer);
            }
        }
        return selected;

    }

}
