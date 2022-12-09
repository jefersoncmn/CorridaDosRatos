using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    public GameObject[] buildings;
    private void Awake() {
        buildings = GameObject.FindGameObjectsWithTag("Building");
        SetComponentInBuildings();
    }

    private void SetComponentInBuildings(){
        foreach (var building in buildings)
        {
            Property property = building.AddComponent(typeof(Property)) as Property;
            property.propertyType = PropertyTypes.commercial;
        }
    }
}
