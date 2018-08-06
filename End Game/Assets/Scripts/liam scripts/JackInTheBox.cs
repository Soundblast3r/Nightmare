using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JackInTheBox : MonoBehaviour
{
    GameObject jackinthebox;
    float timer = 0;
    public float timerIncrament = 100;
    public List<GameObject> Jackboxs = new List<GameObject>();
	// Use this for initialization
	void Start ()
    {
        //jackinthebox = GameObject.FindGameObjectsWithTag("JacknBox");
        //boxs.Add(GameObject.FindGameObjectsWithTag("JacknBox");
        Debug.Log(Jackboxs.Count);
        RandomSpawn();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Time.time > timer)
        {
            //do thing
            //set the timer to the current time plus the amount
            //of time you want to wait in seconds 
            timer = Time.time + timerIncrament;
        }
	}


    void RandomSpawn()
    {
        //stores the Random number in an int 
        //used to spawn The JACK IN THE BOX
        int JackCount;
        JackCount = Random.Range(0, Jackboxs.Count -1);

        //checks to see if it's not null
        if(Jackboxs.Count > 0)
        {
            //Jackboxs[JackCount].SetActive(GameObject.FindGameObjectWithTag("JacknBox"));
            
            //spawns the jack in the box 
            //wherever the number compeared to

            if(Jackboxs[JackCount].activeInHierarchy == false)
            {
                //Jackboxs[JackCount].GetComponentInChildren<GameObject>().SetActive(true)

                Jackboxs[JackCount].SetActive(true);
            }
        }
    }
}
