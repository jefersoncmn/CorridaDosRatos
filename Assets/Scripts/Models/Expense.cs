using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Expense
{
    public double value;
    public double interest;
    public string name;
    public bool isLiability;
    public Expense(double value, double interest, string name, bool isLiability)
    {
        this.value = value;
        this.interest = interest;
        this.name = name;
        this.isLiability = isLiability;
    }
}
