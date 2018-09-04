using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

//=======================================================
// Created by: Edward Ngo
// Contributors:
//=======================================================

public class WalkieTalkie : MonoBehaviour {

    private Items items;

    private int m_Channel;
    public int currentChannel;

    public GameObject[] m_recievers;

    void Start () {
        items = GetComponentInParent<Items>();

        m_Channel = 1;
        Mathf.Clamp(m_Channel, 1, 5);
        currentChannel = m_Channel;
    }

    void Update () {

        if (items.currentItem == Items.ITEMTYPE.WALKYTALKY) {

            float f = Input.GetAxis("Mouse ScrollWheel");

            if (f > 0f) {
                currentChannel += 1;
            }

            if (f < 0f) {
                currentChannel -= 1;
            }
        }
	}




}

