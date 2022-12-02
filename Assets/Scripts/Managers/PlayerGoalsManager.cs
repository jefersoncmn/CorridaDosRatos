using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGoalsManager : MonoBehaviour
{
    public string playerName;
    public Dream playerDream;
    void Awake(){

        //TODO pode ter só uma instancia dessa na cena

        DontDestroyOnLoad(this.gameObject);
    }   
}
