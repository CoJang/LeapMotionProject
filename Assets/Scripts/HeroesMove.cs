using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class HeroesMove : MonoBehaviour
{
    [SerializeField] QuadInteraction _quad;
    [SerializeField] Transform goal;

    NavMeshAgent agent;
    Rigidbody _Rigid;
    Life_Score_System _LifeScoreSystem;
    bool IsHit;
    int GiveScore;

    private void Awake()
    {
		gameObject.AddComponent<NavMeshAgent>();   
    }

    void Start()
    {
        IsHit = false;
        agent = gameObject.GetComponent<NavMeshAgent>();
        _Rigid = gameObject.GetComponent<Rigidbody>();
        _LifeScoreSystem = GameObject.Find("Monitor Iterator").GetComponent<Life_Score_System>();


        if (gameObject.tag == "Hero A") 
		{
			agent.baseOffset = 0.35f;
            GiveScore = 2;
        }

		if (gameObject.tag == "Hero B") 
		{
			agent.baseOffset = 0.35f;
            GiveScore = 3;
        }

		if (gameObject.tag == "Hero C") 
		{
			agent.baseOffset = 0.15f;
            GiveScore = 5;
        }

		agent.speed = UnityEngine.Random.Range(1.0f, 2.5f);
        //agent.destination = new Vector3(0.266f, 20.867f, -54.595f);
        agent.destination = goal.position;
        agent.autoBraking = false;
        agent.autoRepath = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Hammer" && gameObject.tag != "Hero C" && !IsHit)
        {
            IsHit = true;
            agent.enabled = false;
            _Rigid.isKinematic = false;
            _LifeScoreSystem.OnHeroHitByTraps(GiveScore);
        }

        if (other.tag == "Door")
        {
            if (_quad.GetDoorState() && gameObject.tag != "Hero B" && !IsHit)
            {
                IsHit = true;
                agent.enabled = false;
                _Rigid.isKinematic = false;
                _LifeScoreSystem.OnHeroHitByTraps(GiveScore);
            }
        }

        if(other.tag == "Pad" && !IsHit)
        {
            if (_quad.GetPadState())
            {
                IsHit = true;
                agent.enabled = false;
                _Rigid.isKinematic = false;
                _LifeScoreSystem.OnHeroHitByTraps(GiveScore);
            }
        }

		if (other.tag == "FinalDestination" && !IsHit) 
		{
            //print (gameObject.name + " Entered FD!");
            _LifeScoreSystem.OnHeroEnterd();

            Destroy(gameObject);
		}


    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Hammer" && gameObject.tag != "Hero C" && !IsHit)
        {
            IsHit = true;
            agent.enabled = false;
            _Rigid.isKinematic = false;
            _LifeScoreSystem.OnHeroHitByTraps(GiveScore);
        }

        if (other.tag == "Door")
        {
            if (_quad.GetDoorState() && gameObject.tag != "Hero B" && !IsHit)
            {
                IsHit = true;
                agent.enabled = false;
                _Rigid.isKinematic = false;
                _LifeScoreSystem.OnHeroHitByTraps(GiveScore);
            }
        }

        if (other.tag == "Pad" && !IsHit)
        {
            if (_quad.GetPadState())
            {
                IsHit = true;
                agent.enabled = false;
                _Rigid.isKinematic = false;
                _LifeScoreSystem.OnHeroHitByTraps(GiveScore);
            }
                
        }
    }

    private void Update()
    {
        if(transform.position.y < -70)
        {
            Destroy(gameObject);
        }
    }
}
