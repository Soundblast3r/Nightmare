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
    //private GameObject Bear;
    //private GameObject Panda;   
    //private GameObject Owl;

    public Text CrocTimer, BearTimer, PandaTimer, OwlTimer;
    public Text WalkieChannel;

    // Use this for initialization
    void Start() {

        items = GameObject.Find("FirstPersonCharacter").GetComponent<Items>();
        walkie = GameObject.Find("PlayerWalky").GetComponent<WalkieTalkie>();

        Crocodile = GameObject.FindGameObjectWithTag("Crocodile").GetComponent<Crocodile>();
        //Bear = GameObject.FindGameObjectWithTag("Bear").GetComponent<;
        //Panda = GameObject.FindGameObjectWithTag("RedPanda");
        //Owl =  GameObject.FindGameObjectWithTag("Owl");
    }

    // Update is called once per frame
    void Update() {

        if (items.currentItem == Items.ITEMTYPE.WALKYTALKY) {
            WalkieChannel.text = "CH: " + walkie.currentChannel.ToString();
        }

        CrocTimer.text = Crocodile.timeToTransform.ToString("F0");
    }
}
