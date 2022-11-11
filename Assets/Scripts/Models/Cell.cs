using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe da célula que irá compor o mapa
/// </summary>
public class Cell : MonoBehaviour
{
    public GameObject cellObject;
    public Cell left, right, up, down;
    public AmbientType ambientType;
    public bool isOccupied;
    public Property property;
    public List<Cell> pathmemory = new List<Cell>();

    public Cell()
    {
        left = null;
        right = null;
        up = null;
        down = null;

        ambientType = AmbientType.Plano;
    }
}