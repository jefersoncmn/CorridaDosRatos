using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe responsável por criar as construções no mapa
/// </summary>
public class BuildingsGeneratorController : MonoBehaviour
{
    public void generateBuildingsOnMap(GameObject[] cellmap){
        //percorrer o mapa
        //TODO instanciar as propriedades em cada bloco e fazer o cado de propriedades que ocupam mais de um bloco. Ela teria que ver se nas vizinhas está ocupado, se não estiver, ela cria e ocupa as outras com a mesma instância da propriedade.
        foreach (var cell in cellmap)
        {
            Cell cellComponent = cell.gameObject.GetComponent(typeof(Cell)) as Cell;
            Property newProperty = cell.gameObject.AddComponent(typeof(Property)) as Property;

            cellComponent.property = newProperty;   
        }
    }
}
