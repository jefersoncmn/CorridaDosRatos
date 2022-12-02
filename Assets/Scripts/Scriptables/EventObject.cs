using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Event", menuName = "Event")]
public class EventObject : ScriptableObject
{
    public string eventName;
    public string description;
    public Sprite sprite;
}
