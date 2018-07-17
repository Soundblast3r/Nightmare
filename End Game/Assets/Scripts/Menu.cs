using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;

public class Menu : MonoBehaviour
{
    //Make sure to attach these Buttons in the Inspector
    public GameObject NewGameButton;
    public GameObject ContinueButton;
    public GameObject QuitGameButton;
    public GameObject OptionsButton;
    public GameObject UnlockablesButton;
    public bool UnlockablesUnlocked;
    //public Button OptionsBackButton;
    //public Button UnlockablesBackButton;

    //Panels
    public GameObject MainMenuPanel;
    public GameObject OptionsPanel;
    public GameObject UnlockablesPanel;
    void Start()
    {
        MainMenuPanel.SetActive(true);
        OptionsPanel.SetActive(false);
        UnlockablesPanel.SetActive(false);

        {
            
        }
    }

    public void StartNew()
    {
        Debug.Log("New Game Initiated");
        SceneManager.LoadScene(1);
    }

    ///LoadGame
    public void StartLoad()
    {
        //Output this to console when the Button is clicked
        Debug.Log("Loading Game");
        Debug.Log("Load Game Unavailable");
    }

    ///Quit
    public void Terminate()
    {
        //Output this to console when the Button is clicked
        Debug.Log("Game Terminated");
        EditorApplication.isPlaying = false;
        Application.Quit();
    }

    ///Options
    public void ChangeOptions()
    {
        //Output this to console when the Button is clicked
        Debug.Log("Options Opened");

        MainMenuPanel.SetActive(false);
        OptionsPanel.SetActive(true);
        UnlockablesPanel.SetActive(false);
    }

    ///Unlockables
    public void Extras()
    {
        //Output this to console when the Button is clicked
        if (UnlockablesButton.activeSelf == true)
        {
            Debug.Log("Unlockables opened");

            MainMenuPanel.SetActive(false);
            OptionsPanel.SetActive(false);
            UnlockablesPanel.SetActive(true);
        }
    }

    public void CloseOptions()
    {
        //Output this to console when the Button is clicked
        Debug.Log("Options Closed");

        OptionsPanel.SetActive(false);
        UnlockablesPanel.SetActive(false);
        MainMenuPanel.SetActive(true);
    }

    ///Unlockables
    public void CloseExtras()
    {
        //Output this to console when the Button is clicked
        if (UnlockablesPanel.activeSelf == true)
        {
            Debug.Log("Unlockables Closed");

            OptionsPanel.SetActive(false);
            UnlockablesPanel.SetActive(false);
            MainMenuPanel.SetActive(true);
        }
    }

    private void Update()
    {
        if (UnlockablesUnlocked == true)
        {
            UnlockablesButton.SetActive(true);
        }

        else
        {
            UnlockablesButton.SetActive(false);
        }
    }
}