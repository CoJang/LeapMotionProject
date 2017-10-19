using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class DummyMove : MonoBehaviour
{
    [SerializeField] QuadInteraction _quad;
    public Transform goal;
    NavMeshAgent agent;

    void Start()
    {  
        agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Cube" || other.tag == "Hammer")
        {
            agent.enabled = false;
        }

        if (other.tag == "Door")
        {
            if (_quad.GetDoorState())
                agent.enabled = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Cube" || other.tag == "Hammer")
        {
            agent.enabled = false;
        }

        if (other.tag == "Door")
        {
            if (_quad.GetDoorState())
                agent.enabled = false;
        }
    }
}
