using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class RedPanda : NPC
{
    private GameObject player;
    private GameObject Player;
    private GameObject origen;
    public GameObject[] hidding;
    private Rigidbody RB;
    private NavMeshAgent NMA;
    private int rand;

    private float timeCheck;
    public float counter;
    private float VisDist = 10;

    private float rayDistance;
    private float SphereRadius;
    private Vector3 Origen;

    [HideInInspector] public bool isRunning;

    //Interactions cam;
    GameManager game;

    void Start()
    {
        RB = GetComponent<Rigidbody>();
        NMA = GetComponent<NavMeshAgent>();
        player = GameObject.Find("FPSController");

        game = GameObject.Find("GameManager").GetComponent<GameManager>();
        origen = GameObject.Find("Origen");
        hidding = GameObject.FindGameObjectsWithTag("Hideable");

        Player = GameObject.FindGameObjectWithTag("Player");
        hidding = GameObject.FindGameObjectsWithTag("Hideable");

        isRunning = false;
        timeCheck = 1000.0f;
        counter = timeCheck;

        rayDistance = 15;
        SphereRadius = 2.0f;

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

        if (counter <= 0)
        {
            counter = timeCheck;
            MoveToOrigen();
        }
        counter--;

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

    public void Sense()
    {
        RaycastHit hit;
        Origen = transform.position;

        if (Physics.SphereCast(Origen, SphereRadius, transform.forward, out hit))
        {
            for (int i = 0; i < hidding.Length; i++)
            {
                if (hidding[i] == gameObject)
                {
                    Search();
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Debug.DrawLine(Origen, Origen + transform.forward * VisDist);
    }
}
