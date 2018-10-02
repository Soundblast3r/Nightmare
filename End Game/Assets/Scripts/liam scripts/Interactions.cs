using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

//=======================================================
//  Created By Liam Gates
//  Updates: Edward ngo
//=======================================================

public class Interactions : MonoBehaviour
{
    private Items items;
    private InfoDisplay infoDisplay;

    //Raycast Pickups
    public Camera Cam;
    public float rayDistance;
    private float RayLine = 15f;
    private float SphereRadius;

    private Vector3 origin;
    private Owl Demon;
    //Camera Rotations
    private float RotateY;
    //private float Vertical = 0.0f;
    //private float Horizontal = 0.0f;
    public float lookSpeed;
    public float MaxRotation;
    public float MinRotation;

    // Camera
    private Vector3 OriginalCameraPos;
    public GameObject target;
    public Camera mainCamera;
    public Camera HideCamera;
    //CursorLockMode cursorLock;
    
    public bool isHiding;
	// Use this for initialization
	void Start ()
    {
        //cursorLock = CursorLockMode.Locked;
        mainCamera = this.GetComponent<Camera>();
        HideCamera = GameObject.Find("HideCamera").GetComponent<Camera>();
        infoDisplay = GameObject.Find("GameUI").GetComponent<InfoDisplay>();
        Demon = GameObject.FindGameObjectWithTag("Owl").GetComponent<Owl>();
        items = GetComponent<Items>();
        mainCamera.enabled = true;
        HideCamera.enabled = false;

        //SprayBottleActive = false;
        //WalkyTalkyActive = false;

        OriginalCameraPos = Cam.transform.localPosition;

        SphereRadius = 0.10f;
        isHiding = false;
	}

    // Update is called once per frame
    void Update()
    {
        //TorchLine();
        //Changes the controlls if you're hiding
        if (isHiding)
        {
            HiddenMove();
        }

        //Interactions
        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact();
            AnimalInteract();
        }

        LookAt();


	}

    void Interact()
    {
        //creats a ray of specific distance between the objects you're
        //looking at the screen
        RaycastHit hit;
        Ray ray = Cam.ScreenPointToRay(Input.mousePosition);
        
        //cheacks if the ray actualy hit something within a set distance
        /*if (Physics.SphereCast(ray, SphereRadius, out hit, rayDistance))*/
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
                    items.BottleAcquired = true;
                    //Debug.Log("picked up spray bottle");
                }
                if (hit.collider.name == "WalkyTalky")
                {
                    items.WalkyAcquired = true;
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
        Ray ray = Cam.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit, rayDistance))
        {
            if (hit.collider.tag == "Plushie")
            {
                if(hit.collider.name == "Ted Bear")
                {
                    //Play Giving Bear tea animation
                }

                if(hit.collider.name == "Owl")
                {
                    //Play Winding Owl animation
                }
            }
        }
    }

    void HiddenMove()
    {
        Vector3 Angles = HideCamera.transform.localEulerAngles;
        //gets the mouse input to rotate the camera
        RotateY = lookSpeed * Input.GetAxis("Mouse X") /* Time.deltaTime*/;
        //RotatX = lookSpeed * Input.GetAxis("Mouse X") /* Time.deltaTime*/;

        //clamps the camera to a certain preset rainge
        RotateY = Mathf.Clamp(Angles.y + RotateY, MinRotation, MaxRotation);
        //RotatX = Mathf.Clamp(Angles.x + RotatX, MinRotation, MaxRotation);

        //changes the cameras rotation using the
        //previusly set horizontal and vertical axis
        HideCamera.transform.localEulerAngles = new Vector3(Angles.x, RotateY, Angles.z);
        //HideCamera.transform.Rotate(RotatY, RotatX, 0.0f);

        //Debug.Log("Horizontal");
        //Debug.Log("Vertical");
    }

    void LookAt() {

        RaycastHit hit;
        Ray ray = Cam.ScreenPointToRay(Input.mousePosition);

        //if (Physics.SphereCast(ray, SphereRadius, out hit, rayDistance)) {
        if (Physics.Raycast(ray, out hit, rayDistance)) {
            if (hit.collider.tag == "Pickup") {
                infoDisplay.DisplayTooltip("Take " + hit.collider.name);
            }

            if (hit.collider.tag == "Reciever") {
                GameObject temp = hit.collider.gameObject;
                infoDisplay.DisplayTooltip("reciever " + temp.GetComponent<WalkieReciever>().walkyNumber);
            }

            if (hit.collider.tag == "Hideable" && !isHiding) {
                infoDisplay.DisplayTooltip("Hide in " + hit.collider.name);
            }

            if (hit.collider.tag == "Plushie") {
                GameObject temp = hit.collider.transform.parent.gameObject;
                infoDisplay.DisplayTooltip(temp.tag.ToString());
            }

        }

        // CHECKS IF NOT LOOKING AT OBJECT, CLEARS TOOLTIP
        // ADD ITEMS THAT CAN BE DISPLAYED ON TOOLTIP HERE
       if (Physics.Raycast(ray, out hit, 100)) {
           if (hit.collider.tag != "Pickup" && hit.collider.tag != "Hideable" && hit.collider.tag != "Plushie" &&
               hit.collider.tag != "Reciever" &&
              (hit.collider.tag != "Crocodile" || hit.collider.tag != "RedPanda" || hit.collider.tag != "Owl" || hit.collider.tag != "Bear" ))  {
               infoDisplay.ClearTooltip();
           }
       }
    }

    public void TorchLine()
    {
        RaycastHit point;
        Ray torchline = Cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(torchline, out point, RayLine))
        {
            if (point.collider.tag == "Owl")
            {
                target = point.collider.gameObject;
                Demon.StopSearching();
                //Debug.Log(target);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        origin = transform.position;
        Gizmos.color = Color.red;
        Debug.DrawLine(origin, origin + transform.forward * RayLine);
    }
}