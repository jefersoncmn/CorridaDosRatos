using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectManager : MonoBehaviour
{
    [SerializeField] private string selectableTag = "Selectable";
    // [SerializeField] private Material highlightMaterial;
    // [SerializeField] private Material defaultMaterial;
    public float timeSelected = 0f;
    private Transform _selection;

    [SerializeField] 
    public delegate void OnSelectedItemHandler(GameObject selectedProperty);
    [SerializeField] 
    public event OnSelectedItemHandler OnSelectedItem;
    
    
    void Update()
    {
        SelectItem();
    }

    private void SelectItem(){
        if(Input.touchCount == 1){
            Touch touch = Input.GetTouch(0);
            timeSelected += Time.deltaTime;//Start add time
            
            if(touch.phase == TouchPhase.Ended){
                if(timeSelected > 0.2f){ //Tempo definido para o quick click
                    timeSelected = 0;
                    return;
                } else {
                    Vector3 touchPoint = new Vector3(touch.position.x, touch.position.y, 8);
                    var ray = Camera.main.ScreenPointToRay(touchPoint);
            
                    RaycastHit hit;
                    if(Physics.Raycast(ray, out hit)){
                        var selection = hit.transform.gameObject;
                        if(selection.tag == selectableTag){
                            OnSelectedItem?.Invoke(selection);
                        }
                    }
                }
                timeSelected = 0;
            }
            
            
            
        }
    }
}
