﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//=======================================================
// Created by: Edward Ngo
// Contributors:
//=======================================================

public class InfoDisplay : MonoBehaviour {

    // SCRIPT REFERENCE
    private Items items;
    private WalkieTalkie walkie;
    private Crocodile Crocodile;
    private TeddyBear Bear;  
    private Owl Owl;
    private GameManagerScript game;

    // USE TO DISPLAY IN GAME MESSAGES
    private string MiscInfo;

    // PLUG IN INSPECTOR
    public Text CrocTimer, BearTimer, OwlTimer;
    public Text CountdownTimer;
    public Text WalkieChannel;
    public Text Tooltip;
	public Image CentreDot;

    // GAME MANAGER TIMER INFO
    string timeRemaining;
    int timerMinute;
    int timerSecond;

    void Start() {

        game =  GetComponent<GameManagerScript>();
        items = GameObject.Find("FirstPersonCharacter").GetComponent<Items>();
        walkie = GameObject.Find("FirstPersonCharacter").GetComponent<WalkieTalkie>();

        Crocodile = GameObject.FindGameObjectWithTag("Crocodile").GetComponent<Crocodile>();
        Bear = GameObject.FindGameObjectWithTag("Bear").GetComponent<TeddyBear>();
        Owl =  GameObject.FindGameObjectWithTag("Owl").GetComponent<Owl>();

        Tooltip.text = string.Empty;

        WalkieChannel.enabled = false;
    }

    // Update is called once per frame
    void Update() {
        
        if (Input.GetMouseButtonDown(0)) {
            DisplayMessage();
        }

        // WALKY CHANNELS DISPLAY
        if (items.currentItem == Items.ITEMTYPE.WALKYTALKY) {
            if (!WalkieChannel.enabled) {
                WalkieChannel.enabled = true;
            }

            if (WalkieChannel.enabled) {
                WalkieChannel.text = "CH: " + walkie.currentChannel.ToString();
            }
        }

        if (items.currentItem != Items.ITEMTYPE.WALKYTALKY) {
            if (WalkieChannel.enabled) {
                WalkieChannel.enabled = false;
            }
        }

        // TUTORIAL TIMER
        if (!game.isTutorialFinished) {
            timeRemaining = string.Format("{0:0}:{1:00}", timerMinute, timerSecond);
            timerMinute = Mathf.FloorToInt(game.tutorialTimer / 60f);
            timerSecond = Mathf.FloorToInt(game.tutorialTimer - timerMinute * 60);
            CountdownTimer.text = timeRemaining;
        }

        // IN GAME TIMER
        if (game.isTutorialFinished) {
            timeRemaining = string.Format("{0:0}:{1:00}", timerMinute, timerSecond);
            timerMinute = Mathf.FloorToInt(game.GameTimer / 60f);
            timerSecond = Mathf.FloorToInt(game.GameTimer - timerMinute * 60);
            CountdownTimer.text = timeRemaining;
        }

        // MONSTER TRANSFORM TIMER
        CrocTimer.text = "Croc: " + Crocodile.timeToTransform.ToString("F0");
        BearTimer.text = "Bear: " + Bear.timeToTransform.ToString("F0");
        OwlTimer.text = "Owl: " + Owl.timeToTransform.ToString("F0");

    }

    public void DisplayTooltip(string word) {
        Tooltip.text = word.ToString();
    }

    public void ClearTooltip() {
        Tooltip.text = string.Empty;
    }

    //private void OnGUI() {
    //    float textBoxWidth = 400;
    //    float textBoxHeight = 100;
    //    float textBoxPosX = (Screen.width * 0.5f) - (textBoxWidth * 0.5f);
    //    float textBoxPosY = (Screen.height - textBoxHeight) - 100 ;
    //    GUI.TextField(new Rect(textBoxPosX, textBoxPosY, textBoxWidth, textBoxHeight), "hello");
    //}

    public void DisplayMessage() {

    }
}
