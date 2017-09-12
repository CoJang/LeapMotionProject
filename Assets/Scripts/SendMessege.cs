using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendMessege : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void OnCorrect()
    {
        print("It was Right");
    }

    public void OnIncorrect()
    {
        print("It was Wrong");
    }
}
