using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    //  Created By Liam Gates
    //  Updates:
    //
    Interactions interactions;
    Camera camera;
    GameObject Spraybottle;
    float rayDistance = 5;
    
	// Use this for initialization
	void Start ()
    {
        Spraybottle = GameObject.Find("SprayBottle");
        //interactions.SprayBottleActive;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("Torch");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            //set everything else to false
            Debug.Log("Spray Bottle");
            SprayBottle();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Debug.Log("Walky Talky");
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
                Spraybottle.SetActive(true);
            }
        }
    }
}