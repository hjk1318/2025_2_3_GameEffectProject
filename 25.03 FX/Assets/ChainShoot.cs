using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainShoot : MonoBehaviour
{
    [SerializeField] float refreshRate = 0.01f;
    [SerializeField] [Range(1, 10)] int maximunEnemiesInChain = 3;
    [SerializeField] float delayBetweenEachChain = 0.3f;
    [SerializeField] Transform playerFirePoint;
    [SerializeField] EnemyDetector playerEnemyDetector;
    [SerializeField] GameObject lineRendererPrefab;

    bool Shooting;
    bool shot;
    float counter = 1;
    GameObject currentClosestEnemy;
    List<GameObject> SpawnedLineRenderers = new List<GameObject>();
    List<GameObject> enemiesInChain = new List<GameObject>();
    List<GameObject> activeEffect = new List<GameObject>();

    void stopShooting()
    {
        shooting = false;
        shot = false;
        counter = 1;

        for (int i = 0; i < SpawnedLineRenderers.Count; i++)
        {
            Destroy(SpawnedLineRenderers[i]);
        }

        SpawnedLineRenderers.Clear();
        enemiesInChain.Clear();

        for (int i = 0; i < activeEffect.Count; i++)
        {
            Destroy(activeEffect[i]);
        }

        activeEffect.Clear();
    }

    IEnumerator UpdateLineRenderer(GameObject LineR, Transform startPos, Transform endPos, bool getClosestEnemyToPlater = false)
    {
        if (shooting && shot && lineR != null)
        {
            lineR.GetComponent<LineRendererController>().SetPosition(startPos, endPos);
            yield return new WaitForSeconds(refreshRate);

            if(getClosestEnemyToPlater)
            {
                StartCoroutine(UpdateLineRenderer(LineR, startPos, playerEnemyDetector.GetClosesdEnemy().transform,true)

                if (currentClosestEnemy != playerEnemyDetector.getClosestEnemy())
                {
                    StopShooting();

                }
            }
            else
            {
                StartCoroutine(UpdateLineRenderer(LineR, startPos, endPos));
            }

        }
    }

    void NewLineRenderer(Transform startPos, Transform end, bool getClosestEnemyToPlater = false)
    {
        GameObject lineR = Instantiate(lineRendererPrefab);
        SpawnedLineRenderers.Add(lineR);
        StartCoroutine(UpdateLineRenderer(lineR, startPos, endPos, GetClosestEnemyToPlayer));
    }

    IEnumerator ChainReaction(GameObject closestEnemey)
    {
        yeld return new WaitForSeconds(delayBetweenEachChain);
    }
}
