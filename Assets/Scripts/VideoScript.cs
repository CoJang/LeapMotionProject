using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]

public class VideoScript : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        Invoke("GoToNextScene", 15.3f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Invoke("GoToNextScene", 0.0f);
        }
    }

    private void GoToNextScene()
    {
        SceneManager.LoadScene("Room");
    }
}
