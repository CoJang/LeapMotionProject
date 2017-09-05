using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonitorIter : MonoBehaviour
{
    public Material[] _mat;
    public Renderer[] _renderer;

    TV_Change Main_Monitor;


	void Start ()
    {
        Main_Monitor = GameObject.Find("MainMonitor").GetComponent<TV_Change>();

    }

	void Update ()
    {
		
	}

    public void IndexChanged()
    {
        switch(Main_Monitor._index)
        {
            case 0:
                _renderer[0].sharedMaterial = _mat[0];
                _renderer[1].sharedMaterial = _mat[1];
                _renderer[2].sharedMaterial = _mat[2];
                break;

            case 1:
                _renderer[0].sharedMaterial = _mat[1];
                _renderer[1].sharedMaterial = _mat[0];
                _renderer[2].sharedMaterial = _mat[2];
                break;

            case 2:
                _renderer[0].sharedMaterial = _mat[2];
                _renderer[1].sharedMaterial = _mat[1];
                _renderer[2].sharedMaterial = _mat[0];
                break;
        }
    }
}
