using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//=======================================================
// Created by: Edward Ngo
// Contributors:
//=======================================================

public class WalkieTalkie : MonoBehaviour {

    private Items items;
    public GameObject[] m_recievers;
    public GameObject currentReciever;

    private int m_Channel;
    public int currentChannel;

    public bool isChannelSet;
    private int minChannel = 1;
    private int maxChannel;
    private int prevChannel = 0;

    void Start () {

        items = GetComponent<Items>();

        m_Channel = 1;
        currentChannel = m_Channel;

        maxChannel = m_recievers.Length;

        isChannelSet = false;
    }

    void Update () {

        // Set channels
        if (!isChannelSet) {
            for (int i = 0; i < maxChannel; i++) {
                m_recievers[i].GetComponent<WalkieReciever>().SetCurrentChannel(i + 1);
            }

            isChannelSet = true;
        }

        if (items.currentItem == Items.ITEMTYPE.WALKYTALKY) {

            // Detect scroll wheel to change channel
            float f = Input.GetAxis("Mouse ScrollWheel");

            if (f > 0f && currentChannel < maxChannel) {
                currentChannel += 1;
                isChannelSet = false;
            }

            if (f < 0f && currentChannel > minChannel) {
                currentChannel -= 1;
                isChannelSet = false;
            }

            // SET Current Reciever depending on channel
            if (prevChannel != currentChannel) {
                for (int i = 0; i < maxChannel; i++) {
                    if (currentChannel == m_recievers[i].GetComponent<WalkieReciever>().GetChannel()) {
                        SetCurrentReciever(m_recievers[i]);
                        prevChannel = currentChannel;
                    }
                }
            }
        }
	}

    private void SetCurrentReciever(GameObject go) {
        currentReciever = go;
    }

    public void MakeNoise() {
        currentReciever.GetComponent<WalkieReciever>().PlaySound();
    }
    


}

