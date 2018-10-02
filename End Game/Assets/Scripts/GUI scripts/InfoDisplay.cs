using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//=======================================================
// Created by: Edward Ngo
// Contributors:
//=======================================================

public class InfoDisplay : MonoBehaviour {

    private Items items;
    private WalkieTalkie walkie;
    private Crocodile Crocodile;
    private TeddyBear Bear;  
    private Owl Owl;
    private GameManager game;

    public Text CrocTimer, BearTimer, OwlTimer;
    public Text CountdownTimer;
    public Text WalkieChannel;
	public Image CentreDot;
    public Text Tooltip;

    // timer info
    string timeRemaining;
    int timerMinute;
    int timerSecond;

    void Start() {

        game = GameObject.Find("GameManager").GetComponent<GameManager>();
        items = GameObject.Find("FirstPersonCharacter").GetComponent<Items>();
        walkie = GameObject.Find("FirstPersonCharacter").GetComponent<WalkieTalkie>();

        Crocodile = GameObject.FindGameObjectWithTag("Crocodile").GetComponent<Crocodile>();
        Bear = GameObject.FindGameObjectWithTag("Bear").GetComponent<TeddyBear>();
        //Panda = GameObject.FindGameObjectWithTag("RedPanda").GetComponent<RedPanda>();
        //Owl =  GameObject.FindGameObjectWithTag("Owl").GetComponent<Owl>();

        Tooltip.text = string.Empty;

        WalkieChannel.enabled = false;
    }

    // Update is called once per frame
    void Update() {
        
        // WALKY DISPLAY
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

        timeRemaining = string.Format("{0:0}:{1:00}", timerMinute, timerSecond);
        timerMinute = Mathf.FloorToInt(game.GameTimer / 60f);
        timerSecond = Mathf.FloorToInt(game.GameTimer - timerMinute * 60);

        // TIMERS DISPLAY
        CountdownTimer.text = timeRemaining;

        CrocTimer.text = "Croc: " + Crocodile.timeToTransform.ToString("F0");
        BearTimer.text = "Bear: " + Bear.timeToTransform.ToString("F0");
       //PandaTimer.text = "Panda: " + Panda.timeToTransform.ToString("F0");
       //OwlTimer.text = "Owl: " + Owl.timeToTransform.ToString("F0");

    }

    public void DisplayTooltip(string word) {
        Tooltip.text = word.ToString();
    }

    public void ClearTooltip() {
        Tooltip.text = string.Empty;
    }

    
}
