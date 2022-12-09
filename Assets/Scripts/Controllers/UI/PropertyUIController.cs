using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PropertyUIController : MonoBehaviour
{
    public Text propertyNameText;
    public Text propertyTypeText;
    public Text stockVariationValueText;
    public Text playerStocksAmountText;
    public GameObject propertyPanel;
    public WindowGraph windowGraph;
    
    public PlayerManager playerManager;
    public SelectManager selectManager;

    public Property selectedProperty;

    private void Awake() {
        selectManager.OnSelectedItem+=SetPropertyUIValues;
        selectManager.OnSelectedItem+=SelectProperty;
    }

    public void SelectProperty(GameObject selectedProperty){
        this.selectedProperty = selectedProperty.GetComponentInParent(typeof(Property)) as Property;
    }
    public void SetPropertyUIValues(GameObject selectedProperty){
        
        if(selectedProperty == null){
            return;
        }
        Property property = selectedProperty.GetComponentInParent(typeof(Property)) as Property;
        propertyNameText.text = property.name;
        propertyTypeText.text = property.description;
        stockVariationValueText.text = "Próximas atualizações";

        List<Asset> playerAssets = playerManager.player.finance.GetAssets();
        foreach (var asset in playerAssets)
        {
            if(asset == property.stock.asset){
                playerStocksAmountText.text = asset.amount.ToString();
            }
        }
        propertyPanel.SetActive(true);

        ///Gráfico

        List<float> valueList = new List<float>();//Lista valores da acao que ja passaram
        for (int i = 0; i <= property.stock.indexValueOverTime; i++)
        {
            valueList.Add(property.stock.valueOverTime[i]);
        }
        
        windowGraph.ShowGraph(valueList, -1, (int _i) => "Day " + (_i + 1), (float _f) => "$" + Mathf.RoundToInt(_f));//Define o texto que acompanha os valores
    }

    public void EnablePropertyPanel(){
        propertyPanel.SetActive(true);
    }

    public void DisablePropertyPanel(){
        propertyPanel.SetActive(false);
    }

    public void BuyStock(){
        if(selectedProperty == null){
            return;
        }
        playerManager.financeController.BuyStock(playerManager.player.finance, selectedProperty.stock.asset);
    }

    public void SellStock(){
        if(selectedProperty == null){
            return;
        }
        playerManager.financeController.SellStock(playerManager.player.finance, selectedProperty.stock.asset);
    }
}
