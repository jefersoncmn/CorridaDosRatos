using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finance
{
    [SerializeField]
    double money;
    [SerializeField]
    JobObject job;

    List<Expense> expenses = new List<Expense>(); //Lista de gastos
    List<Income> incomes = new List<Income>(); //Lista de ganhos (trabalho/Investimentos/Dividentos/Aluguel/Negócios/Renda Fixa)
    List<Asset> assets = new List<Asset>(); //Lista de ações

    public Finance(double money, JobObject job, List<Expense> expenses, List<Income> incomes, List<Asset> assets)
    {
        this.money = money;
        this.job = job;

        UpdateTotalIncome();
        UpdateTotalExpenses();
    }

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
        double calculatedTotalIncome = 0;
        foreach (var income in incomes)
        {
            calculatedTotalIncome += income.value;
        }
        return calculatedTotalIncome;
    }

    double GetTotalExpenses(){
        double calculatedTotalExpenses = 0;
        foreach (var expense in expenses)
        {
            calculatedTotalExpenses  += income.value;
        }
        return calculatedTotalExpenses ;
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

    
}
