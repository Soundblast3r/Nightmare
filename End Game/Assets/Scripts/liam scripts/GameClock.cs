using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameClock : MonoBehaviour
{
    /// <summary>
    // Created by Liam Gates
    // Updates:
    // by Callum Bradshaw
    /// </summary>
    public GameObject EndgameScreen;
    public GameObject WinScreen;
    public GameObject YouDied;
    public GameObject pausePanel;
    public GameObject optionsPanel;
    public GameObject soundPanelOptions;
    public GameObject controlsPanelOptions;
    public GameObject graphicalPanelOptions;
    public GameObject mainMenuPanel;
    public GameObject restartPanel;
    public GameObject PauseMenu;
    public float GameTimer = 10;
    bool isPaused;

    //public int WorldClock;
    // TimeLimit
    bool isGameOver;

    // Use this for initialization
    void Awake()
    {
        Pause();
    }

    void Start()
    {
        isPaused = false;
        isGameOver = false;
        EndgameScreen.SetActive(false);
        WinScreen.SetActive(false);
        YouDied.SetActive(false);
        pausePanel.SetActive(false);
        optionsPanel.SetActive(false);
        soundPanelOptions.SetActive(false);
        controlsPanelOptions.SetActive(false);
        graphicalPanelOptions.SetActive(false);
        mainMenuPanel.SetActive(false);
        restartPanel.SetActive(false);
    }

    
	// Use this for initialization
	

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameTimer > 0)
            {
                if (isPaused == false)
                {
                    isPaused = true;
                    //Time.timeScale = 0;
                    PauseMenu.SetActive(true);
                    pausePanel.SetActive(true);
                }

                else if (isPaused == true)
                {
                    isPaused = false;
                    //Time.timeScale = 1;
                    PauseMenu.SetActive(false);
                    pausePanel.SetActive(false);
                    optionsPanel.SetActive(false);
                    soundPanelOptions.SetActive(false);
                    controlsPanelOptions.SetActive(false);
                    graphicalPanelOptions.SetActive(false);
                    mainMenuPanel.SetActive(false);
                    restartPanel.SetActive(false);
                }
            }
        }

        else
        {
            //nothing
        }
        //if (GameTimer <= 0)
        //{
        //    Time.timeScale = 0;
        //    GameTimer = 0;
        //    Debug.Log("WIN");
        //    EndgameScreen.SetActive(true);
        //    WinScreen.SetActive(true);
        //}

        if (GameTimer <= 0)
            //else if (isDead == true)
            {
                
                //GameTimer = 0;
                Time.timeScale = 0;
                Debug.Log("You Died");
                EndgameScreen.SetActive(true);
                YouDied.SetActive(true);
            }
        
    }
    // Update is called once per frame
    void FixedUpdate ()
    {
            //if(GameTimer <= 0)
            //{
            //    WorldClock += 1;
            //    GameTimer = 10;
            //    //Debug.Log(WorldClock);
            //}



            GameTimer -= Time.fixedDeltaTime;

            Debug.Log(GameTimer);

	}

    public void ReturnToMenu()
    {
        EndgameScreen.SetActive(false);
        YouDied.SetActive(false);
        WinScreen.SetActive(false);
        Debug.Log("Back To Main Menu");
        SceneManager.UnloadSceneAsync(1);
        SceneManager.LoadScene(0);
    }

    public void RestartGame()
    {
        EndgameScreen.SetActive(false);
        YouDied.SetActive(false);
        WinScreen.SetActive(false);
        Debug.Log("Restart Game");
        SceneManager.UnloadSceneAsync(1);
        SceneManager.LoadScene(1);
    }

    public void Pause()
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

    public void Options()
    {
        //set active options panel
        optionsPanel.SetActive(true);
        // nothing else active
        soundPanelOptions.SetActive(false);
        controlsPanelOptions.SetActive(false);
        graphicalPanelOptions.SetActive(false);
        mainMenuPanel.SetActive(false);
        restartPanel.SetActive(false);
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

    public void MainMenu()
    {
        pausePanel.SetActive(false);
        optionsPanel.SetActive(false);
        soundPanelOptions.SetActive(false);
        controlsPanelOptions.SetActive(false);
        graphicalPanelOptions.SetActive(false);
        mainMenuPanel.SetActive(true);
        restartPanel.SetActive(false);
    }

    public void Restart()
    {
        pausePanel.SetActive(false);
        optionsPanel.SetActive(false);
        soundPanelOptions.SetActive(false);
        controlsPanelOptions.SetActive(false);
        graphicalPanelOptions.SetActive(false);
        mainMenuPanel.SetActive(false);
        restartPanel.SetActive(true);
    }

    public void Resume()
    {
        pausePanel.SetActive(false);
        optionsPanel.SetActive(false);
        soundPanelOptions.SetActive(false);
        controlsPanelOptions.SetActive(false);
        graphicalPanelOptions.SetActive(false);
        mainMenuPanel.SetActive(false);
        restartPanel.SetActive(false);
        PauseMenu.SetActive(false);
        isPaused = false;
    }

    public void Confirm()
    {
        pausePanel.SetActive(false);
        optionsPanel.SetActive(false);
        soundPanelOptions.SetActive(false);
        controlsPanelOptions.SetActive(false);
        graphicalPanelOptions.SetActive(false);
        mainMenuPanel.SetActive(false);
        restartPanel.SetActive(false);
    }

    public void SoundPanel()
    {
        pausePanel.SetActive(false);
        optionsPanel.SetActive(false);
        soundPanelOptions.SetActive(true);
        controlsPanelOptions.SetActive(false);
        graphicalPanelOptions.SetActive(false);
        mainMenuPanel.SetActive(false);
        restartPanel.SetActive(false);
    }

    public void Controls()
    {
        pausePanel.SetActive(false);
        optionsPanel.SetActive(false);
        soundPanelOptions.SetActive(false);
        controlsPanelOptions.SetActive(true);
        graphicalPanelOptions.SetActive(false);
        mainMenuPanel.SetActive(false);
        restartPanel.SetActive(false);
    }

    public void Graphicaloptions()
    {
        pausePanel.SetActive(false);
        optionsPanel.SetActive(false);
        soundPanelOptions.SetActive(false);
        controlsPanelOptions.SetActive(false);
        graphicalPanelOptions.SetActive(true);
        mainMenuPanel.SetActive(false);
        restartPanel.SetActive(false);
    }

}
