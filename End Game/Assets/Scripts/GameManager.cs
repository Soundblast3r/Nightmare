using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //=======================================================
    // Created by Liam Gates
    // Updates:
    // by Callum Bradshaw
    // -Edward Ngo
    //=======================================================

    private Button m_Resume;
    private Button m_Restart;
    private Button m_MainMenu;

    public GameObject EndgameScreen;
    public GameObject WinScreen;
    public GameObject YouDied;
    public GameObject pausePanel;
    public GameObject mainMenuPanel;
    public GameObject restartPanel;
    public GameObject PauseMenu;

    //public SceneChanger SceneChanger;

    public float GameTimer;
    public int CurrentScene = 1;


    bool isPaused;

    [HideInInspector] public bool isGameOver;

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
        mainMenuPanel.SetActive(false);
        restartPanel.SetActive(false);
        GameTimer = 300;
    }

    
	// Use this for initialization
	

    private void Update()
    {
        /*
        //from here
        if (GameTimer <= 0)
        {
            if (CurrentScene == 1)
            {
                Debug.Log("Scene 2 loaded");
                CurrentScene = 2;
                SceneManager.LoadScene(2);
                GameTimer = 10;
            }

            else if (CurrentScene == 2)
            {
                Debug.Log("Scene 3 loaded");
                CurrentScene = 3;
                SceneManager.LoadScene(3);
                GameTimer = 5;
            }

            else if (CurrentScene == 3)
            {
                Debug.Log("Scene 4 loaded");
                CurrentScene = 4;
                SceneManager.LoadScene(4);
                GameTimer = 10;
            }

            else if (CurrentScene == 4)
            {
                Debug.Log("Scene 5 loaded");
                CurrentScene = 5;
                SceneManager.LoadScene(5);
                GameTimer = 15;
            }

            else if (CurrentScene == 5)
            {
                Debug.Log("end of game loaded");
                CurrentScene = 6;
                SceneManager.LoadScene(6);
            }
        }
        //to here
        */

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameTimer > 0)
            {
                if (isPaused == false)
                {
                    isPaused = true;
                    Time.timeScale = 0;
                    PauseMenu.SetActive(true);
                    pausePanel.SetActive(true);
                }

                else if (isPaused == true)
                {
                    isPaused = false;
                    Time.timeScale = 1;
                    PauseMenu.SetActive(false);
                    pausePanel.SetActive(false);
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

        //if (GameTimer <= 0)
        //    //else if (isDead == true)
        //    {
                
        //        //GameTimer = 0;
        //        Time.timeScale = 0;
        //        Debug.Log("You Died");
        //        EndgameScreen.SetActive(true);
        //        YouDied.SetActive(true);
        //    }

        if(isGameOver)
        {
            Time.timeScale = 0;
            GameTimer = 0;
            //Debug.Log("WIN");
            EndgameScreen.SetActive(true);
            YouDied.SetActive(true);
        }

    }
    // Update is called once per frame
    void FixedUpdate ()
    {

        // GAME WIN COUNTDOWN 
        if (GameTimer > 0) {
           GameTimer -= Time.fixedDeltaTime;
        }
	}

    public void ReturnToMenu()
    {
        EndgameScreen.SetActive(false);
        YouDied.SetActive(false);
        WinScreen.SetActive(false);
        SceneManager.LoadScene(0);
    }

    public void RestartGame()
    {
        EndgameScreen.SetActive(false);
        YouDied.SetActive(false);
        WinScreen.SetActive(false);
        SceneManager.LoadScene(CurrentScene);
    }

    public void Pause()
    {
        pausePanel.SetActive(true);
        mainMenuPanel.SetActive(false);
        restartPanel.SetActive(false);
    }

    public void Options()
    {
        mainMenuPanel.SetActive(false);
        restartPanel.SetActive(false);
        pausePanel.SetActive(false);
    }

    public void MainMenu()
    {
        pausePanel.SetActive(false);
        mainMenuPanel.SetActive(true);
        restartPanel.SetActive(false);
    }

    public void Restart()
    {
        pausePanel.SetActive(false);
        mainMenuPanel.SetActive(false);
        restartPanel.SetActive(true);
    }

    public void Resume()
    {
        pausePanel.SetActive(false);
        mainMenuPanel.SetActive(false);
        restartPanel.SetActive(false);
        PauseMenu.SetActive(false);
        isPaused = false;
    }

    public void Confirm()
    {
        pausePanel.SetActive(false);
        mainMenuPanel.SetActive(false);
        restartPanel.SetActive(false);
    }

    public void SoundPanel()
    {
        pausePanel.SetActive(false);
        mainMenuPanel.SetActive(false);
        restartPanel.SetActive(false);
    }

    public void Controls()
    {
        pausePanel.SetActive(false);
        mainMenuPanel.SetActive(false);
        restartPanel.SetActive(false);
    }

    public void Graphicaloptions()
    {
        pausePanel.SetActive(false);
        mainMenuPanel.SetActive(false);
        restartPanel.SetActive(false);
    }


    public void WinGame() {


        // add win stuff here; 
        // -CUTSCENE
        // -HIGHSCORE
        // -REPLAY/QUIT
        // -SCORE?
    }
}
