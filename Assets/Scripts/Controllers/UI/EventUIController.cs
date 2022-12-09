using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EventUIController : MonoBehaviour
{
    public GameObject eventPanel;
    public Image eventImage;
    public Text eventText;
    public Text eventDescriptionText;
    public Text buttonText;
    public void ShowEvent(Event _event){
        eventPanel.SetActive(true);
        eventImage.sprite = _event.sprite;
        eventText.text = _event.eventName;
        eventDescriptionText.text = _event.description;
        buttonText.text = _event.answer;
    }

    public void CloseEvent(){
        eventPanel.SetActive(false);
    }
}
