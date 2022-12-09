using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FinanceUIController : MonoBehaviour
{
    public Text cashText;
    public Text buttonFinancePanelCashText;
    public Text totalIncomeText;
    public Text totalExpensesText;
    public Text payDayText;
    public Text[] incomesText;
    public GameObject incomesScrollListContainer;
    public Text[] expensesText;
    public GameObject expensesScrollListContainer;
    public Text[] assetsText;
    public GameObject assetsScrollListContainer;
    public Text[] liabilitiesText;
    public GameObject liabilitiesScrollListContainer;
    public GameObject financePanel;
    public bool financePanelUIEnable = false;
    public GameObject itemListPrefab;

    public void SetUIValues(Player player){
        buttonFinancePanelCashText.text = player.finance.GetMoney().ToString("F2");
        cashText.text = player.finance.GetMoney().ToString("F2");
        totalExpensesText.text = player.finance.GetTotalExpenses().ToString("F2");
        totalIncomeText.text = player.finance.GetTotalIncome().ToString("F2");
        payDayText.text = player.finance.GetPayDay().ToString("F2");
    }

    public void SetItensInScrollLists(Player player){
        foreach (Asset item in player.finance.GetAssets())
        {
            SetItemInScrollList(item.description, item.value, assetsScrollListContainer);
        }
        foreach (Expense item in player.finance.GetExpenses())
        {
            if(item.isLiability == true){
                SetItemInScrollList(item.name, item.value * item.interest, expensesScrollListContainer);
                SetItemInScrollList(item.name, item.value, liabilitiesScrollListContainer);
            } else {
                SetItemInScrollList(item.name, item.value, expensesScrollListContainer);
            }
        }
        foreach (Income item in player.finance.GetIncomes())
        {
            SetItemInScrollList(item.description, item.value, incomesScrollListContainer);
        }
    }

    public void UpdateFinancePanel(Player player){
        CleanScrollList(assetsScrollListContainer.transform);
        CleanScrollList(expensesScrollListContainer.transform);
        CleanScrollList(liabilitiesScrollListContainer.transform);
        CleanScrollList(incomesScrollListContainer.transform);
        SetItensInScrollLists(player);
        SetUIValues(player);
    }
    
    private void SetItemInScrollList(string description, double _value, GameObject parent){
        Text text = itemListPrefab.transform.Find("Text").GetComponent<Text>() as Text;
        text.text = description;
        Text value = itemListPrefab.transform.Find("Value").GetComponent<Text>() as Text;
        value.text = _value.ToString("F2");
        GameObject newItem = Instantiate(itemListPrefab, new Vector3(0,0,0), Quaternion.identity) as GameObject;
        newItem.transform.SetParent(parent.transform, false);
    }

    private void CleanScrollList(Transform scrollList){
        foreach (Transform component in scrollList)
        {
            Destroy(component.gameObject);
        }
    }
    
    public void EnableFinancePanel(){
        financePanel.SetActive(true);
    }

    public void DisableFinancePanel(){
        financePanel.SetActive(false);
    }

    public void SetFinancePanelUIStatus(){
        financePanelUIEnable = !financePanelUIEnable;
    }
}
