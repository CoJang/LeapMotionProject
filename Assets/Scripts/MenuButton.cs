using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Hands" && gameObject.tag == "Play")
        {
            //print("Play");
            SceneManager.LoadScene("MovieScene");
        }

        if (other.tag == "Hands" && gameObject.tag == "Option")
        {
            //print("Option");
        }

        if (other.tag == "Hands" && gameObject.tag == "Exit")
        {
            //print("Exit");
            Application.Quit();
        }
    }
}
