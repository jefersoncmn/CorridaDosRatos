using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Dream", menuName = "Dream")]
public class DreamObject : ScriptableObject
{
    public string description;
    public double cost;
    public Sprite sprite;
}
