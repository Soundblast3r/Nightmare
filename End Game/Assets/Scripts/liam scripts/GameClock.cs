using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClock : MonoBehaviour
{
    public float GameTimer;
    bool isGameOver;

	// Use this for initialization
	void Start ()
    {
        isGameOver = false;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if(GameTimer >= 0)
        {
            Debug.Log(GameTimer);
            GameTimer -= Time.fixedDeltaTime;
        }

        if (GameTimer <= 0)
        {
            Debug.Log("WIN");
        }
	}
}
