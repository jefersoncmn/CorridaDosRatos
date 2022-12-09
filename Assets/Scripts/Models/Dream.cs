using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Dream : MonoBehaviour
{
    public string description;
    public double cost;
    public Sprite sprite;
    
    public Dream(string description, double cost, Sprite sprite){
        this.description = description;
        this.cost = cost;
        this.sprite = sprite;
    }
}
