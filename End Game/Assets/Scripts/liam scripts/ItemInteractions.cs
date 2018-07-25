using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteractions : MonoBehaviour
{
    public Camera camera;
    public float rayDistance;
    public float Distance;

    public GameObject target;

    CursorLockMode cursorLock;

    bool SprayBottleActive = false;
    bool WalkyTalkyActive = false;

	// Use this for initialization
	void Start ()
    {
        cursorLock = CursorLockMode.Locked;
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            cursorLock = CursorLockMode.None;
        }
	}

    void Interact()
    {
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            if(hit.collider.tag == "Pickup")
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

            if(hit.collider.tag == "Hideable")
            {
                Debug.Log("Can Hide Here");
                target = hit.collider.gameObject;

                camera.transform.position = target.transform.position;
            }
        }
    }

}
