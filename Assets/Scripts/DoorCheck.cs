using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCheck : MonoBehaviour
{
    [SerializeField] LobbyScript _LobbyScript;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Hands")
        {
            _LobbyScript.HandCollision = true;
        }
        else
        {
            _LobbyScript.HandCollision = false;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        {
            _LobbyScript.HandCollision = false;
        }

    }
}
