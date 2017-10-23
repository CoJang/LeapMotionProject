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
        if(other.tag == "Hammer" && gameObject.tag != "Hero C")
        {
            agent.enabled = false;
        }

        if (other.tag == "Door")
        {
            if (_quad.GetDoorState() && gameObject.tag != "Hero B")
                agent.enabled = false;
        }

        if(other.tag == "Pad")
        {
            if (_quad.GetPadState())
                agent.enabled = false;

            print("Section3 Enterd!");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Hammer" && gameObject.tag != "Hero C")
        {
            agent.enabled = false;
        }

        if (other.tag == "Door")
        {
            if (_quad.GetDoorState() && gameObject.tag != "Hero B")
                agent.enabled = false;
        }

        if (other.tag == "Pad")
        {
            if (_quad.GetPadState())
                agent.enabled = false;
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
