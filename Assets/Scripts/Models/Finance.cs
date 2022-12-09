using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
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
        this.expenses = expenses;
        this.incomes = incomes;
        this.incomes.Add(new Income(job.wage, job.jobName));
        this.assets = assets;
    }

    public double GetMoney(){
        return money;
    }

    public double GetTotalIncome(){
        double calculatedTotalIncome = 0;

        foreach (var income in incomes)
        {
            calculatedTotalIncome += income.value;
        }
        return calculatedTotalIncome;
    }

    public double GetTotalExpenses(){
        double calculatedTotalExpenses = 0;
        foreach (var expense in expenses)
        {
            calculatedTotalExpenses  += expense.value;
        }
        return calculatedTotalExpenses ;
    }

    public void SetMoney(double money){
        this.money = money;
    }

    public double GetPayDay(){
        return GetTotalIncome() - GetTotalExpenses();
    }

    public void AddExpense(Expense expense){
        this.expenses.Add(expense);
    }

    public void AddAsset(Asset asset){
        this.assets.Add(asset);
    }

    public void RemoveAsset(Asset asset){
        this.assets.Remove(asset);
    }

    public void RemoveExpense(Expense expense){
        this.expenses.Remove(expense);
    }

    public void AddIncome(Income income){
        this.incomes.Add(income);
    }

    public void RemoveIncome(Income income){
        this.incomes.Remove(income);
    }

    public List<Asset> GetAssets(){
        return assets;
    }
    public List<Expense> GetExpenses(){
        return expenses;
    }
    public List<Income> GetIncomes(){
        return incomes;
    }
    
}
