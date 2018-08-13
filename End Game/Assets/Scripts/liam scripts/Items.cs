using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    //  Created By Liam Gates
    //  Updates:
    //
    //[HideInInspector] public bool SprayBottleActive;
    //[HideInInspector] public bool WalkyTalkyActive;

    Interactions interactions;
    Camera cam;
    GameObject Spraybottle;
    float rayDistance = 5;
    
	// Use this for initialization
	void Start ()
    {
        cam = this.GetComponent<Camera>();
        interactions = GetComponent<Interactions>();
        //Spraybottle = GameObject.Find("CrocBottle");
        Spraybottle = GameObject.FindGameObjectWithTag("Spray");
        Spraybottle.SetActive(false);
	}

	// Update is called once per frame
	void Update ()
    {
        if(Input.GetMouseButton(0))
        {
            SprayBottle();
        }

        if (Input.GetKey(KeyCode.Alpha1))
        {
            //Debug.Log("Torch");
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            //set everything else to false
            if (interactions.SprayBottleActive == true)
            {
                //SprayBottle();
                Debug.Log(interactions.SprayBottleActive);
                if (Spraybottle != null)
                {
                    Spraybottle.SetActive(true);
                }
            }
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            Debug.Log("malk");
        }
    }


    void SprayBottle()
    {
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit, rayDistance))
        {
            if(hit.collider.tag == "Plushie" && interactions.SprayBottleActive == true)
            {
                //do something
                Debug.Log("Squek");
            }
        }
    }
}