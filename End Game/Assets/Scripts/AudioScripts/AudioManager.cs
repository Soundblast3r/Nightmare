using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//=======================================================
//  Created By Edward Ngo
//  Updates:
//=======================================================

    [RequireComponent(typeof(AudioSource))]

public class AudioManager : MonoBehaviour {

    private GameManagerScript gameManager;
    private AudioSource currentAudio;
    private AudioSource rainSFX;
    //private Owl owl;
    private Crocodile croc;
    private TeddyBear bear;

    public AudioClip DefaultAudio;
    public AudioClip ChaseAudio;
    public AudioClip RainAudio;
    public AudioClip Thunder1;
    public AudioClip Thunder2;

    private bool isBeingChased;
    private bool isRaining;

    //public float thunderMin;
    //public float thunderMax;
    private float thunderInterval;
    private float thunderIntervalMax;

	// Use this for initialization
	void Start () {
        gameManager = GameObject.Find("GameUI").GetComponent<GameManagerScript>();
        rainSFX = GetComponentInChildren<AudioSource>();
        croc = GameObject.FindGameObjectWithTag("Crocodile").GetComponent<Crocodile>();
        bear = GameObject.FindGameObjectWithTag("Bear").GetComponent<TeddyBear>();
        //owl = GameObject.FindGameObjectWithTag("Owl").GetComponent<Owl>();

        rainSFX.clip = RainAudio;
        currentAudio.clip = DefaultAudio;
        isBeingChased = false;
        isRaining = false;

        thunderInterval = 5;
	}
	
	// Update is called once per frame
	void Update () {

        // Start bgm when game starts
        PlayBGM();

        // Play chase music when demons start hunting
        CheckHuntBGM();

        // check if tutorial has finished, if so start rain sfx
        if (gameManager.isTutorialFinished) {
            isRaining = true;
        }

        if (isRaining) {
            
            // START RAIN SFX
            if (!rainSFX.isPlaying) {
                rainSFX.Play();
                rainSFX.PlayOneShot(Thunder1);
            }

            // PLAY THUNDER TIMER AT INTERVALS
            if (thunderInterval > 0) {
                thunderInterval -= Time.deltaTime;
            }

            if (thunderInterval <= 0) {
                PlayThunder();
            }
        }
        

	}

    void PlayBGM() {
        if (!currentAudio.isPlaying && !isBeingChased) {
            if (currentAudio.clip != DefaultAudio) {
                currentAudio.clip = DefaultAudio;
                currentAudio.loop = true;
            }
        }

        if (isBeingChased) {
            if (currentAudio.clip != ChaseAudio) {
                currentAudio.clip = ChaseAudio;
                currentAudio.loop = true;
            }
        }
    }

    void CheckHuntBGM() {
        if (croc.isHunting || bear.isHunting) {
            if (!isBeingChased) {
                isBeingChased = true;
            }
        }

        if (!croc.isHunting && !bear.isHunting) {
            if (isBeingChased) {
                isBeingChased = false;
            }
        }
    }


    void PlayThunder() {
        int rand = Random.Range(1, 2);

        if (rand == 1) {
            rainSFX.PlayOneShot(Thunder1);
            Debug.Log("thunder1 played");
        }

        if (rand == 2) {
            rainSFX.PlayOneShot(Thunder2);
            Debug.Log("thunder2 played");
        }

        thunderInterval = Random.Range(5, 15);
    }
}
