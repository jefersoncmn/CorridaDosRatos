using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Asset
{
    public string description;
    public double value;
    public double interest;
    public int amount;
    public bool isIncome;

    public Asset(string description, double value, double interest)
    {
        this.description = description;
        this.value = value;
        this.interest = interest;
    }
    //Diferenciar se ele vai ser por ação inteiro (imóvel) ou por pedaços (açoes)
}
