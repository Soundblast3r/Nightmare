using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    //  Created By Liam Gates
    //  Updates:
    //

    Interactions interactions;
    Camera cam;
    GameObject Spraybottle;
    GameObject WalkyTalky;
    float rayDistance = 5;
    private float SphereRadius;
    public ParticleSystem Spray;

    [HideInInspector] public bool TorchActive;
    //[HideInInspector] public bool WalkyTalkyActive;

	// Use this for initialization
	void Start ()
    {
        cam = this.GetComponent<Camera>();
        interactions = GetComponent<Interactions>();
        //Spraybottle = GameObject.Find("CrocBottle");
        Spraybottle = GameObject.FindGameObjectWithTag("Spray");
        WalkyTalky = GameObject.FindGameObjectWithTag("Walky");
        Spraybottle.SetActive(false);
        WalkyTalky.SetActive(false);

        TorchActive = true;

        //if (Spray == null)
        //{
        //    Spray = GameObject.Find("CrocBottle").GetComponent<ParticleSystem>();
        //}
	}

	// Update is called once per frame
	void Update ()
    {
        if(Input.GetMouseButton(0))
        {
            if(interactions.SprayBottleActive == true)
            {
                SprayBottle();
            }

        }

        if (Input.GetKey(KeyCode.Alpha1))
        {
            //Debug.Log("Torch");
            Spraybottle.SetActive(false);
            WalkyTalky.SetActive(false);
            TorchActive = true;
        }

        if (Input.GetKey(KeyCode.Alpha2))
        {
            //set everything else to false
            if (interactions.SprayBottleActive == true)
            {
                TorchActive = false;
                WalkyTalky.SetActive(false);
                if (Spraybottle != null)
                {
                    Spraybottle.SetActive(true);
                }
            }
        }

        if (Input.GetKey(KeyCode.Alpha3))
        {
            if (interactions.WalkyTalkyActive == true)
            {
                TorchActive = false;
                Spraybottle.SetActive(false);
                if (WalkyTalky != null)
                {
                    WalkyTalky.SetActive(true);
                }
            }
        }
    }


    void SprayBottle()
    {
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        //if(Physics.Raycast(ray, out hit, rayDistance))
        if (Physics.SphereCast(ray, SphereRadius, out hit, rayDistance))
        {
            if(hit.collider.tag == "Plushie" && interactions.SprayBottleActive == true)
            {
                //do something
                //Debug.Log("Squek");
                if (!Spray.isPlaying)
                {
                    if (Spray != null)
                    {
                        Spray.Play();
                    }
                }
            }
        }
    }

    void TalkyWalky()
    {
        //Play sound From the audio sorce
        //I'll figure out a way to change the channls later
    }
}