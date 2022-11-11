using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TurnController : MonoBehaviour
{
    [SerializeField]
    int turn = 0;

    [SerializeField] 
    public delegate void OnTurnPassHandler();
    [SerializeField] 
    public event OnTurnPassHandler OnTurnPass;
    
    public void PassTurn(){
        turn++;
        OnTurnPass?.Invoke();
    }
    //Mudar valores das ações (fazer um observer para outras classes verem isso e mudarem as coisas com base na mudança do turno)

    //Gerar o evento

    
}
