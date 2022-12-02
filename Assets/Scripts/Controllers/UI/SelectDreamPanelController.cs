using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectDreamPanelController : MonoBehaviour
{
    public DreamObject[] dreamsObjects;
    public Image selectedDreamImage;
    public Text selectedDreamText;
    public GameObject dreamOptionComponent;
    public GameObject scrollableDreamsRow;//Para instanciar os DreamOptionComponent

    public Dream selectedDream;
    void Start()
    {
        dreamsObjects = LoadScriptableObjectsOnFileController.LoadDreams();
        SetDreamsOnUI();
    }

    void CreateDreamOptionComponent(DreamObject dreamObject){
        var newDreamOptionComponent = Instantiate(dreamOptionComponent, new Vector3(0, 0, 0), Quaternion.identity);
        
        Dream newDream = newDreamOptionComponent.GetComponent(typeof(Dream)) as Dream;
        newDream.cost = dreamObject.cost;
        newDream.description = dreamObject.description;
        newDream.sprite = dreamObject.sprite;
        

        newDreamOptionComponent.transform.SetParent(scrollableDreamsRow.transform, false);
        Text dreamText = newDreamOptionComponent.GetComponentInChildren(typeof(Text)) as Text;
        dreamText.text = dreamObject.description;
        Image dreamImage = newDreamOptionComponent.GetComponentInChildren(typeof(Image)) as Image;
        dreamImage.sprite = dreamObject.sprite;
        Button dreamButton = newDreamOptionComponent.GetComponentInChildren(typeof(Button)) as Button;
        dreamButton.onClick.AddListener(delegate{SelectDream(newDream);});
    }

    void SetDreamsOnUI(){
        foreach(DreamObject dreamObject in dreamsObjects)
        {
            CreateDreamOptionComponent(dreamObject);
        }
    }

    public void SelectDream(Dream dream){
        selectedDream = dream;
        ChangeSelectedDreamOnView(dream);
    }

    public void ChangeSelectedDreamOnView(Dream dream){
        selectedDreamImage.sprite = dream.sprite;
        selectedDreamText.text = dream.description;
    }

}
