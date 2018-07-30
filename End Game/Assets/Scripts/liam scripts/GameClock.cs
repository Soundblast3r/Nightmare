using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClock : MonoBehaviour
{
    float GameTimer;
    bool isGameOver;

	// Use this for initialization
	void Start ()
    {
        isGameOver = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        GameTimer -= Time.deltaTime;
	}
}
