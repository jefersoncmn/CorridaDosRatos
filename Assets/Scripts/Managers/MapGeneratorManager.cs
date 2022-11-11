using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGeneratorManager : MonoBehaviour
{
    MapGeneratorController mapGeneratorController;
    BuildingsGeneratorController buildingsGeneratorController;
    public GameObject[] cellmap;
    
    private void Awake() {
        mapGeneratorController = this.gameObject.GetComponent(typeof(MapGeneratorController)) as MapGeneratorController;
        buildingsGeneratorController = this.gameObject.GetComponent(typeof(BuildingsGeneratorController)) as BuildingsGeneratorController;
        
        cellmap = mapGeneratorController.cellmap;
        //Gerar mapa
        mapGeneratorController.spawnPaths();

        //Colocar as contruções no mapa
        buildingsGeneratorController.generateBuildingsOnMap(cellmap);
    }
    
}
