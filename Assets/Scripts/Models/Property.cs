using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Property : MonoBehaviour
{
    PropertyTypes propertyType;
    GameObject propertyPrefab;
    Stock stock;
    int sizeX;
    int SizeY;

    //Receberá uma matriz encadeada para informar o "formato" que ocupa no mapa
    //Nessa matriz encadeada ele terá celulas ocupadas pelo estabelecimento
    //Celulas adicionais (para aprimoramentos)
    //Celulas de saida e entrada pela estrada

    //Ao usuário clicar, será percorrido essa matrix da construção e verificado se no mapa os lugares podem ser ocupados.
    //Se puder, todas as informações da matriz da construção serão coladas no mapa
}
