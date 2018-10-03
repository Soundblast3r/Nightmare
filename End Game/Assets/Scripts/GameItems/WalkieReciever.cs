using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(BoxCollider))]

public class WalkieReciever : MonoBehaviour {

    private GameObject playerCam;
    private GameObject displayWalkyNumber;
    private bool displayNumberSet = false;

    public int walkyNumber;

    private bool emittingSound;
    public float soundDuration;
    public float soundDurationMax;

    void Start () {
        playerCam = GameObject.Find("FirstPersonCharacter");
        displayWalkyNumber = transform.Find("Canvas/displayChannelNumber").gameObject;
        GetComponent<BoxCollider>().isTrigger = true;
        walkyNumber = 0;
        emittingSound = false;
        soundDurationMax = 2;
	}
	
	void Update () {

        if (!displayNumberSet) {
            displayWalkyNumber.GetComponent<Text>().text = walkyNumber.ToString();
            displayNumberSet = true;
        }

        if (displayNumberSet) { // rotates on all axis instead of only Y, need fix?
            displayWalkyNumber.transform.LookAt(playerCam.transform.position);
        }

        if (emittingSound && soundDuration >= 0) {
            soundDuration -= Time.deltaTime;
        }

        if (soundDuration <= 0) {
            emittingSound = false;
        }
	}

    private void OnTriggerStay(Collider other) {
        if (emittingSound) {
            if (other.gameObject.GetComponent<Crocodile>()  ||
                other.gameObject.GetComponent<Owl>()        ||
                other.gameObject.GetComponent<TeddyBear>()) {

                // CALL DISTRACT FUNCTION WHEN ITS READY          
            }
        }
    }

    public void SetCurrentChannel(int val) {
        walkyNumber = val;
    }

    public int GetChannel() {
        return walkyNumber;
    }

    public void PlaySound() {
        soundDuration = soundDurationMax;
        emittingSound = true;
        Debug.Log("HELLO FROM RECIEVER " + walkyNumber);

        //PLAY DISTORTED AUDIO HERE
    }

}
