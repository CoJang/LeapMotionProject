using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonitorColl : MonoBehaviour
{
    //BoxCollider Collider;


	// Use this for initialization
	void Awake ()
    {
        //Collider = GetComponent<BoxCollider>();

    }
	
	// Update is called once per frame
	void Update ()
    { 
		
	}

    private void OnTriggerEnter(Collider other)
    {
        //print("Something Collition");

        if(other.tag == "Hands")
        {
            print("Hands Touched Moniter!");
        }
    }
}
