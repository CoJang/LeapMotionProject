using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SendMessege : MonoBehaviour
{
    HammerMove _HM;
    HammerMove _LFD;
    HammerMove _RTD;
    static bool IsSwinging = false;

	// Use this for initialization
	void Start ()
    {
        _HM = GameObject.Find("RealHammer").GetComponent<HammerMove>();
        _LFD = GameObject.Find("LeftDoor").GetComponent<HammerMove>();
        _RTD = GameObject.Find("RightDoor").GetComponent<HammerMove>();
        IsSwinging = false;
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

    // 주어진 Delay가 끝나면 불려질 함수
    Action CallbackAction = () =>
    {
        IsSwinging = false;
    };

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "LeftQuad" && !IsSwinging)
        {
            IsSwinging = true;
            print("Left Quad Touched");
            _HM.Rotate(_HM.LeftSwing.rotation, 0.5f, 0.0f, CallbackAction);
            
        }

        if (other.tag == "RightQuad" && !IsSwinging)
        {
            IsSwinging = true;
            print("Right Quad Touched");
            _HM.Rotate(_HM.RightSwing.rotation, 0.5f, 0.0f, CallbackAction);
        }

        if (other.tag == "UpQuad")
        {
            print("Up Quad Touched");
            _LFD.Rotate(_LFD.LeftDoorGreed.rotation, 1.0f, 0.0f, null);
            _RTD.Rotate(_RTD.RightDoorGreed.rotation, 1.0f, 0.0f, null);
        }

        if (other.tag == "DownQuad")
        {
            print("Down Quad Touched");
        }
    }

    
}
