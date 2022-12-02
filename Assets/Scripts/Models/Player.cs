using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public string playerName;
    public Dream dream;
    public Finance finance;
    public int turns;

    public Player(string playerName, Dream dream, Finance finance, int turns)
    {
        this.playerName = playerName;
        this.dream = dream;
        this.finance = finance;
        this.turns = turns;
    }
}
