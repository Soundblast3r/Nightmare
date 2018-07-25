using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

//=================================================================================
// Script written by: Edward Ngo
//=================================================================================

public class NPC : MonoBehaviour {

    private GameObject player;
    private GameObject playerCam;
    private NavMeshAgent NMA;
    private Rigidbody rb;

    public bool isSearching;
    private Image hello;

    public Transform[] patrolPoints;
    public Transform playerKillPos;

    // countdowns/timer
    public float demonTransformCountdown; // time until toy transforms
    public float demonFormCountdown;      // time until demon form ends

    public bool inToyForm;
    
    // Use this for initialization
    void Start () {
        NMA = GetComponent<NavMeshAgent>();
        player = GameObject.Find("PLAYER1");
        //playerCam = GameObject.Find("FPSController");
        rb = GetComponent<Rigidbody>();
        isSearching = false;
        demonTransformCountdown = 10;
        demonFormCountdown = 10;
        inToyForm = true;

    }

    // Update is called once per frame
    void Update() {

        //=================================================================================
        // Countdowns and timers
        //=================================================================================
        
        // Countdown to demon form
        if (demonTransformCountdown >= 0 && inToyForm) {
            demonTransformCountdown -= Time.deltaTime;
        }

        // In demon form, countdown to toy form
        if (demonFormCountdown >= 0 && !inToyForm) {
            demonFormCountdown -= Time.deltaTime;
        }

        //=================================================================================
        // Timers  while in toy/demon form
        //=================================================================================
        
        // when in TOY form, and not 'taken care of' and countdown reaches 0, transform to demon
        if (demonTransformCountdown <= 0 && inToyForm) {
            DemonForm();
        }

        // when in DEMON form, and conditions met, turns back to toy form
        if (demonFormCountdown <= 0 && !inToyForm) {
            ToyForm();
        }

        // CONTINUOUSLY FOLLOW PLAYER
        if (isSearching && !inToyForm) {
            FollowPlayer();
        }
        else if (!isSearching && inToyForm) {
            StopSearching();
        }
        
        // TO SEARCH LAST KNOWN PLAYER POS OR 'DISTRACTION' , CALL FollowPlayer()
    }

    // FUNCIONS 

    public void DemonForm() {
        demonFormCountdown = 10;
        NMA.isStopped = false;
        inToyForm = false;
        isSearching = true;
        rb.AddForce(0, 10, 0);
        this.gameObject.transform.localScale = new Vector3(5, 5, 5);

    }

    public void ToyForm() {
        StopSearching();
        demonTransformCountdown = 10;
        inToyForm = true;
        this.gameObject.transform.localScale = new Vector3(1, 1, 1);
    }

    public void FollowPlayer() {
        NMA.destination = player.transform.position;
    }

    public void StopSearching() {
        rb.velocity = new Vector3(0, 0, 0);
        NMA.isStopped = true;
        isSearching = false;
    }

    public void KillPlayer() {
        // CALL CAMERA FUNTION FROM PLAYER SCRIPT
        // PUT PLAYER INFRONT OF MONSTER
        //playerCam.transform.position = playerKillPos.position;

        // GET PLAYER TO FACE MONSTER
        //I AM HERE

        // PLAY KILL ANIMATION

        // SET GAMEOVER THINGS
    }

    public void Patrol() {
        // DO PATROL STUFF
    }

    private void ResetTimer() {
        demonTransformCountdown = 10;
    }

    private void OnTriggerEnter(Collider other) {

        if (other.gameObject == player && isSearching) {
            StopSearching();
            KillPlayer();
        }
    }

}
