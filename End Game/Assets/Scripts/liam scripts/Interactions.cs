using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Interactions : MonoBehaviour
{
    //Raycast Pickups
    public Camera camera;
    public float rayDistance;
    //public float Distance;

    //Items items;

    //Camera Rotations
    private float RotatY;
    //private float Vertical = 0.0f;
    //private float Horizontal = 0.0f;
    public float lookSpeed;
    public float MaxRotation;
    public float MinRotation;

    // Camera
    private Vector3 OrigionalCameraPos;

    public GameObject target;
    public Camera mainCamera;
    public Camera HideCamera;
    //CursorLockMode cursorLock;
    
    //if cheack Bools 
    [HideInInspector] public bool SprayBottleActive;
    [HideInInspector] public bool WalkyTalkyActive;

    bool isHiding;
	// Use this for initialization
	void Start ()
    {
        //cursorLock = CursorLockMode.Locked;
        mainCamera = this.GetComponent<Camera>();
        HideCamera = GameObject.Find("HideCamera").GetComponent<Camera>();
        //items = GetComponent<Items>();
        mainCamera.enabled = true;
        HideCamera.enabled = false;

        SprayBottleActive = false;
        WalkyTalkyActive = false;

        OrigionalCameraPos = camera.transform.localPosition;

        isHiding = false;
	}

    // Update is called once per frame
    void FixedUpdate()
    {
        //Changes the controlls if you're hiding
        if(isHiding)
        {
            HiddenMove();
        }

        //Interactions
        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact();
            AnimalInteract();
        }
	}

    void Interact()
    {
        //creats a ray of specific distance between the objects you're
        //looking at the screen
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        
        //cheacks if the ray actualy hit something within a set distance
        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            //cheacks if you are able to pick up the object
            if (hit.collider.tag == "Pickup")
            {
                //sets whatever you hit as the current target
                //Debug.Log("Object hit");
                target = hit.collider.gameObject;
                //makes the world obejct invisable
                target.SetActive(false);
                if (hit.collider.name == "SprayBottle")
                {
                    //adds the obejcts to your inventory
                    SprayBottleActive = true;
                    //Debug.Log("picked up spray bottle");
                }
                if (hit.collider.name == "WalkyTalky")
                {
                    WalkyTalkyActive = true;
                    //Debug.Log("picked up Walky Talky");
                }
            }

            if(hit.collider.tag == "Climbable" && isHiding == false)
            {
                //Debug.Log("can climb this");
                target = hit.collider.gameObject;

                GameObject.Find("FPSController").transform.position = GameObject.Find("ClimbingPoint").transform.position;
            }

            //cheacks if you are able to hide in the target and
            //only if you're not alrady hiding
            if (hit.collider.tag == "Hideable" && isHiding == false)
            {
                //sets the hideable object to the current target
                //Debug.Log("Can Hide Here");
                target = hit.collider.gameObject;

                //finds scripts and colliders attached to the player and turns them off
                GameObject.Find("FPSController").GetComponent<FlashlightLean>().enabled = false;
                GameObject.Find("Character").GetComponent<CapsuleCollider>().enabled = false;
                GameObject.Find("FPSController").GetComponent<FirstPersonController>().enabled = false;

                //switches the your main camera from the plays to the hidden one
                mainCamera.enabled = false;
                HideCamera.enabled = true;
                //camera.transform.position = target.transform.position;
                //this.camera.transform.position = target.transform.position;
                //this.GetComponent<Camera>()
                
                //you are now hidding
                isHiding = true;
            }
            //if you are already hidding lets you leave the hiding place
            else if (isHiding == true)
            {
                //turns the scripts attached to the play back on
                GameObject.Find("FPSController").GetComponent<FlashlightLean>().enabled = true;
                GameObject.Find("Character").GetComponent<CapsuleCollider>().enabled = false;
                GameObject.Find("FPSController").GetComponent<FirstPersonController>().enabled = true;

                //changes the main camera back to players from the hidden one
                mainCamera.enabled = true;
                HideCamera.enabled = false;

                //you are no longer hidding
                isHiding = false;
            }
        }
    }

    void AnimalInteract()
    {
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit, rayDistance))
        {
            if (hit.collider.tag == "Plushie")
            {
                if(hit.collider.name == "Ted Bear")
                {
                    Debug.Log("Play: Giving Bear, tea animation");
                }

                if(hit.collider.name == "Owl")
                {
                    Debug.Log("Play: Winding Owl animation");
                }

                if(hit.collider.name == "RedPanda")
                {
                    Debug.Log("Play: Peting Red Panda animation");
                }
            }
        }
    }

    void HiddenMove()
    {
        Vector3 Angles = HideCamera.transform.localEulerAngles;
        //gets the mouse input to rotate the camera
        RotatY = lookSpeed * Input.GetAxis("Mouse X") /* Time.deltaTime*/;
        //RotatX = lookSpeed * Input.GetAxis("Mouse X") /* Time.deltaTime*/;

        //clamps the camera to a certain preset rainge
        RotatY = Mathf.Clamp(Angles.y + RotatY, MinRotation, MaxRotation);
        //RotatX = Mathf.Clamp(Angles.x + RotatX, MinRotation, MaxRotation);

        //changes the cameras rotation using the
        //previusly set horizontal and vertical axis
        HideCamera.transform.localEulerAngles = new Vector3(Angles.x, RotatY, Angles.z);
        //HideCamera.transform.Rotate(RotatY, RotatX, 0.0f);

        //Debug.Log("Horizontal");
        //Debug.Log("Vertical");
    }
}