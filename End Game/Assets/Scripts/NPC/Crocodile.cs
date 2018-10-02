using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Crocodile : NPC
{
    private float VisDist = 10;
    private float SphereRadius;
    private Vector3 origen;
    private float MoveSpeed;

    GameManagerScript game;

    //private GameObject Toy;
    private Collider coll;
    //private MeshRenderer render;


    //public GameObject plushieCroc;
    private GameObject player;
    private Rigidbody RB;
    private NavMeshAgent NMA;

    private bool ReachedTarget = false;
    private Vector3 SeekPosition = Vector3.zero;
    private int PatrolIterator = 0;

    private GameObject toyCroc;

    void Start()
    {
        RB = GetComponent<Rigidbody>();
        NMA = GetComponent<NavMeshAgent>();
        player = GameObject.Find("FPSController");
        //Toy = GameObject.FindGameObjectWithTag("Plushie");
        //Nightmare = GameObject.FindGameObjectWithTag("Nightmare");
        //render = this.GetComponentInChildren<MeshRenderer>();

        game = GameObject.Find("GameManager").GetComponent<GameManagerScript>();

        transform.GetChild(0).gameObject.SetActive(false);
        coll = GetComponent<Collider>();
        coll.enabled = !coll.enabled;

        timeToTransformMax = 30;
        timeToRevertMax = 30;
        SphereRadius = 2.0f;
        MoveSpeed = 10f;

        timeToTransform = timeToTransformMax;
        timeToRevert = timeToRevertMax;

        isSearching = false;
        //inToyForm = true;

        //Nightmare.SetActive(false);

        SeekPosition = transform.position;
        NMA.SetDestination(SeekPosition);

        toyCroc = GameObject.Find("PlushieCroc");
    }

    void Update()
    {
        //=================================================================================
        // Countdowns and timers
        //=================================================================================

        // Countdown to demon form
        if (timeToTransform >= 0 && game.isTutorialFinished)
        {
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
        if (timeToTransform <= 0 && !isSearching )
        {
            DemonForm();
        }

        //// when in DEMON form, and conditions met, turns back to toy form
        //if (timeToRevert <= 0 && !inToyForm) {
        //    ToyForm();
        //}

        ReachedTarget = NMA.remainingDistance < 0.2f;
        VisualRange();
        if(isHunting)
        {
            FollowPlayer();
        }
        if(isSearching && !isHunting)
        {
            Patrol();
        }
    }
    
    public void DemonForm()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        transform.GetChild(1).gameObject.SetActive(false);
        //plushieCroc.SetActive(false);
        coll.enabled = !coll.enabled;
        NMA.isStopped = false;
        //inToyForm = false;
        isSearching = true;
        RB.AddForce(0, MoveSpeed, 0);
        this.gameObject.transform.localScale = new Vector3(scale, scale, scale); //scale size
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
        //RB.AddForce(player.transform.position, ForceMode.Acceleration);
        NMA.speed = 1000;
        NMA.destination = player.transform.position;
        //MoveSpeed = 100;
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
    
    public void Patrol()
    {
        // DO PATROL STUFF

        if (ReachedTarget)
        {

            if(PatrolIterator >= patrolPoints.Length)
            {
                //Wrap index in case of overflow
                PatrolIterator = 0;
            }

            //Debug.Log(patrolPoints[PatrolIterator]);
            NMA.SetDestination(patrolPoints[PatrolIterator].position);
            PatrolIterator++;
            PatrolIterator %= patrolPoints.Length;
        }
    }
    
    public void VisualRange()
    {
        RaycastHit hit;
        origen = transform.position;

        if (Physics.SphereCast(origen, SphereRadius, transform.forward, out hit))
        {
            if (hit.collider.tag == "Player" && isSearching)
            {
                isSearching = false;
                isHunting = true;
            }
            else if (hit.collider.tag != "Player" && isHunting)
            {
                isHunting = false;
                isSearching = true;
                NMA.speed = 5f;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StopSearching();
            KillPlayer();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Debug.DrawLine(origen, origen + transform.forward * VisDist);
        Gizmos.DrawWireSphere(origen + transform.forward * VisDist, SphereRadius);
    }

    public override void PlayFeedback()
    {
        if (toyCroc.activeInHierarchy && !FeedbackParticle.isPlaying)
        {
            FeedbackParticle.Play();
        }
    }
}
