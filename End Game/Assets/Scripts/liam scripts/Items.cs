using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//=======================================================
//  Created By Liam Gates
//  Updates: Edward ngo
//=======================================================

public class Items : MonoBehaviour
{
    // Script references
    private Interactions interactions;
    private Camera cam;
    private Crocodile Croc;
    private WalkieTalkie wt;
    private InfoDisplay infoDisplay;

    // Gameobject references
    private GameObject m_SprayBottle;
    private GameObject m_WalkyTalky;

    //if cheack Bools 
    [HideInInspector] public bool BottleAcquired;
    [HideInInspector] public bool WalkyAcquired;

    public ParticleSystem Spray;

    private float rayDistance = 5;
    private float SphereRadius;
    private int sprayTimerIncrease;

    public enum ITEMTYPE {
        NONE,
        SPRAYBOTTLE,
        WALKYTALKY
    }

    public ITEMTYPE currentItem;

	void Start ()
    {
        // Component References
        cam = GetComponent<Camera>();
        interactions = GetComponent<Interactions>();
        wt = GetComponent<WalkieTalkie>();
        infoDisplay = GameObject.Find("GameUI").GetComponent<InfoDisplay>();

        // Toy/Demon references

        // Items attached to player
        m_SprayBottle = GameObject.Find("PlayerBottle");
        m_WalkyTalky = GameObject.Find("PlayerWalky");

        // Check if player has an item
        BottleAcquired = false;
        WalkyAcquired = false;

        // Set items to inactive (default)
        m_SprayBottle.SetActive(false);
        m_WalkyTalky.SetActive(false);

        // Other variables
        currentItem = ITEMTYPE.NONE;
        sprayTimerIncrease = 1;
        SphereRadius = 0.10f;

        //Croc = GameObject.Find("PlushieCroc").GetComponentInParent<Crocodile>();
    }

	void Update ()
    {
        // SWITCH ITEM
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchItem(0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            if (BottleAcquired && currentItem != ITEMTYPE.SPRAYBOTTLE) {
                SwitchItem(2);
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha3)) {
            if (WalkyAcquired && currentItem != ITEMTYPE.WALKYTALKY) {
                SwitchItem(3);                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                
            }
        }

        // USE ITEM ON LEFT CLICK
        if (currentItem == ITEMTYPE.NONE) {
            return;
        }

        if (currentItem == ITEMTYPE.SPRAYBOTTLE && Input.GetMouseButton(0)) {
            UseSprayBottle();
        }

        if (currentItem == ITEMTYPE.WALKYTALKY && Input.GetMouseButtonDown(0)) {
            UseWalky();
        }
    }

    void SwitchItem(int val) {

        if (val == 0) {
            currentItem = ITEMTYPE.NONE;

            if (m_SprayBottle != null || m_WalkyTalky != null) {
                m_SprayBottle.SetActive(false);
                m_WalkyTalky.SetActive(false);
            }
        }

        if (val == 2) {
            currentItem = ITEMTYPE.SPRAYBOTTLE;
            m_WalkyTalky.SetActive(false);
            if (m_SprayBottle != null) {
                m_SprayBottle.SetActive(true);
                infoDisplay.DisplayMessage("Left-Click to spray", 1);
            }
        }

        if (val == 3) {
            currentItem = ITEMTYPE.WALKYTALKY;
            m_SprayBottle.SetActive(false);
            if (m_WalkyTalky != null) {
                m_WalkyTalky.SetActive(true);
                infoDisplay.DisplayMessage("Mouse-Scroll to set channel, Left-Click to use", 1);
            }
        }
    }

    void UseSprayBottle()
    {
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (!Spray.isPlaying) {
            Spray.Play();
        }

        if (Physics.SphereCast(ray, SphereRadius, out hit, rayDistance))
        {
            if(BottleAcquired == true)
            {

                if (hit.collider.tag == "Plushie" && Spray.isPlaying) {

                    if (Croc.timeToTransform < Croc.timeToTransformMax) {
                        Croc.timeToTransform += (sprayTimerIncrease * 0.25f);

                        Croc.PlayFeedback();
                    }
                }
            }
        }
    }

    void UseWalky() {
        wt.MakeNoise();
        
    }

}