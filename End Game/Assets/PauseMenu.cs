using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PauseMenu : MonoBehaviour {

    public GameObject pausePanel;
    public GameObject optionsPanel;
    public GameObject soundPanelOptions;
    public GameObject controlsPanelOptions;
    public GameObject graphicalPanelOptions;
    public GameObject mainMenuPanel;
    public GameObject restartPanel;

    // Use this for initialization
    void Awake ()
    {
        pause(); 
	}

    public void pause()
    {
        //set active pause panel
        pausePanel.SetActive(true);
        // nothing else active
        optionsPanel.SetActive(false);
        soundPanelOptions.SetActive(false);
        controlsPanelOptions.SetActive(false);
        graphicalPanelOptions.SetActive(false);
        mainMenuPanel.SetActive(false);
        restartPanel.SetActive(false);
    }

    public void options()
    {
        //set active options panel
        optionsPanel.SetActive(true);
        // nothing else active
        pausePanel.SetActive(false);

        //sound
        ///player
        ///enviromnet
        ///npc
        ///music
        //controls
        ///image of controls
        //graphical
        ///aspect ratio
    }

    public void mainMenu()
    {
        pausePanel.SetActive(false);
        optionsPanel.SetActive(false);
        soundPanelOptions.SetActive(false);
        controlsPanelOptions.SetActive(false);
        graphicalPanelOptions.SetActive(false);
        mainMenuPanel.SetActive(false);
        restartPanel.SetActive(false);

        //confirm();
    }

    public void restart()
    {
        //?
    }

    public void resume()
    {
        pausePanel.SetActive(false);
        optionsPanel.SetActive(false);
        soundPanelOptions.SetActive(false);
        controlsPanelOptions.SetActive(false);
        graphicalPanelOptions.SetActive(false);
        mainMenuPanel.SetActive(false);
        restartPanel.SetActive(false);
    }

    public void confirm()
    {

    }
}
