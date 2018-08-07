using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameClock : MonoBehaviour
{
    float GameTimer;
    //public int WorldClock;
    // TimeLimit
    bool isGameOver;

	// Use this for initialization
	void Start ()
    {
        GameTimer = 5;
        isGameOver = false;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if(GameTimer <= 0)
        {
            WorldClock += 1;
            GameTimer = 10;
            //Debug.Log(WorldClock);
        }

        if (WorldClock == 10)
        {
            Debug.Log("WIN");
            SceneManager.LoadScene(0);
        }

        GameTimer -= Time.fixedDeltaTime;

        Debug.Log(GameTimer);
	}
}
