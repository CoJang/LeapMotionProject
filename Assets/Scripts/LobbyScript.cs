using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyScript : MonoBehaviour
{
	[SerializeField] Material DoorMat;
    [SerializeField] GameObject SpriteUI;
    int EmissionCounter = 0;
    public bool HandCollision;

    float CurTime;
    public float DelayTime;
    public bool SettingComplete;
    public bool ActiveUI = false;
    // Use this for initialization
    void Start ()
    {
        if (DelayTime == 0)
            DelayTime = 1.0f;

        SettingComplete = false;

        //DoorMat = GameObject.Find("DoorExample").GetComponent<Renderer>().sharedMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        if(ActiveUI)
        {
            SpriteUI.SetActive(!HandCollision);
        }
        else
            SpriteUI.SetActive(false);
        //if(Input.GetKeyUp(KeyCode.E))
        //{
        //    MakeEmission(true);
        //}

        //if (Input.GetKeyUp(KeyCode.D))
        //{
        //    MakeEmission(false);
        //}

        if (CurTime <= DelayTime)
        {
            CurTime += Time.deltaTime;
        }
        else if(CurTime > DelayTime && HandCollision)
        {
            MakeEmission(true);
            CurTime = 0;
        }
        else if (CurTime > DelayTime && !HandCollision)
        {
            MakeEmission(false);
            CurTime = 0;
        }
    }

    public void RotateDoor()
    {
        Animator Doors;
        Doors = GameObject.Find("DoorArch").GetComponent<Animator>();
        Doors.SetTrigger("Rotate");
    }

    public void StopAnimator()
    {
        //CharAnimator = gameObject.GetComponentInChildren<Animator>();
        Animator CharAnimator;
        CharAnimator = GameObject.Find("LobbyChar").GetComponent<Animator>();
        CharAnimator.enabled = false;
    }

    public void InactiveUI()
    {
        ActiveUI = false;
    }

    public void activeUI()
    {
        ActiveUI = true;
    }

    public void StartAnim()
    {
        Animator CharAnimator;
        CharAnimator = GameObject.Find("LobbyChar").GetComponent<Animator>();
        CharAnimator.enabled = true;
    }

    public void SlowerAnimation()
    {
        Animator CharAnimator;
        CharAnimator = GameObject.Find("LobbyChar").GetComponent<Animator>();
        CharAnimator.speed = 0.6f;
    }

    public void MakeEmission(bool UpOrDown)
    {
        float _Emission;

        if (UpOrDown == true && EmissionCounter < 40)
        {
            EmissionCounter++;
            _Emission = 1.1f; //UP   [0.5 * 1.2f 기준 5번], [0.5f * 1.1f 기준 16번]
                              //UP   [0.2 * 1.1f 기준 40번]
        }
        else if (UpOrDown == false && EmissionCounter > 0)
        {
            EmissionCounter--;
            _Emission = 0.9f;
        }
        else if (EmissionCounter == 40)
        {
            _Emission = 1;
            MoveTriggerOn();
        }
        else
            _Emission = 1;

        Color _Color = DoorMat.GetColor("_EmissionColor");

        Color _FinalColor = _Color * Mathf.LinearToGammaSpace(_Emission);

        DoorMat.SetColor("_EmissionColor", _FinalColor);
        //print(EmissionCounter);
    }

    public void MoveTriggerOn()
    {
        Animator CharAnimator;
        CharAnimator = GameObject.Find("LobbyCharObject").GetComponent<Animator>();
        CharAnimator.SetTrigger("Move");
    }

    public void OnSettingComplete()
    {
        SettingComplete = true;
    }

}
