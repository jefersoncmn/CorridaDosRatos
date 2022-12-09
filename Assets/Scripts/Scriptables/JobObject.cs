using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Job", menuName = "Scriptables/Job")]
public class JobObject : ScriptableObject
{
    public string jobName;
    public double wage;
}