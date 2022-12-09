using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerActionsUIController : MonoBehaviour
{
    public Text playerActionsText;

    public void SetPlayerActionsText(string actionsAmount){
        playerActionsText.text = "Ações do jogador: "+actionsAmount;
    }
}
