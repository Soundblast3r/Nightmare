using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class TeddyBear : NPC {

    private GameObject player;
    private Rigidbody RB;
    private NavMeshAgent NMA;

    private bool ReachedTarget = false;
    private Vector3 SeekPosition = Vector3.zero;
    private int PatrolIterator = 0;

    void Start () {
        RB = GetComponent<Rigidbody>();
        NMA = GetComponent<NavMeshAgent>();
        player = GameObject.Find("FPSController");

        timeToTransformMax = 0;
        timeToRevertMax = 30;

        timeToTransform = timeToTransformMax;
        //timeToRevert = timeToRevertMax;

        isSearching = false;
        inToyForm = true;

        SeekPosition = transform.position;
        NMA.SetDestination(SeekPosition);
    }

    void Update() {
        //=================================================================================
        // Countdowns and timers
        //=================================================================================

        // Countdown to demon form
        if (timeToTransform >= 0 && inToyForm) {
            timeToTransform -= Time.deltaTime;
        }

        //// In demon form, countdown to toy form
        //if (timeToRevert >= 0 && !inToyForm) {
        //    timeToRevert -= Time.deltaTime;
        //}

        //=================================================================================
        // Timers  while in toy/demon form
        //=================================================================================

        // when in TOY form, and not 'taken care of' and countdown reaches 0, transform to demon
        if (timeToTransform <= 0 && inToyForm) {
            DemonForm();
        }

        // when in DEMON form, and conditions met, turns back to toy form
        //if (timeToRevert <= 0 && !inToyForm) {
        //    ToyForm();
        //}


        ReachedTarget = NMA.remainingDistance < 0.2f;
        if (isSearching)
        {
            Patrol();
        }
        else if (!isSearching && inToyForm)
        {
            StopSearching();
        }
    }
    
    public void DemonForm() {
        NMA.isStopped = false;
        inToyForm = false;
        isSearching = true;
        RB.AddForce(0, 10, 0);
        this.gameObject.transform.localScale = new Vector3(2.5f, 2.5f, 2.5f); //scale size
        //timeToRevert = timeToRevertMax;
    }

    public void ToyForm() {
        StopSearching();
        inToyForm = true;
        this.gameObject.transform.localScale = new Vector3(1, 1, 1); // scale size
        timeToTransform = timeToTransformMax;
    }

    public void FollowPlayer() {
        NMA.destination = player.transform.position;
    }

    public void StopSearching() {
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

        if (ReachedTarget)
        {

            if (PatrolIterator >= patrolPoints.Length)
            {
                // Wrap index in case of overflow.
                PatrolIterator = 0;
            }

            Debug.Log(patrolPoints[PatrolIterator]);
            NMA.SetDestination(patrolPoints[PatrolIterator].position);
            PatrolIterator++;
            PatrolIterator %= patrolPoints.Length;
            //ReachedTarget = false;
        }
    }


    private void OnTriggerEnter(Collider other) {

        if (other.gameObject == player && !inToyForm) {
            StopSearching();
            KillPlayer();
        }
    }


}
