using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class RedPanda : NPC
{
    private GameObject player;
    private GameObject origen;
    private Rigidbody RB;
    private NavMeshAgent NMA;
    private int rand;

    Interactions cam;
    GameManager game;


    void Start()
    {
        RB = GetComponent<Rigidbody>();
        NMA = GetComponent<NavMeshAgent>();
        player = GameObject.Find("FPSController");

        game = GameObject.Find("GameManager").GetComponent<GameManager>();
        origen = GameObject.Find("Origen");

        
        //timeToTransformMax = 30;
        //timeToRevertMax = 30;

        //timeToTransform = timeToTransformMax;
        //timeToRevert = timeToRevertMax;

        isSearching = false;
        //inToyForm = true;
    }

    void Update()
    {
        //=================================================================================
        // Countdowns and timers
        //=================================================================================

        //// Countdown to demon form
        //if (timeToTransform >= 0 && inToyForm) {
        //    timeToTransform -= Time.deltaTime;
        //}

        //// In demon form, countdown to toy form
        //if (timeToRevert >= 0 && !inToyForm) {
        //    timeToRevert -= Time.deltaTime;
        //}

        //=================================================================================
        // Timers  while in toy/demon form
        //=================================================================================

        // when in TOY form, and not 'taken care of' and countdown reaches 0, transform to demon
        //if (timeToTransform <= 0 && inToyForm) {
        //    DemonForm();
        //}

        //// when in DEMON form, and conditions met, turns back to toy form
        //if (timeToRevert <= 0 && !inToyForm) {
        //    ToyForm();
        //}
    }

    public void FixedUpdate()
    {
        //if (isSearching && !inToyForm) {
        //    FollowPlayer();
        //}
        //else if (!isSearching && inToyForm) {
        //    StopSearching();
        //}
    }

    public void DemonForm()
    {
        NMA.isStopped = false;
        //inToyForm = false;
        isSearching = true;
        RB.AddForce(0, 10, 0);
        this.gameObject.transform.localScale = new Vector3(2.5f, 2.5f, 2.5f); //scale size
        timeToRevert = timeToRevertMax;
    }

    public void ToyForm()
    {
        StopSearching();
        //inToyForm = true;
        this.gameObject.transform.localScale = new Vector3(1, 1, 1); // scale size
        timeToTransform = timeToTransformMax;
    }
    
    public void FollowPlayer()
    {
        NMA.destination = player.transform.position;
    }

    public void MoveToOrigen()
    {
        isSearching = false;
        isHunting = false;
        NMA.destination = origen.transform.position;
    }

    public void StopSearching()
    {
        RB.velocity = new Vector3(0, 0, 0);
        NMA.isStopped = true;
        isSearching = false;
    }

    public void KillPlayer()
    {
        // CALL CAMERA FUNTION FROM PLAYER SCRIPT
        // PUT PLAYER INFRONT OF MONSTER
        //playerCam.transform.position = playerKillPos.position;

        // GET PLAYER TO FACE MONSTER
        //I AM HERE

        // PLAY KILL ANIMATION
        game.isGameOver = true;
        // SET GAMEOVER THINGS
    }

    public void Search()
    {
        //DO SEARCH STUFF
        rand = Random.Range(0, 1);

        if(rand <= 0.5)
        {
            Debug.Log("Checked Hidding place");
        }
        else
        {
            Debug.Log("Didnt check hidding place");
        }
    }

    public void Distracted()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            StopSearching();
            KillPlayer();
        }
    }
}
