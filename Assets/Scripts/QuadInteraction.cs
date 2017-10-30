using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class QuadInteraction : MonoBehaviour
{
    static TrapMove _HM;
    TrapMove _LFD;
    TrapMove _RTD;
    TrapMove _PAD;

    static bool IsSwinging = false;
    static bool IsBreaked = false;
    static bool IsRotating = false;

    // Use this for initialization
    void Start ()
    {
        _HM = GameObject.Find("Hammers").GetComponent<TrapMove>();
        _LFD = GameObject.Find("LeftDoor").GetComponent<TrapMove>();
        _RTD = GameObject.Find("RightDoor").GetComponent<TrapMove>();
        _PAD = GameObject.Find("Trap").GetComponent<TrapMove>();
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

    public void SetCoolTime()
    {
        IsBreaked = false;
    }

    public void SetSwingTime()
    {
        IsSwinging = false;
    }

    public void SetRotateTime()
    {
        IsRotating = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "LeftQuad" && !IsSwinging)
        {
            IsSwinging = true;
            print("Left Quad Touched");

            _HM.LeftSwing();
            Invoke("SetSwingTime", 1.0f);
        }

        if (other.tag == "RightQuad" && !IsSwinging)
        {
            IsSwinging = true;
            print("Right Quad Touched");

            _HM.RightSwing();
            Invoke("SetSwingTime", 1.0f);
        }

        if (other.tag == "UpQuad" && !IsRotating)
        {
            _PAD.RotatePad();
            IsRotating = true;
            Invoke("SetRotateTime", 1.2f);
        }

        if (other.tag == "DownQuad" && !IsBreaked)
        {
            print("Up Quad Touched");
            _LFD.Break(_LFD.LeftDoorGreed.rotation, _LFD.DoorSpeed, 0.0f, null);
            _RTD.Break(_RTD.RightDoorGreed.rotation, _RTD.DoorSpeed, 0.0f, null);
            IsBreaked = true;
            Invoke("SetCoolTime", 1.4f);
        }
    }

    public bool GetDoorState()
    {
        return IsBreaked;
    }

    public bool GetPadState()
    {
        return IsRotating;
    }
    
}
