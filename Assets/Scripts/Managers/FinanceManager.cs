using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinanceManager : MonoBehaviour
{
    [SerializeField]
    Finance finance;

    [SerializeField] 
    public delegate void OnUpdateFinanceValues(Finance finance);
    [SerializeField] 
    public event OnUpdateFinanceValues OnUpdateFinance;

    private void Start() {
        finance = this.gameObject.AddComponent(typeof(Finance)) as Finance;
        finance.SetFinance(100,120,100);

    }

    public void UpdateValues(){
        finance.Payment();
        OnUpdateFinance?.Invoke(finance);
    }

}
