using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CreatePlayerController : MonoBehaviour
{
    public static Player CreatePlayer(string playerName, Dream dream, int turns){
        return new Player(playerName, dream, GenerateFinance(), turns);
    }

    private static Finance GenerateFinance(){
        //Random.Range(100, 345)
        return new Finance(10000, RandomJob(), GenerateExpenses(3), new List<Income>(), new List<Asset>());
    }

    private static JobObject RandomJob(){
        JobObject[] jobs = LoadScriptableObjectsOnFileController.LoadJobs();
        return jobs[Random.Range(0, jobs.Length)];
    }

    private static List<Expense> GenerateExpenses(int amount){
        ExpenseObject[] expenses = LoadScriptableObjectsOnFileController.LoadExpenses();
        List<Expense> selectedExpenses = new List<Expense>(); 

        for (int i = 0; i < amount; i++)
        {
            selectedExpenses.Add(new Expense(expenses[i].value, expenses[i].interest, expenses[i].expenseName, expenses[i].isLiability));
        }
        //Random.Range(0, expenses.Length)
        return selectedExpenses;
    }

    private static Income[] GenerateIncomes(){
        //TODO code GenerateIncomes
        return new Income[0];
    }
}
