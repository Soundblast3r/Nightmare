using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    //=======================================================
    // Created by Liam Gates
    // Updates:
    // by Callum Bradshaw
    // -Edward Ngo
    //=======================================================

    public GameObject EndgameScreen;
    public GameObject WinScreen;
    public GameObject YouDied;

    public float tutorialTimer;
    public bool isTutorialFinished;
    public float GameTimer;
    public bool isNightmareStarted;
    public int CurrentScene = 1;

    [HideInInspector] public bool isGameOver;

    void Start()
    {
        isGameOver = false;
        EndgameScreen.SetActive(false);
        WinScreen.SetActive(false);
        YouDied.SetActive(false);

        isTutorialFinished = false;
        tutorialTimer = 30;
        GameTimer = 300;
    }

    private void Update()
    {
        if(isGameOver)
        {
            SetGameOver();
        }

        // TUTORIAL COUNTDOWN
        if (!isTutorialFinished) {
            if (tutorialTimer > 0) {
                tutorialTimer -= Time.deltaTime;
            }

            if (tutorialTimer <= 0) {
                isTutorialFinished = true;
            }
        }

        // GAME COUNTDOWN
        if (isTutorialFinished) {
            if (GameTimer > 0) {
                GameTimer -= Time.fixedDeltaTime;
            }

            if (GameTimer <= 0) {
                WinGame();
            }
        }

    }

    public void SetGameOver() {
        Time.timeScale = 0;
        GameTimer = 0;
        EndgameScreen.SetActive(true);
        YouDied.SetActive(true);
    }

    public void WinGame()
    {
        // add win stuff here; 
        // -CUTSCENE
        // -HIGHSCORE
        // -REPLAY/QUIT
        // -SCORE?
    }
}
