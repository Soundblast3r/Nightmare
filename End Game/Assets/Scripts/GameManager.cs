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

    public GameObject EndgameScreen;
    public GameObject WinScreen;
    public GameObject YouDied;

    public float GameTimer;
    public int CurrentScene = 1;

    [HideInInspector] public bool isGameOver;

    void Start()
    {
        isGameOver = false;
        EndgameScreen.SetActive(false);
        WinScreen.SetActive(false);
        YouDied.SetActive(false);
        GameTimer = 300;
    }

    private void Update()
    {
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

    public void WinGame()
    {
        // add win stuff here; 
        // -CUTSCENE
        // -HIGHSCORE
        // -REPLAY/QUIT
        // -SCORE?
    }
}
