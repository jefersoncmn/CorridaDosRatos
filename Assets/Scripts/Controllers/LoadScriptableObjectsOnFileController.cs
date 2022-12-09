using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Essa classe é responsável pelos scriptableObjects que contém dados do jogo.
/// </summary>
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
    static public ExpenseObject[] LoadExpenses(){
        ExpenseObject[] expenses = Resources.LoadAll<ExpenseObject>("ScriptableObjects/Expenses");
        return expenses;
    }
    static public IncomeObject[] LoadIncomes(){
        IncomeObject[] incomes = Resources.LoadAll<IncomeObject>("ScriptableObjects/Incomes");
        return incomes;
    }
}
