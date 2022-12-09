using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe responsável por fazer a ligação entre as classes, usando Events (Pattern Observer) para comunicação entre classes com baixo acoplamento.
/// </summary>
public class EventManager : MonoBehaviour
{
    public EventController eventController;
    public EventUIController eventUIController;

    [SerializeField]
    TurnController turnController;


    void Start()
    {
        turnController.OnTurnPass += GetEvent;
    }

    //Todas funções abaixo, fazer seus observers para o PlayerManager escutar e alterar as coisas

    private void GetEvent(){
        Event _event = eventController.GetRandomEvent();
        eventUIController.ShowEvent(_event);
    }

    private void PlayerLoseActions(){
        //TODO o usuário poderá perder ações
    }

    private void PlayerGainMoney(){
        //TODO o usuário poderá ganhar dinheiro
    }

    private void PlayerLoseMoney(){

    }
    private void PlayerGainNewLiability(){

    }

    private void PlayerGainNewAsset(){
        
    }

    
}
