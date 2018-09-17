using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]

public class WalkieReciever : MonoBehaviour {

    public int walkyNumber;

    private bool emittingSound;
    public float soundDuration;
    public float soundDurationMax;

    void Start () {
        GetComponent<BoxCollider>().isTrigger = true;
        walkyNumber = 0;
        emittingSound = false;
        soundDurationMax = 2;
	}
	
	void Update () {

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
                other.gameObject.GetComponent<RedPanda>()   ||
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
