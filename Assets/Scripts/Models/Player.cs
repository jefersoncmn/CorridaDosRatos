using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player
{
    public string playerName;
    public Dream dream;
    public Finance finance;
    public int maxActions;

    public Player(string playerName, Dream dream, Finance finance, int maxActions)
    {
        this.playerName = playerName;
        this.dream = dream;
        this.finance = finance;
        this.maxActions = maxActions;
    }
}
