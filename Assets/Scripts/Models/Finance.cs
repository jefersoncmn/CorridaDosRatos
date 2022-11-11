using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finance : MonoBehaviour
{
    [SerializeField]
    double money;
    [SerializeField]
    double totalIncome;
    [SerializeField]
    double totalExpenses;
    [SerializeField]
    double payDay;
    [SerializeField]
    string jobName;

    List<Expense> expenses = new List<Expense>(); //Lista de gastos
    List<Income> incomes = new List<Income>(); //Lista de ganhos (trabalho/Investimentos/Dividentos/Aluguel/Negócios/Renda Fixa)
    List<Asset> Assets = new List<Asset>(); //Lista de ações

    public void SetFinance(double money, double totalIncome, double totalExpenses){
        this.money = money;
        this.totalIncome = totalIncome;
        this.totalExpenses = totalExpenses;
        UpdatePayDay();
    }

    public double GetMoney(){
        return money;
    }

    double GetTotalIncome(){
        return totalIncome;
    }

    double GetTotalExpenses(){
        return totalExpenses;
    }

    void SetMoney(double money){
        this.money = money;
    }

    public void UpdatePayDay(){
        this.payDay = this.totalIncome - this.totalExpenses;
    }

    void AddExpense(Expense expense){
        expenses.Add(expense);
        UpdateTotalExpenses();
    }

    void RemoveExpense(Expense expense){
        expenses.Remove(expense);
        UpdateTotalExpenses();
    }

    void AddIncome(Income income){
        incomes.Add(income);
        UpdateTotalIncome();
    }

    void RemoveIncome(Income income){
        incomes.Remove(income);
        UpdateTotalIncome();
    }
    
    void UpdateTotalIncome(){
        double calculatedIncome = 0;
        foreach (var income in incomes)
        {
            calculatedIncome += income.value;
        }
        this.totalIncome =  calculatedIncome;
    }

    void UpdateTotalExpenses(){
        double calculatedExpenses = 0;
        foreach (var expense in expenses)
        {
            calculatedExpenses += expense.value;
        }
        this.totalExpenses =  calculatedExpenses;
    }

    public void Payment(){
        SetMoney(GetMoney()+this.payDay);
    }

    void GenerateLife(){
        //Random Work
        //Random expenses
    }
}
