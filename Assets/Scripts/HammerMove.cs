using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HammerMove : MonoBehaviour
{
    Transform _transform;

    public Transform LeftSwing;
    public Transform RightSwing;

    //Quaternion LeftQ;
    //Quaternion RightQ;

    // Use this for initialization
    void Start ()
    {
        _transform = transform;
        //LeftQ = LeftSwing.rotation;
        //RightQ = RightSwing.rotation;
    }
	
	// Update is called once per frame
	void Update ()
    {

    }


    public void Move(Vector3 dstPosition, float moveTime, float delayTime, Action callback)
    {
        dstPosition.z = _transform.position.z;
        StartCoroutine(UpdateMove(dstPosition, moveTime, delayTime, callback));
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

        //for (float rate = 0.0f; rate < 1.0f; rate += Time.deltaTime / moveTime)
        //{
        //    transform.position = Vector3.Lerp(dstPosition, srcPosition, rate);
        //    yield return null;
        //}

        if (callback != null)
            callback();
    }

    public void Rotate(Quaternion dstQuaternion, float rotateTime, float delayTime, Action callback)
    {
        StartCoroutine(UpdateRotate(dstQuaternion, rotateTime, delayTime, callback));
    }

    IEnumerator UpdateRotate(Quaternion dstQuaternion, float rotateTime, float delayTime, Action callback)
    {
        Quaternion srcQuaternion = transform.rotation;

        for(float rate = 0.0f; rate < 1.0f; rate += Time.deltaTime / rotateTime)
        {
            transform.rotation = Quaternion.Lerp(srcQuaternion, dstQuaternion, rate);
            yield return null;
        }

        yield return new WaitForSeconds(delayTime);

        //for(float rate = 0.0f; rate < 1.0f; rate += Time.deltaTime / rotateTime)
        //{
        //    transform.rotation = Quaternion.Lerp(dstQuaternion, srcQuaternion, rate);
        //    yield return null;
        //}

        if(callback != null)
        {
            callback();
        }

    }
}
