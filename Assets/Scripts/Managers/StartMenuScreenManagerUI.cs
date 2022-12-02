using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenuScreenManagerUI : MonoBehaviour
{
    public GameObject startMenuScreen;

    public void EnableStartMenuScreen(){
        startMenuScreen.SetActive(true);
    }

    public void DisableStartMenuScreen(){
        startMenuScreen.SetActive(false);
    }

    public void QuitGame(){
        Application.Quit();
    }
}
