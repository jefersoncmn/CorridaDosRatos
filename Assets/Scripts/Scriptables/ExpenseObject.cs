using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Expense", menuName = "Scriptables/Expense")]
public class ExpenseObject : ScriptableObject
{
    public string expenseName;
    public double value;
    public double interest;
    public string description;
    public bool isLiability;

}
