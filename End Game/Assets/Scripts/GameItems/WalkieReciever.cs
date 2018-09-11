using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkieReciever : MonoBehaviour {

    public int walkyNumber;

    private bool emittingSound;
    public float soundDuration;
    public float soundDurationMax;

	void Start () {

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
            if (other.gameObject.GetComponent<Crocodile>() ||
                other.gameObject.GetComponent<Crocodile>() ||
                other.gameObject.GetComponent<Crocodile>() ||
                other.gameObject.GetComponent<Crocodile>()) {

                // AGGRO/DISTRACT temporarily
                
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
    }

}
