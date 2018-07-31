using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

//=================================================================================
// Script written by: Edward Ngo
//=================================================================================

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(NavMeshAgent))]

public class NPC : MonoBehaviour {

    public bool isSearching;

    public Transform[] patrolPoints;
    public Transform playerKillPos;

    // countdowns/timer
    public float timeToTransform;
    public float TransformedTimer = 10;
    public float timeToRevert;
    public float revertTimer = 30;

    public bool inToyForm;
    
    void Start () {
        isSearching = false;
        inToyForm = true;
    }

    void Update() {

    }

    
    /*
    public virtual void DemonForm() {
        NMA.isStopped = false;
        inToyForm = false;
        isSearching = true;
        RB.AddForce(0, 10, 0);
        this.gameObject.transform.localScale = new Vector3(2.5f, 2.5f, 2.5f); //scale size
        timeToRevert = revertTimer;
    }

    public virtual void ToyForm() {
        StopSearching();
        inToyForm = true;
        this.gameObject.transform.localScale = new Vector3(1, 1, 1); // scale size
        timeToTransform = TransformedTimer;
    }

    public virtual void FollowPlayer() {
        NMA.destination = player.transform.position;
    }

    public virtual void StopSearching() {
        RB.velocity = new Vector3(0, 0, 0);
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


    private void OnTriggerEnter(Collider other) {

        if (other.gameObject == player && !inToyForm) {
            StopSearching();
            KillPlayer();
        }
    }
    */

}
