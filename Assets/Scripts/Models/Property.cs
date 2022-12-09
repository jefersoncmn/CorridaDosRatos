using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Property : MonoBehaviour
{
    public string name;
    public string description;
    public PropertyTypes propertyType;
    public GameObject propertyPrefab;
    [SerializeField]
    public Stock stock;
    public int sizeX;
    public int SizeY;

    private void Start() {
        stock = this.gameObject.AddComponent(typeof(Stock)) as Stock;    
    }

    //Receberá uma matriz encadeada para informar o "formato" que ocupa no mapa
    //Nessa matriz encadeada ele terá celulas ocupadas pelo estabelecimento
    //Celulas adicionais (para aprimoramentos)
    //Celulas de saida e entrada pela estrada

    //Ao usuário clicar, será percorrido essa matrix da construção e verificado se no mapa os lugares podem ser ocupados.
    //Se puder, todas as informações da matriz da construção serão coladas no mapa
}
