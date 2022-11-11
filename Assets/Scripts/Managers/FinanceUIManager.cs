using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinanceUIManager : MonoBehaviour
{
    public Text cash;
    public RectTransform m_RectTransform;
    public bool financePanelUIEnable = false;


    public void UpdateUIValues(Finance finance){
        cash.text = finance.GetMoney().ToString();
    }
    
    public void MoveFinancePanel(){
        if(financePanelUIEnable == false){
            LeanTween.moveY( m_RectTransform, 0f, 0.8f).setOnComplete(SetFinancePanelUIStatus);
        } else {
            LeanTween.moveY( m_RectTransform, 400f, 0.8f).setOnComplete(SetFinancePanelUIStatus);
        }
    }

    public void SetFinancePanelUIStatus(){
        financePanelUIEnable = !financePanelUIEnable;
    }
}
