using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TrapMove : MonoBehaviour
{
    public Transform Origin_transform;

    public Transform LeftHammer;
    public Transform RightHammer;
    public Transform Section3Pad;

    public float DoorSpeed = 1.0f;
    public float HammerSpeed = 0.5f;

    static Animator Section1Door_Ani;
    static Animator LeftSwing_Ani;
    static Animator RightSwing_Ani;
    static Animator Section3Pad_Ani;

    // Use this for initialization
    void Start ()
    {
        LeftSwing_Ani = GameObject.Find("LeftHammer").GetComponent<Animator>();
        RightSwing_Ani = GameObject.Find("RightHammer").GetComponent<Animator>();
        Section1Door_Ani = GameObject.Find("field2").GetComponent<Animator>();
        Section3Pad_Ani = GameObject.Find("Trap").GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
    {


    }

    public void LeftSwing()
    {
        LeftSwing_Ani.SetTrigger("Swing");
    }

    public void RightSwing()
    {
        RightSwing_Ani.SetTrigger("Swing");
    }

    public void RotatePad()
    {
        Section3Pad_Ani.SetTrigger("Rotate");
    }

    public void RotateDoor()
    {
        Section1Door_Ani.SetTrigger("Rotate");
    }

    public void Move(Vector3 dstPosition, float rotateTime, float delayTime, Action callback)
    {
        StartCoroutine(UpdateMove(dstPosition, rotateTime, delayTime, callback));
    }

    public void Break(Quaternion dstQuaternion, float rotateTime, float delayTime, Action callback)
    {
        StartCoroutine(UpdateBreak(dstQuaternion, rotateTime, delayTime, callback));
    }

    public void Rotate(Quaternion dstQuaternion, float rotateTime, float delayTime, Action callback)
    {
        StartCoroutine(UpdateRotate(dstQuaternion, rotateTime, delayTime, callback));
    }

    IEnumerator UpdateRotate(Quaternion dstQuaternion, float rotateTime, float delayTime, Action callback)
    {
        Quaternion srcQuaternion = transform.rotation;

        for (float rate = 0.0f; rate < 1.0f; rate += Time.deltaTime / rotateTime)
        {
            transform.rotation = new Quaternion(Mathf.LerpAngle(srcQuaternion.x, dstQuaternion.x, rate),
                                                Mathf.LerpAngle(srcQuaternion.y, dstQuaternion.y, rate),
                                                Mathf.LerpAngle(srcQuaternion.z, dstQuaternion.z, rate),
                                                Mathf.LerpAngle(srcQuaternion.w, dstQuaternion.w, rate));

            yield return null;
        }
        yield return new WaitForSeconds(delayTime);

        if (callback != null)
        {
            callback();
        }
    }

    IEnumerator UpdateMove(Vector3 dstPosition, float moveTime, float delayTime, Action callback)
    {
        Vector3 srcPosition = transform.position;

        for (float rate = 0.0f; rate < 1.0f; rate += Time.deltaTime / moveTime)
        {
            transform.position = Vector3.Lerp(srcPosition, dstPosition, rate);
            yield return null;
        }

        yield return new WaitForSeconds(delayTime);

        if (callback != null)
        {
            callback();
        }

    }

    IEnumerator UpdateBreak(Quaternion dstQuaternion, float rotateTime, float delayTime, Action callback)
    {
        Quaternion srcQuaternion = transform.rotation;

        for (float rate = 0.0f; rate < 1.0f; rate += Time.deltaTime / rotateTime)
        {
            transform.rotation = Quaternion.Lerp(srcQuaternion, dstQuaternion, rate);
            
            yield return null;
        }

        yield return new WaitForSeconds(delayTime);

        for (float rate = 0.0f; rate < 1.0f; rate += Time.deltaTime / rotateTime)
        {
            transform.rotation = Quaternion.Lerp(dstQuaternion, srcQuaternion, rate);
            yield return null;
        }

        if (callback != null)
        {
            callback();
        }

    }
}
