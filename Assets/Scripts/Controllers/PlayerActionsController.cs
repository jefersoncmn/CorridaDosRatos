using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActionsController
{
    public void UseAction(PlayerManager playerManager){
        playerManager.actions--;
    }
    
    public void RestartActions(PlayerManager playerManager, Player player){
        playerManager.actions = player.maxActions;
    }
}
