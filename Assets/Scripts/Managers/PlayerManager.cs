using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Player player;
    public FinanceController financeController;
    public FinanceUIController financeUIController;
    public TurnController turnController;
    public EventManager eventManager;
    public PlayerActionsController playerActionsController;
    public PlayerActionsUIController playerActionsUIController;
    public int actions;
    //Geral centralizado aqui
    private void Awake() {
        turnController.OnTurnPass+= turnPass; 
    }
    private void Start() {
        CreatePlayer();
    }
    public void CreatePlayer(){
        DreamObject[] dreamObjects = LoadScriptableObjectsOnFileController.LoadDreams();
        player = CreatePlayerController.CreatePlayer("Teste", new Dream(dreamObjects[0].description, dreamObjects[0].cost, dreamObjects[0].sprite), 3);
        financeController = new FinanceController();
        playerActionsController = new PlayerActionsController();

        //FinanceUI
        financeUIController.SetItensInScrollLists(this.player);
        financeUIController.SetUIValues(this.player);

        //Actions
        playerActionsController.RestartActions(this, player);
        this.actions = player.maxActions;
        playerActionsUIController.SetPlayerActionsText(actions.ToString());
    }

    private void turnPass(){
        financeController.Payment(player.finance);
        playerActionsController.RestartActions(this, player);
        financeUIController.SetUIValues(player);
    }

    public void UpdateFinancePanel(){
        financeUIController.UpdateFinancePanel(player);
    }
    
}