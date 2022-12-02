using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe responsável por fazer a ligação entre as classes, usando Events (Pattern Observer) para comunicação entre classes com baixo acoplamento.
/// </summary>
public class EventManager : MonoBehaviour
{
    [SerializeField]
    TurnController turnController;
    [SerializeField]
    FinanceManager financeManager;

    [SerializeField]
    FinanceUIManager financeUIManager;

    void Start()
    {
        turnController = FindObjectOfType<TurnController>();
        financeManager = FindObjectOfType<FinanceManager>();
        financeUIManager = FindObjectOfType<FinanceUIManager>();

        turnController.OnTurnPass += financeManager.UpdateValues;

        financeManager.OnUpdateFinance += financeUIManager.UpdateUIValues;   
    }

    
}
