using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankBackAvoider : MonoBehaviour
{
    public GameObject enemyTank;
    private EnemyTankHealth tankHealthScript;

    void Start()
    {
        tankHealthScript = enemyTank.GetComponent<EnemyTankHealth>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EnemySoldier"))
        {
             EnemyMovement enemMov= other.gameObject.GetComponent<EnemyMovement>();
            if (enemMov != null)
            {
                if (tankHealthScript != null && tankHealthScript.isAlive)
                {
                    Vector3 newPosition = enemMov.transform.position;
                    newPosition.z += 6f;
                    enemMov.transform.position = newPosition;
                }
                else
                {

                    if (enemMov != null)
                    {
                        Vector3 newPosition = enemMov.transform.position;
                        newPosition.z += 4f;
                        enemMov.transform.position = newPosition;

                    }
                }
            }
            
        }
    }
}
