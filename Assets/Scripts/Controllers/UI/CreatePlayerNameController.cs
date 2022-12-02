using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreatePlayerNameController : MonoBehaviour
{
    public string playerName;

    public void SubmitName(string playerName){
        this.playerName = playerName;
    }
}
