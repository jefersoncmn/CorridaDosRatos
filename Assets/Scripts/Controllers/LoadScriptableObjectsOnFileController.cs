using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LoadScriptableObjectsOnFileController : MonoBehaviour
{
    static public DreamObject[] LoadDreams(){
        DreamObject[] dreams = Resources.LoadAll<DreamObject>("ScriptableObjects/Dreams");
        return dreams;
    }
    static public EventObject[] LoadEvents(){
        EventObject[] events = Resources.LoadAll<EventObject>("ScriptableObjects/Events");
        return events;
    }
    static public JobObject[] LoadJobs(){
        JobObject[] jobs = Resources.LoadAll<JobObject>("ScriptableObjects/Jobs");
        return jobs;
    }
    static public PropertyObject[] LoadProperties(){
        PropertyObject[] properties = Resources.LoadAll<PropertyObject>("ScriptableObjects/Properties");
        return properties;
    }
}
