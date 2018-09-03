using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//=======================================================
// Created by: Edward Ngo
// Contributors:
//=======================================================

public class TimerUI : MonoBehaviour {

    private Crocodile Crocodile;
    //private GameObject Bear;
    //private GameObject Panda;   
    //private GameObject Owl;

    public Text CrocTimer, BearTimer, PandaTimer, OwlTimer;

    // Use this for initialization
    void Start () {
        Crocodile = GameObject.FindGameObjectWithTag("Crocodile").GetComponent<Crocodile>();
        //Bear = GameObject.FindGameObjectWithTag("Bear").GetComponent<;
        //Panda = GameObject.FindGameObjectWithTag("RedPanda");
        //Owl =  GameObject.FindGameObjectWithTag("Owl");
    }

    // Update is called once per frame
    void Update () {
        //Crocodile.timeToTransform;
        CrocTimer.text = Crocodile.timeToTransform.ToString("F0");
    }
}
