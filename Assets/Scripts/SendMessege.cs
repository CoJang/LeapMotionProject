using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendMessege : MonoBehaviour
{
    HammerMove _HM;
    bool IsSwinging;

	// Use this for initialization
	void Start ()
    {
        _HM = GameObject.Find("RealHammer").GetComponent<HammerMove>();
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

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "LeftQuad" && !IsSwinging)
        {
            IsSwinging = true;
            print("Left Quad Touched");
            _HM.Rotate(_HM.LeftSwing.rotation, 0.6f, 0.0f, null);
            
        }

        if (other.tag == "RightQuad" && !IsSwinging)
        {
            IsSwinging = true;
            print("Right Quad Touched");
            _HM.Rotate(_HM.RightSwing.rotation, 0.6f, 0.0f, null);
        }

        if (other.tag == "UpQuad")
        {
            print("Up Quad Touched");
        }

        if (other.tag == "DownQuad")
        {
            print("Down Quad Touched");
        }
    }

    
}
