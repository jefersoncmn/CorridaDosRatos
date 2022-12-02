using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CreatePlayerController : MonoBehaviour
{
    
    public static Player CreatePlayer(){

    }

    private Finance GenerateFinance(){
        // return new Finance(Random.Range(100, 345), RandomJob(), )
    }

    private JobObject RandomJob(){
        JobObject[] jobs = LoadScriptableObjectsOnFileController.LoadJobs();
        return jobs[Random.Range(0, jobs.Length)];
    }

    private Expense[] GenerateExpenses(){

    }

    private Income[] GenerateIncomes(){

    }
}
