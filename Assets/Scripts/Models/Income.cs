using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Income
{
    public double value;
    public string description;

    public Income(double value, string description)
    {
        this.value = value;
        this.description = description;
    }
}
