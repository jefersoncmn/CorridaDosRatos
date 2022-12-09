using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event
{
    public string eventName;
    public string description;
    public Sprite sprite;
    public string answer;

    public Event(string eventName, string description, Sprite sprite, string answer)
    {
        this.eventName = eventName;
        this.description = description;
        this.sprite = sprite;
        this.answer = answer;
    }
}
