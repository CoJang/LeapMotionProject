using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerDirectionCheck : MonoBehaviour {

    bool IsMidFingerCorrect;
    bool IsIndexFingerCorrect;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(IsMidFingerCorrect && IsIndexFingerCorrect)
        {
            print("Motion Correct!");
        }
	}

    public void OnMiddleFingerCorrect()
    {
        IsMidFingerCorrect = true;
    }

    public void OnIndexFingerCorrect()
    {
        IsIndexFingerCorrect = true;
    }

    public void DeactivateIndexFinger()
    {
        IsIndexFingerCorrect = false;
    }

    public void DeactivateMiddleFinger()
    {
        IsMidFingerCorrect = false;
    }
}
