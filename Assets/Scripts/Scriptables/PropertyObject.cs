using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Property", menuName = "Scriptables/Property")]
public class PropertyObject : ScriptableObject
{
    public string propertyName;
    public double description;
}

