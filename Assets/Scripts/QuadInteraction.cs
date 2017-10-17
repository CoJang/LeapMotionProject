using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class QuadInteraction : MonoBehaviour
{
    static TrapMove _HM;
    TrapMove _LFD;
    TrapMove _RTD;

    static bool IsSwinging = false;
    static bool IsBreaked = false;

    // Use this for initialization
    void Start ()
    {
        _HM = GameObject.Find("RealHammer").GetComponent<TrapMove>();
        _LFD = GameObject.Find("LeftDoor").GetComponent<TrapMove>();
        _RTD = GameObject.Find("RightDoor").GetComponent<TrapMove>();



        IsSwinging = false;
        IsBreaked = false;
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
    Action CallbackSwing = () =>
    {
        IsSwinging = false;
        //_HM.transform.rotation = _HM.Origin_transform.rotation;
        //print("CallBacked");
    };

    Action CallbackBreak = () =>
    {
        IsBreaked = false;
    };

    public void SetCooltime()
    {
        IsBreaked = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "LeftQuad" && !IsSwinging)
        {
            IsSwinging = true;
            print("Left Quad Touched");
            _HM.Rotate(_HM.LeftSwing.rotation, _HM.HammerSpeed, 0.0f, CallbackSwing);
            //_HM.LeftSwing.rotation = new Quaternion(_HM.LeftSwing.rotation.x + 360, _HM.LeftSwing.rotation.y, _HM.LeftSwing.rotation.z, _HM.LeftSwing.rotation.w);
        }

        if (other.tag == "RightQuad" && !IsSwinging)
        {
            IsSwinging = true;
            print("Right Quad Touched");
            _HM.Rotate(_HM.RightSwing.rotation, _HM.HammerSpeed, 0.0f, CallbackSwing);
           
        }

        if (other.tag == "UpQuad" && !IsBreaked)
        {
            IsBreaked = true;
            print("Up Quad Touched");
            _LFD.Break(_LFD.LeftDoorGreed.rotation, _LFD.DoorSpeed, 0.0f, null);
            _RTD.Break(_RTD.RightDoorGreed.rotation, _RTD.DoorSpeed, 0.0f, null);
            Invoke("SetCooltime", 2.0f);
        }

        if (other.tag == "DownQuad")
        {
            print("Down Quad Touched");
        }
    }

    public bool GetDoorState()
    {
        return IsBreaked;
    }
    
}
