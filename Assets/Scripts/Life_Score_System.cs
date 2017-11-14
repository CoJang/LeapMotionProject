using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life_Score_System : MonoBehaviour
{
    [SerializeField] SpriteRenderer[] _renderers;
    [SerializeField] Sprite[] _sprite; // 0 = sane, 1 = insane
    [SerializeField] TextMesh _3DText;
    [SerializeField] LobbyScript _LobbyScript;

    int Life;
    int Score;
    float _Time;
    bool IsGameOver;

	// Use this for initialization
	void Start ()
    {
        Life = 3;
        Score = 0;
        _Time = 60;
        IsGameOver = false;

        StartCoroutine(GoodByeMyTime());
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void OnHeroEnterd()
    {
        Life--;
        
        switch(Life)
        {
            case 2:
                _renderers[Life].sprite = _sprite[1];
                break;

            case 1:
                _renderers[Life].sprite = _sprite[1];
                break;

            case 0:
                _renderers[Life].sprite = _sprite[1];
                _3DText.text = "Game Over";
                IsGameOver = true;
                break;
        }
    }

    public void OnHeroHitByTraps(int AddScore)
    {
        Score += AddScore;
        //_3DText.text = "Score : " + Score;
    }

    IEnumerator GoodByeMyTime()
    {
        if(_LobbyScript.SettingComplete && !IsGameOver)
        {
            _3DText.text = "" + _Time--;
            if (_Time < 1)
                _3DText.text = "Game Over";
        }

        yield return new WaitForSeconds(1.0f);

        StartCoroutine(GoodByeMyTime());
    }
}
