using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomControls : MonoBehaviour {

    public GameObject Flashlight;

    public bool torchSwitchLimit;
    public float FlashlightCooldownTime = 0.4f;
    // Use this for initialization
    void Start ()
    {
        Flashlight.SetActive(false);
        torchSwitchLimit = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (torchSwitchLimit == false)
        {
            if (Input.GetKey(KeyCode.F) && Flashlight.activeSelf == false)
            {
                torchSwitchLimit = true;
                Flashlight.SetActive(true);
                StartCoroutine(FlashlightCooldown());
                Debug.Log("Flashlight on");
            }

            else if (Input.GetKey(KeyCode.F) && Flashlight.activeSelf == true)
            {
                torchSwitchLimit = true;
                Flashlight.SetActive(false);
                StartCoroutine(FlashlightCooldown());
                Debug.Log("Flashlight off");
            }
        }
    }

    private IEnumerator FlashlightCooldown()
    {
        yield return new WaitForSeconds(FlashlightCooldownTime);
        torchSwitchLimit = false;
    }

}
