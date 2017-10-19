using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TrapMove : MonoBehaviour
{
    public Transform Origin_transform;

    public Transform LeftHammer;
    public Transform RightHammer;

    public Transform LeftDoorGreed;
    public Transform RightDoorGreed;

    public float DoorSpeed = 1.0f;
    public float HammerSpeed = 0.5f;

    Animator LeftSwing_Ani;
    Animator RightSwing_Ani;

    // Use this for initialization
    void Start ()
    {
        Origin_transform = transform;
        LeftSwing_Ani = LeftHammer.GetComponentInChildren<Animator>();
        RightSwing_Ani = RightHammer.GetComponentInChildren<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        //transform.rotation = new Quaternion(transform.rotation.x + 1, transform.rotation.y, transform.rotation.z, transform.rotation.w);
        //transform.rotation. = new Quaternion(transform.rotation.x + 1, transform.rotation.y, transform.rotation.z, transform.rotation.w);
        //transform.eulerAngles = new Vector3(transform.rotation.x + 1, transform.rotation.y, transform.rotation.z);

    }

    public void LeftSwing()
    {
        LeftSwing_Ani.SetTrigger("LeftSwing");
    }

    public void RightSwing()
    {
        RightSwing_Ani.SetTrigger("RightSwing");
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
