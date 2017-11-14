using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class QuadInteraction : MonoBehaviour
{
    static public TrapMove _Traps;

    static bool IsSwinging = false;
    static bool IsBreaked = false;
    static bool IsRotating = false;

    // Use this for initialization
    void Start ()
    {
        _Traps = GameObject.Find("Dungeuns").GetComponent<TrapMove>();
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

    //// 주어진 Delay가 끝나면 불려질 함수
    //Action CallbackSwing = () =>
    //{
    //    IsSwinging = false;
    //    //_HM.transform.rotation = _HM.Origin_transform.rotation;
    //    //print("CallBacked");
    //};

    // Action CallbackBreak = () =>
    //{
    //    IsBreaked = false;
    //};

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
            //print("Left Quad Touched");

            _Traps.LeftSwing();
            Invoke("SetSwingTime", 1.0f);
        }

        if (other.tag == "RightQuad" && !IsSwinging)
        {
            IsSwinging = true;
            //print("Right Quad Touched");

            _Traps.RightSwing();
            Invoke("SetSwingTime", 1.0f);
        }

        if (other.tag == "UpQuad" && !IsRotating)
        {
            _Traps.RotatePad();
            IsRotating = true;
            Invoke("SetRotateTime", 1.2f);
        }

        if (other.tag == "DownQuad" && !IsBreaked)
        {
            //print("Up Quad Touched");
            _Traps.RotateDoor();
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
