using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinanceController
{
    public void Payment(Finance finance){
        finance.SetMoney(finance.GetMoney()+ finance.GetPayDay());
    }

    //TODO pegar divida
    public void RepayDebt(Finance finance, Expense expense){
        if(finance.GetMoney() >= expense.value){
            finance.SetMoney(finance.GetMoney() - expense.value);
            finance.RemoveExpense(expense);
        } else {
            //TODO return error
        }
    }

    //TODO pagar divida
    public void Borrow(Finance finance, double value){
        if(finance.GetMoney() > -100000){
            finance.SetMoney(finance.GetMoney() + value);
            finance.AddExpense(new Expense(value, 0.4, "Empréstimo do Banco", true));
        } else {
            //TODO return error
        }
    }

    public void BuyStock(Finance finance, Asset asset){
        if(finance.GetMoney() > asset.value){
            finance.SetMoney(finance.GetMoney() - asset.value);
            finance.AddAsset(asset);
        } else {
            //TODO return error
        }
    }

    public void SellStock(Finance finance, Asset asset){
        finance.RemoveAsset(asset);
        finance.SetMoney(finance.GetMoney() + asset.value);
    }

}
