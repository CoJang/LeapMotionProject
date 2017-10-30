using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TV_Change : MonoBehaviour
{
    public Material[] _mat;
    public int _index;
    public MonitorIter _Iter;

    Renderer _renderer;
    bool handsoff;
    bool _timer;

	void Awake ()
    {
        _renderer = GetComponent<Renderer>();
        handsoff = true;
        _timer = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerStay(Collider other)
    {
        //print("Something Collition");

        if (other.tag == "Hands" && handsoff && !_timer)
        {
            handsoff = false;
            StartCoroutine(WaitingHands());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Hands" && !handsoff && _timer)
        {
            handsoff = true;
            _renderer.sharedMaterial = _mat[_index++];
            _index = _index % 3;

            _Iter.IndexChanged();

            _timer = false;
        }
    }

    IEnumerator WaitingHands()
    {
        yield return new WaitForSecondsRealtime(0.3f);

        _timer = true;
    }
}
