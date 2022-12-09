using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CreatePlayerManagerUI : MonoBehaviour
{
    public GameObject startMenuScreen;
    public GameObject selectDreamPanel;
    public GameObject createPlayerNamePanel;
    public SelectDreamPanelController selectDreamPanelController;
    public CreatePlayerNameController createPlayerNameController;

    public PlayerManager playerManager;

    void Awake()
    {
        //Get components
    }

    public void GoToSelectDreamPlayerPanel(){
        startMenuScreen.SetActive(false);
        selectDreamPanel.SetActive(true);
    }

    public void GoToCreateNamePlayerPanel(){
        if(selectDreamPanelController.selectedDream != null){
            startMenuScreen.SetActive(false);
            selectDreamPanel.SetActive(false);
            createPlayerNamePanel.SetActive(true);
        }
    }

    public void EndPlayerCreation(){
        // playerManager.CreatePlayer("test", selectDreamPanelController.selectedDream);
        SceneManager.LoadScene("Game");
        //TODO forma de escrever pelo celular
        /*
        if(createPlayerNameController.playerName != string.Empty){
            playerManager.CreatePlayer(createPlayerNameController.playerName, selectDreamPanelController.selectedDream);
            SceneManager.LoadScene("Game");
        }
        */
    }

}
