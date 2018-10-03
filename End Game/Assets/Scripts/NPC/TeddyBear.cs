using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class TeddyBear : NPC
{
    //private GameObject VisRange;
    private float VisDist = 10;
    private float SphereRadius;
    private Vector3 origen;

    private GameObject player;
    private Rigidbody RB;
    private NavMeshAgent NMA;

    GameManagerScript game;
    MeshRenderer Render;
    private Collider coll;

    private bool ReachedTarget = false;
    private Vector3 SeekPosition = Vector3.zero;
    private int PatrolIterator = 0;

    void Start () {
        RB = GetComponent<Rigidbody>();
        NMA = GetComponent<NavMeshAgent>();
        player = GameObject.Find("FPSController");
        //VisRange = GameObject.FindGameObjectWithTag("VisualRange");

        game = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>();

        Render = gameObject.GetComponent<MeshRenderer>();
        Render.enabled = false;
        coll = GetComponent<Collider>();
        coll.enabled = !coll.enabled;

        timeToTransformMax = 30;
        //timeToRevertMax = 30;
        SphereRadius = 2.0f;

        timeToTransform = timeToTransformMax;
        //timeToRevert = timeToRevertMax;

        isSearching = false;
        //inToyForm = true;

        SeekPosition = transform.position;

    }

    void Update() {
        //=================================================================================
        // Countdowns and timers
        //=================================================================================

        //Debug.Log(timeToTransform);
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
        if (timeToTransform <= 0)
        {
            DemonForm();
            //VisRange.SetActive(true);
        }

        // when in DEMON form, and conditions met, turns back to toy form
        //if (timeToRevert <= 0 && !inToyForm) {
        //    ToyForm();
        //}

        ReachedTarget = NMA.remainingDistance < 0.2f;
        VisualRange();
        if (isHunting)
        {
            FollowPlayer();
        }
        if (isSearching)
        {
            Patrol();
        }
        //else if (!isSearching)
        //{
        //    StopSearching();
        //}
    }
    
    public void DemonForm()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        Render.enabled = true;
        coll.enabled = !coll.enabled;
        NMA.isStopped = false;
        //inToyForm = false;
        isSearching = true;
        RB.AddForce(0, 10, 0);
        this.gameObject.transform.localScale = new Vector3(scale, scale, scale); //scale size
    }

    public void ToyForm() {
        StopSearching();
        //inToyForm = true;
        this.gameObject.transform.localScale = new Vector3(1, 1, 1); // scale size
        timeToTransform = timeToTransformMax;
    }

    public void FollowPlayer()
    {
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
        game.isGameOver = true;
        // SET GAMEOVER THINGS
    }

    public void Patrol()
    {
        // DO PATROL STUFF

        if (ReachedTarget)
        {

            if (PatrolIterator >= patrolPoints.Length)
            {
                // Wrap index in case of overflow.
                PatrolIterator = 0;
            }

            //Debug.Log(patrolPoints[PatrolIterator]);
            NMA.SetDestination(patrolPoints[PatrolIterator].position);
            PatrolIterator++;
            PatrolIterator %= patrolPoints.Length;
            //ReachedTarget = false;
        }
    }

    public void VisualRange()
    {
        RaycastHit hit;
        origen = transform.position;
        //Debug.DrawRay(transform.position, transform.forward * VisDist, Color.green);
        //Debug.DrawRay(transform.position, (transform.forward + transform.right).normalized * VisDist, Color.green);
        //Debug.DrawRay(transform.position, (transform.forward - transform.right).normalized * VisDist, Color.green);

        if (Physics.SphereCast(origen, SphereRadius, transform.forward, out hit))
        {
           if (hit.collider.tag == "Player" && isSearching)
            {
                isSearching = false;
                isHunting = true;
            }
           else if (isHunting)
            {
                isHunting = false;
                isSearching = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other) {

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
}
