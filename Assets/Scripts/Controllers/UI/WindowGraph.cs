using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// https://youtu.be/CmU5-v-v1Qo?list=PLzDRvYVwl53v5ur4GluoabyckImZz3TVQ
public class WindowGraph : MonoBehaviour
{
    [SerializeField] private RectTransform graphContainer;
    [SerializeField] private RectTransform labelTemplateX;
    [SerializeField] private RectTransform labelTemplateY;
    [SerializeField] private RectTransform dashTemplateX;
    [SerializeField] private RectTransform dashTemplateY;
    [SerializeField] private List<GameObject> gameObjectList;

    //Coisas sobre o Rect
    //Pivot é o centro do item
    
    [SerializeField] private Sprite circleSprite;

    private void Awake() {
        graphContainer = transform.Find("graphContainer").GetComponent<RectTransform>();
        labelTemplateX = graphContainer.Find("labelTemplateX").GetComponent<RectTransform>();
        labelTemplateY = graphContainer.Find("labelTemplateY").GetComponent<RectTransform>();
        dashTemplateX = graphContainer.Find("dashTemplateX").GetComponent<RectTransform>();
        dashTemplateY = graphContainer.Find("dashTemplateY").GetComponent<RectTransform>();
        gameObjectList = new List<GameObject>();

        // List<int> valueList = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 37, 40, 36, 33, 50, 30, 60, 50, 40, 20, 5, 20, 10, 50, 30, 20, 11 };
        // ShowGraph(valueList, -1, (int _i) => "Day " + (_i + 1), (float _f) => "$" + Mathf.RoundToInt(_f));//Define o texto que acompanha os valores
    }
    
    /// <summary>
    /// Função responsável por gerar o gráfico
    /// </summary>
    /// <param name="valueList">Valores</param>
    /// <param name="getAxisLabelX">Descrição da cordenada X</param>
    /// <param name="getAxisLabelY">Descrição da cordenada y</param>
    public void ShowGraph(List<float> valueList, int maxVisibleValueAmount = -1, Func<int, string> getAxisLabelX = null, Func<float, string> getAxisLabelY = null){
        if (getAxisLabelX == null) {
            getAxisLabelX = delegate (int _i) { return _i.ToString(); };
        }
        if (getAxisLabelY == null) {
            getAxisLabelY = delegate (float _f) { return Mathf.RoundToInt(_f).ToString(); };
        }

        if (maxVisibleValueAmount <= 0) {
            maxVisibleValueAmount = valueList.Count;
        }

        foreach (GameObject gameObject in gameObjectList) {
            Destroy(gameObject);
        }
        gameObjectList.Clear();
        
        float graphWidth = graphContainer.sizeDelta.x;
        float graphHeight = graphContainer.sizeDelta.y;

        float yMaximum = valueList[0];
        float yMinimum = valueList[0];
        
        for (int i = Mathf.Max(valueList.Count - maxVisibleValueAmount, 0); i < valueList.Count; i++) {
            float value = valueList[i];
            if (value > yMaximum) {
                yMaximum = value;
            }
            if (value < yMinimum) {
                yMinimum = value;
            }
        }

        float yDifference = yMaximum - yMinimum;
        if (yDifference <= 0) {
            yDifference = 5f;
        }
        yMaximum = yMaximum + (yDifference * 0.2f);
        yMinimum = yMinimum - (yDifference * 0.2f);

        yMinimum = 0f; // Start the graph at zero

        float xSize = graphWidth / (maxVisibleValueAmount + 1);

        int xIndex = 0;

        GameObject lastCircleGameObject = null;
        for (int i = Mathf.Max(valueList.Count - maxVisibleValueAmount, 0); i < valueList.Count; i++) {
            float xPosition = xSize + xIndex * xSize;
            float yPosition = ((valueList[i] - yMinimum) / (yMaximum - yMinimum)) * graphHeight;
            GameObject circleGameObject = CreateCircle(new Vector2(xPosition, yPosition));
            gameObjectList.Add(circleGameObject);
            if (lastCircleGameObject != null) {
                GameObject dotConnectionGameObject = CreateDotConnection(lastCircleGameObject.GetComponent<RectTransform>().anchoredPosition, circleGameObject.GetComponent<RectTransform>().anchoredPosition);
                gameObjectList.Add(dotConnectionGameObject);
            }
            lastCircleGameObject = circleGameObject;

            RectTransform labelX = Instantiate(labelTemplateX);
            labelX.SetParent(graphContainer, false);
            labelX.gameObject.SetActive(true);
            labelX.anchoredPosition = new Vector2(xPosition, -7f);
            labelX.GetComponent<Text>().text = getAxisLabelX(i);
            gameObjectList.Add(labelX.gameObject);

            RectTransform dashX = Instantiate(dashTemplateX);
            dashX.SetParent(graphContainer, false);
            dashX.gameObject.SetActive(true);
            dashX.anchoredPosition = new Vector2(xPosition, 0f);
            gameObjectList.Add(dashX.gameObject);

            xIndex++;
        }

        int separatorCount = 10;
        for (int i = 0; i <= separatorCount; i++) {
            RectTransform labelY = Instantiate(labelTemplateY);
            labelY.SetParent(graphContainer, false);
            labelY.gameObject.SetActive(true);
            float normalizedValue = i * 1f / separatorCount;
            labelY.anchoredPosition = new Vector2(-7f, normalizedValue * graphHeight);
            labelY.GetComponent<Text>().text = getAxisLabelY(yMinimum + (normalizedValue * (yMaximum - yMinimum)));
            gameObjectList.Add(labelY.gameObject);

            RectTransform dashY = Instantiate(dashTemplateY);
            dashY.SetParent(graphContainer, false);
            dashY.gameObject.SetActive(true);
            dashY.anchoredPosition = new Vector2(0f, normalizedValue * graphHeight);
            gameObjectList.Add(dashY.gameObject);
        }
    }

    private GameObject CreateCircle(Vector2 anchoredPosition) {
        GameObject gameObject = new GameObject("circle", typeof(Image));
        gameObject.transform.SetParent(graphContainer, false);
        gameObject.GetComponent<Image>().sprite = circleSprite;
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = anchoredPosition;
        rectTransform.sizeDelta = new Vector2(11, 11);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        return gameObject;
    }

    /// <summary>
    /// Função responsável por criar a conexão entre os pontos
    /// </summary>
    /// <param name="dotPositionA">Posição do ponto A</param>
    /// <param name="dotPositionB">Posição do ponto B</param>
    /// <returns>Retorna o objeto que é a linha entre os pontos</returns>
    private GameObject CreateDotConnection(Vector2 dotPositionA, Vector2 dotPositionB) {
        GameObject gameObject = new GameObject("dotConnection", typeof(Image));//Cria o objeto
        gameObject.transform.SetParent(graphContainer, false);
        gameObject.GetComponent<Image>().color = new Color(0, 0, 0, .5f);

        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();

        Vector2 direction = (dotPositionB - dotPositionA).normalized;//TODO [anotação] Direção entre o ponto A e B
        float distance = Vector2.Distance(dotPositionA, dotPositionB);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        rectTransform.sizeDelta = new Vector2(distance, 3f);
        rectTransform.anchoredPosition = dotPositionA + direction * distance * .5f;
        rectTransform.localEulerAngles = new Vector3(0, 0, (Mathf.Atan2(direction.y, direction.x)*180/Mathf.PI));
        return gameObject;
    }
}
