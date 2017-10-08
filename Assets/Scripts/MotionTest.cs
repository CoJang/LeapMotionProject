using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;
using Leap.Unity.Attributes;
using LeapInternal;

public class MotionTest : MonoBehaviour {

    Controller _controller;

	// Use this for initialization
	void Start () {
        _controller = new Controller();
        // _controller.Config.SetFloat
       

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
