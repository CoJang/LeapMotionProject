using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyScript : MonoBehaviour
{
    // Use this for initialization
	void Start ()
    {
		
	}

    // Update is called once per frame
    //void Update ()
    //{

    //}

    public void RotateDoor()
    {
        Animator Doors;
        Doors = GameObject.Find("DoorArch").GetComponent<Animator>();
        Doors.SetTrigger("Rotate");
    }

    public void StopAnimator()
    {
        //CharAnimator = gameObject.GetComponentInChildren<Animator>();
        Animator CharAnimator;
        CharAnimator = GameObject.Find("LobbyChar").GetComponent<Animator>();
        CharAnimator.enabled = false;
    }

    public void StartAnim()
    {
        Animator CharAnimator;
        CharAnimator = GameObject.Find("LobbyChar").GetComponent<Animator>();
        CharAnimator.enabled = true ;
    }
}
