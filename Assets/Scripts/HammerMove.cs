using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HammerMove : MonoBehaviour
{
    Transform _transform;

    public Transform LeftSwing;
    public Transform RightSwing;

    public Transform LeftDoorGreed;
    public Transform RightDoorGreed;

    // Use this for initialization
    void Start ()
    {
        _transform = transform;
    }
	
	// Update is called once per frame
	void Update ()
    {

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

        if(callback != null)
        {
            callback();
        }

    }
}
