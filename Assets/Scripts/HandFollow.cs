using InteractionEngineUtility;
using Leap.Unity.Interaction.Internal;
using Leap.Unity.RuntimeGizmos;
using Leap.Unity.Space;
using Leap.Unity.Query;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity.Attributes;
using Leap.Unity.Interaction;

public class HandFollow : MonoBehaviour
{
    public RectTransform Loading;
    public RectTransform Base;
    //public Transform Loading;
    public GameObject Hand;
    public Camera cam;
    public Vector3 offset;


    //Leap.Unity.

    // Use this for initialization
    void Start ()
    {
		//leap
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 pos = (-Hand.transform.position * 1000) + offset;
        //pos.z = -700;
        pos.z = Base.position.z;
        Loading.localPosition = cam.ScreenToWorldPoint(pos);
	}
}
