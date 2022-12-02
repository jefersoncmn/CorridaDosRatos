using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGeneratorManager : MonoBehaviour
{
    MapGeneratorController mapGeneratorController;
    BuildingsGeneratorController buildingsGeneratorController;
    public GameObject[] cellmap;

    public GameObject cellmodel;

    public int mapSizeX = 27;
    
    public int mapSizeY = 25;
    
    private void Awake() {
        mapGeneratorController = this.gameObject.GetComponent(typeof(MapGeneratorController)) as MapGeneratorController;
        buildingsGeneratorController = this.gameObject.GetComponent(typeof(BuildingsGeneratorController)) as BuildingsGeneratorController;
        
        cellmap = mapGeneratorController.cellmap;
        //Gerar mapa
        mapGeneratorController.spawnPaths(mapSizeX, mapSizeY, cellmodel);

        //Colocar as contruções no mapa
        buildingsGeneratorController.generateBuildingsOnMap(cellmap);
    }
    
}
