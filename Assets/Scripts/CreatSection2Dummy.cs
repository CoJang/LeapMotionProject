using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CreatSection2Dummy : MonoBehaviour
{
    public Transform OriginPos;
    [SerializeField] GameObject[] Heroes; // 0 = A /1 = B /2 = C
    LobbyScript _LobbyScript;

    float GroupTimer = 0;
    float GroupSpawnTime = 6;
    bool ForOnceExe;

	// Use this for initialization
	void Start ()
    {
        _LobbyScript = GameObject.Find("LobbyCharObject").GetComponent<LobbyScript>();
        ForOnceExe = false;


    }

    // Update is called once per frame
    void Update ()
    {
        if(_LobbyScript.SettingComplete && !ForOnceExe)
        {
            ForOnceExe = true;

            {
                #region 그룹 1 Easy
                {
                    StartCoroutine(SpwanHero(GroupTimer++, 0));
                    StartCoroutine(SpwanHero(GroupTimer++, 0));
                    GroupTimer = GroupTimer + GroupSpawnTime;
                }
                #endregion

                #region 그룹 2 Easy
                {
                    StartCoroutine(SpwanHero(GroupTimer++, 0));
                    StartCoroutine(SpwanHero(GroupTimer++, 0));
                    StartCoroutine(SpwanHero(GroupTimer++, 0));
                    GroupTimer = GroupTimer + GroupSpawnTime;
                }
                #endregion

                #region 그룹 3 Easy
                {
                    StartCoroutine(SpwanHero(GroupTimer++, 0));
                    StartCoroutine(SpwanHero(GroupTimer++, 0));
                    StartCoroutine(SpwanHero(GroupTimer++, 0));
                    StartCoroutine(SpwanHero(GroupTimer++, 0));
                    GroupTimer = GroupTimer + GroupSpawnTime;
                }
                #endregion

                #region 그룹 4 Easy
                {
                    StartCoroutine(SpwanHero(GroupTimer++, 0));
                    StartCoroutine(SpwanHero(GroupTimer++, 1));
                    GroupTimer = GroupTimer + GroupSpawnTime;
                }
                #endregion

                #region 그룹 5 Easy
                {
                    StartCoroutine(SpwanHero(GroupTimer++, 0));
                    StartCoroutine(SpwanHero(GroupTimer++, 0));
                    StartCoroutine(SpwanHero(GroupTimer++, 1));
                    GroupTimer = GroupTimer + GroupSpawnTime;
                }
                #endregion

                #region 그룹 6 Easy
                {
                    StartCoroutine(SpwanHero(GroupTimer++, 0));
                    StartCoroutine(SpwanHero(GroupTimer++, 0));
                    StartCoroutine(SpwanHero(GroupTimer++, 0));
                    StartCoroutine(SpwanHero(GroupTimer++, 1));
                    GroupTimer = GroupTimer + GroupSpawnTime;
                }
                #endregion

                #region 그룹 7 Easy
                {
                    StartCoroutine(SpwanHero(GroupTimer++, 0));
                    StartCoroutine(SpwanHero(GroupTimer++, 2)); // D -> C 로 대체
                    GroupTimer = GroupTimer + GroupSpawnTime;
                }
                #endregion

                #region 그룹 8 Easy
                {
                    StartCoroutine(SpwanHero(GroupTimer++, 0));
                    StartCoroutine(SpwanHero(GroupTimer++, 0));
                    StartCoroutine(SpwanHero(GroupTimer++, 2)); // D -> C 로 대체
                    GroupTimer = GroupTimer + GroupSpawnTime;
                }
                #endregion

                #region 그룹 9 Easy
                {
                    StartCoroutine(SpwanHero(GroupTimer++, 0));
                    StartCoroutine(SpwanHero(GroupTimer++, 0));
                    StartCoroutine(SpwanHero(GroupTimer++, 0));
                    StartCoroutine(SpwanHero(GroupTimer++, 2)); // D -> C 로 대체
                    GroupTimer = GroupTimer + GroupSpawnTime;
                }
                #endregion

                #region 그룹 10 Easy
                {
                    StartCoroutine(SpwanHero(GroupTimer++, 0));
                    StartCoroutine(SpwanHero(GroupTimer++, 1));
                    StartCoroutine(SpwanHero(GroupTimer++, 2)); // D -> C로 대체
                    GroupTimer = GroupTimer + GroupSpawnTime;
                }
                #endregion

                #region 그룹 11 Easy
                {
                    StartCoroutine(SpwanHero(GroupTimer++, 0));
                    StartCoroutine(SpwanHero(GroupTimer++, 0));
                    StartCoroutine(SpwanHero(GroupTimer++, 1));
                    StartCoroutine(SpwanHero(GroupTimer++, 2)); // D -> C로 대체
                    GroupTimer = GroupTimer + GroupSpawnTime;
                }
                #endregion

                #region 그룹 12 Easy
                {
                    StartCoroutine(SpwanHero(GroupTimer++, 1));
                    StartCoroutine(SpwanHero(GroupTimer++, 2)); // D -> C로 대체
                    GroupTimer = GroupTimer + GroupSpawnTime;
                }
                #endregion

                #region 그룹 13 Easy
                {
                    StartCoroutine(SpwanHero(GroupTimer++, 0));
                    StartCoroutine(SpwanHero(GroupTimer++, 2));
                    GroupTimer = GroupTimer + GroupSpawnTime;
                }
                #endregion

                #region 그룹 14 Easy
                {
                    StartCoroutine(SpwanHero(GroupTimer++, 0));
                    StartCoroutine(SpwanHero(GroupTimer++, 0));
                    StartCoroutine(SpwanHero(GroupTimer++, 2));
                    GroupTimer = GroupTimer + GroupSpawnTime;
                }
                #endregion

                #region 그룹 15 Normal
                {
                    StartCoroutine(SpwanHero(GroupTimer++, 0));
                    StartCoroutine(SpwanHero(GroupTimer++, 0));
                    StartCoroutine(SpwanHero(GroupTimer++, 1));
                    StartCoroutine(SpwanHero(GroupTimer++, 2)); // D -> C로 대체
                    GroupTimer = GroupTimer + GroupSpawnTime;
                }
                #endregion

                #region 그룹 16 Normal
                {
                    StartCoroutine(SpwanHero(GroupTimer++, 1));
                    StartCoroutine(SpwanHero(GroupTimer++, 1));
                    StartCoroutine(SpwanHero(GroupTimer++, 2)); // D -> C로 대체
                    GroupTimer = GroupTimer + GroupSpawnTime;
                }
                #endregion

                #region 그룹 17 Normal
                {
                    StartCoroutine(SpwanHero(GroupTimer++, 0));
                    StartCoroutine(SpwanHero(GroupTimer++, 1));
                    StartCoroutine(SpwanHero(GroupTimer++, 1));
                    StartCoroutine(SpwanHero(GroupTimer++, 2)); // D -> C로 대체
                    GroupTimer = GroupTimer + GroupSpawnTime;
                }
                #endregion

                #region 그룹 18 Normal
                {
                    StartCoroutine(SpwanHero(GroupTimer++, 0));
                    StartCoroutine(SpwanHero(GroupTimer++, 0));
                    StartCoroutine(SpwanHero(GroupTimer++, 0));
                    StartCoroutine(SpwanHero(GroupTimer++, 2)); // D -> C로 대체
                    GroupTimer = GroupTimer + GroupSpawnTime;
                }
                #endregion

                #region 그룹 19 Normal
                {
                    StartCoroutine(SpwanHero(GroupTimer++, 1));
                    StartCoroutine(SpwanHero(GroupTimer++, 2));
                    StartCoroutine(SpwanHero(GroupTimer++, 2)); // D -> C로 대체
                    GroupTimer = GroupTimer + GroupSpawnTime;
                }
                #endregion

                #region 그룹 20 Normal
                {
                    StartCoroutine(SpwanHero(GroupTimer++, 1));
                    StartCoroutine(SpwanHero(GroupTimer++, 2));
                    StartCoroutine(SpwanHero(GroupTimer++, 0));
                    GroupTimer = GroupTimer + GroupSpawnTime;
                }
                #endregion

                #region 그룹 21 Hard
                {
                    StartCoroutine(SpwanHero(GroupTimer++, 0));
                    StartCoroutine(SpwanHero(GroupTimer++, 2));
                    StartCoroutine(SpwanHero(GroupTimer++, 2));
                    GroupTimer = GroupTimer + GroupSpawnTime;
                }
                #endregion

                #region 그룹 22 Hard
                {
                    StartCoroutine(SpwanHero(GroupTimer++, 2));
                    StartCoroutine(SpwanHero(GroupTimer++, 2));
                    StartCoroutine(SpwanHero(GroupTimer++, 2));
                    GroupTimer = GroupTimer + GroupSpawnTime;
                }
                #endregion

                #region 그룹 23 Hard
                {
                    StartCoroutine(SpwanHero(GroupTimer++, 1));
                    StartCoroutine(SpwanHero(GroupTimer++, 2));
                    StartCoroutine(SpwanHero(GroupTimer++, 2));
                    GroupTimer = GroupTimer + GroupSpawnTime;
                }
                #endregion

                #region 그룹 24 Hard
                {
                    StartCoroutine(SpwanHero(GroupTimer++, 0));
                    StartCoroutine(SpwanHero(GroupTimer++, 2));
                    StartCoroutine(SpwanHero(GroupTimer++, 2));
                    StartCoroutine(SpwanHero(GroupTimer++, 2));
                    GroupTimer = GroupTimer + GroupSpawnTime;
                }
                #endregion

                #region 그룹 25 Hard
                {
                    StartCoroutine(SpwanHero(GroupTimer++, 0));
                    StartCoroutine(SpwanHero(GroupTimer++, 2));
                    StartCoroutine(SpwanHero(GroupTimer++, 2));
                    StartCoroutine(SpwanHero(GroupTimer++, 1));
                    GroupTimer = GroupTimer + GroupSpawnTime;
                }
                #endregion

                #region 그룹 26 Hard
                {
                    StartCoroutine(SpwanHero(GroupTimer++, 0));
                    StartCoroutine(SpwanHero(GroupTimer++, 1));
                    StartCoroutine(SpwanHero(GroupTimer++, 2)); //D->C로 대체
                    GroupTimer = GroupTimer + GroupSpawnTime;
                }
                #endregion

                #region 그룹 27 Hard
                {
                    StartCoroutine(SpwanHero(GroupTimer++, 0));
                    StartCoroutine(SpwanHero(GroupTimer++, 1));
                    StartCoroutine(SpwanHero(GroupTimer++, 2));
                    StartCoroutine(SpwanHero(GroupTimer++, 2)); // D->C로 교체
                    GroupTimer = GroupTimer + GroupSpawnTime;
                }
                #endregion
            }
        }


    }

    public IEnumerator SpwanHero(float SpawnDelay, int HeroType)
    {
        yield return new WaitForSecondsRealtime(SpawnDelay);

        Vector3 sourcePosition = OriginPos.position;
        NavMeshHit closestHit;

        if (NavMesh.SamplePosition(sourcePosition, out closestHit, 500, 1))
        {
            Instantiate(Heroes[HeroType]);
            Heroes[HeroType].transform.position = closestHit.position;
        }
        else
            print("Hero Instantiate Failed!");

    }
}
