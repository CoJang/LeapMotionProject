using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour
{
    public Vector3 _Pos;
    Rigidbody _Rigid;
	// Use this for initialization
	void Awake ()
    {
        _Rigid = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKeyUp(KeyCode.Space))
        {
            transform.position = _Pos;
            _Rigid.velocity = Vector3.zero;
        }
	}
}
