using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatSection2Dummy : MonoBehaviour
{
    public Transform OriginPos;
    [SerializeField] GameObject HeroC;

	// Use this for initialization
	void Start ()
    {
        //DummyHero = Resources.Load("Navi_Section2") as GameObject;
        //OriginPos = new Vector3(-2.37f, 5.498f, -23.716f);

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Instantiate(HeroC, OriginPos);
        }
    }
}
