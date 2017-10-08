using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class DummyMove : MonoBehaviour
{
    public Transform goal;
    NavMeshAgent agent;

    void Start()
    {  
        agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Cube")
        {
            agent.enabled = false;
        }
    }
}
