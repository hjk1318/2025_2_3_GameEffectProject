using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetector : MonoBehaviour
{
    [SerializeField] private float detectionRadius = 10.0f;
    [SerializeField] private LayerMask enemyLayer;

   public GameObject GetClosesdEnemy()
    {
        Collider[] enemiesInRange = Physics.OverlapSphere(transform.position, detectionRadius, enemyLayer);
        if (enemiesInRange.Length > 0 )
        {
            GameObject bestTarget = null;
            float closestDistanceSqr = Mathf.Infinity;
            Vector3 currentPosition = transform.position;
        
            foreach (Collider enemyColider in enemiesInRange)
            {
                if (enemyColider.gameObject == this)
                    continue;

                Vector3 directionToTarget = enemyColider.transform.position - currentPosition;
                float dSqrToTarget = directionToTarget.sqrMagnitude;

                if(dSqrToTarget < closestDistanceSqr)
                {
                    closestDistanceSqr = dSqrToTarget;
                    bestTarget = enemyColider.gameObject;
                }
            }
            return bestTarget;
        }    
        else
        {
            return null;
        }


    }

    public List<GameObject> GetEnemiesInRange()
    {
        List<GameObject> enemiesList = new List<GameObject>();
        Collider[] enemiesInRange = Physics.OverlapSphere(transform.position, detectionRadius, enemyLayer);

        foreach(Collider enemyColider in enemiesInRange)
        {
            if(enemyColider.gameObject != this.gameObject)
            {
                enemiesList.Add(enemyColider.gameObject);
            }
        }
    }
}
