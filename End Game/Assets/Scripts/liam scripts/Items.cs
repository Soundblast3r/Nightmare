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
    Camera camera;
    GameObject Spraybottle;
    float rayDistance = 5;
    
	// Use this for initialization
	void Start ()
    {
        camera = this.GetComponent<Camera>();

        interactions = GetComponent<Interactions>();
        Spraybottle = GameObject.Find("SprayBottle");

	}

	// Update is called once per frame
	void FixedUpdate ()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            //Debug.Log("Torch");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            //set everything else to false
            Debug.Log(interactions.SprayBottleActive);
            if (interactions.SprayBottleActive == true)
            {
                //SprayBottle();
                Spraybottle.SetActive(true);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            //Debug.Log("Walky Talky");
        }
    }


    void SprayBottle()
    {
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit, rayDistance))
        {
            if(hit.collider.tag == "plushi" && interactions.SprayBottleActive == true)
            {
                //do something
                
            }
        }
    }
}