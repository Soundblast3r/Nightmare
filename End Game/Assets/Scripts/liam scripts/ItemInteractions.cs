using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteractions : MonoBehaviour
{
    public Camera camera;
    public float rayDistance;
    public float Distance;

    private float Vertical = 0.0f;
    private float Horizontal = 0.0f;
    public float lookSpeedH;
    public float lookSpeedV;

    private Vector3 OrigionalCameraPos;
    private Vector3 currentCameraPos;

    public GameObject target;
    public Camera mainCamera;
    public Camera HideCamera;
    

    //CursorLockMode cursorLock;

    bool SprayBottleActive = false;
    bool WalkyTalkyActive = false;
    bool isHiding;

	// Use this for initialization
	void Start ()
    {
        //cursorLock = CursorLockMode.Locked;
        mainCamera = this.GetComponent<Camera>();
        HideCamera = GameObject.Find("HideCamera").GetComponent<Camera>();
        mainCamera.enabled = true;
        HideCamera.enabled = false;

        OrigionalCameraPos = camera.transform.localPosition;

        isHiding = false;
	}

    // Update is called once per frame
    void Update()
    {
        if(isHiding)
        {
            HiddenMove();
        }

        currentCameraPos = camera.transform.position;

        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }

        //if(Input.GetKeyDown(KeyCode.Escape))
        //{
        //    cursorLock = CursorLockMode.None;
        //}
	}

    void Interact()
    {
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            if (hit.collider.tag == "Pickup")
            {
                Debug.Log("Object hit");
                target = hit.collider.gameObject;
                target.SetActive(false);
                if (hit.collider.name == "Spray Bottle")
                {
                    SprayBottleActive = true;
                    Debug.Log("picked up spray bottle");
                }
                if (hit.collider.name == "Walky Talky")
                {
                    WalkyTalkyActive = true;
                    Debug.Log("picked up Walky Talky");
                }
            }

            if (hit.collider.tag == "Hideable" && isHiding == false)
            {
                Debug.Log("Can Hide Here");
                target = hit.collider.gameObject;

                GameObject.Find("FPSController").GetComponent<CustomControls>().enabled = false;
                GameObject.Find("Character").GetComponent<CapsuleCollider>().enabled = false;


                mainCamera.enabled = false;
                HideCamera.enabled = true;
                //camera.transform.position = target.transform.position;
                //this.camera.transform.position = target.transform.position;
                //this.GetComponent<Camera>()
                isHiding = true;
            }
            else if (isHiding == true)
            {
                GameObject.Find("FPSController").GetComponent<CustomControls>().enabled = true;
                GameObject.Find("Character").GetComponent<CapsuleCollider>().enabled = false;

                mainCamera.enabled = true;
                HideCamera.enabled = false;

                isHiding = false;
            }
        }
    }

    void HiddenMove()
    {
        //Input.GetAxis("Mouse X");
        //Input.GetAxis("Mouse Y");


        Horizontal += lookSpeedH * Input.GetAxis("Horizontal");
        Vertical -= lookSpeedV * Input.GetAxis("Vertical");

        //camera.transform.localPosition = currentCameraPos;

        transform.eulerAngles = new Vector3(Horizontal, Vertical, 0.0f);



    }

}