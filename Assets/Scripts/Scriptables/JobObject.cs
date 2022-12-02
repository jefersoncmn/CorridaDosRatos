using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Job", menuName = "Job")]
public class JobObject : ScriptableObject
{
    public string jobName;
    public double wage;
}