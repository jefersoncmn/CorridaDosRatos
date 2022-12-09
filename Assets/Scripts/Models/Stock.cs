using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stock : MonoBehaviour
{
    public Asset asset;
    public List<float> valueOverTime = new List<float>();//TODO save
    public int indexValueOverTime;
    public TurnController turnController;

    private void Awake() {
        turnController = FindObjectOfType<TurnController>();
        turnController.OnTurnPass += updateCurrentValue;
    }

    private void Start() {
        createValueOverTime();
        indexValueOverTime = 0;
        asset = new Asset("Ação", valueOverTime[0], 0.1);
    }

    void updateCurrentValue(){
        //Quando chegar no final ele irá criar mais
        if(valueOverTime[indexValueOverTime] == valueOverTime[^1]){
            createValueOverTime();
        }
        indexValueOverTime++;
        SetCurrentValue(valueOverTime[indexValueOverTime]);
    }

    private void SetCurrentValue(float currentValue){
        asset.value = currentValue;
    }

    void createValueOverTime(){
        float[] _valueOverTime = StockGeneratorController.generateStock(20, Random.Range(0, 10000), 0.1f);
        foreach (var value in _valueOverTime)
        {
            valueOverTime.Add(value*100f);
        }
    }

}
