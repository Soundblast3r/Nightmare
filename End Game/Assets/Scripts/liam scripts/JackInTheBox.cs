using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JackInTheBox : MonoBehaviour
{
    GameObject jackinthebox;
    float timer = 0;
    float CalmTimer = 50;
    public float timerIncrament = 100;
    public float CalmIncrament = 1;
    public List<GameObject> Jackboxs = new List<GameObject>();
	// Use this for initialization

	void Start ()
    {
        //jackinthebox = GameObject.FindGameObjectsWithTag("JacknBox");
        //boxs.Add(GameObject.FindGameObjectsWithTag("JacknBox");

        //Debug.Log(Jackboxs.Count);
        //RandomSpawn();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Time.time > timer)
        {
            //do thing
            //set the timer to the current time plus the amount
            //of time you want to wait in seconds 

            Timers();
            timer = Time.time + timerIncrament;
        }
        //Debug.Log("Jacks count down"); Debug.Log(timer);
        timer--;
    }


    void RandomSpawn()
    {
        //stores the Random number in an int 
        //used to spawn The JACK IN THE BOX
        int JackCount;
        JackCount = Random.Range(0, Jackboxs.Count);

        //checks to see if it's not null
        if(Jackboxs.Count > 0)
        {
            //Jackboxs[JackCount].SetActive(GameObject.FindGameObjectWithTag("JacknBox"));
            
            //spawns the jack in the box 
            //wherever the number compeared to

            if(Jackboxs[JackCount].activeInHierarchy == false)
            {
                //Jackboxs[JackCount].GetComponentInChildren<GameObject>().SetActive(true)
                for (int i = 0; i < Jackboxs.Count; i++)
                {
                    if(Jackboxs[i].activeInHierarchy == true)
                    {
                        Jackboxs[i].SetActive(false);
                    }
                }
                Jackboxs[JackCount].SetActive(true);
                //Debug.Log(Jackboxs[JackCount]);
            }
        }
    }

    void Timers()
    {
        if (CalmTimer <= CalmIncrament)
        {
            RandomSpawn();

            CalmTimer = Time.time + CalmIncrament;
        }
        //Debug.Log(CalmTimer);
        CalmTimer -= CalmIncrament;
    }
}
