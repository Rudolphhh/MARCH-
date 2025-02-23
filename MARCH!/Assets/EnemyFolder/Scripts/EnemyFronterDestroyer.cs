using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFronterDestroyer : MonoBehaviour
{
    public GameObject enemyTank;
    public int damageAmount = 200;
    private EnemyTankHealth tankHealthScript;
    private EnemyTankMovement tankMovementScript;

    void Start()
    {

        tankHealthScript = enemyTank.GetComponent<EnemyTankHealth>();

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Soldier"))
        {
            Health enemyHealth = other.gameObject.GetComponent<Health>();
            SoldierMovement enemyMovement = other.gameObject.GetComponent<SoldierMovement>();

            if (tankHealthScript != null && tankHealthScript.isAlive)
            {

                if (enemyHealth != null)
                {
                    enemyHealth.HP -= damageAmount;
                }
            }
            else
            {

                if (enemyMovement != null)
                {
                    Vector3 newPosition = enemyMovement.transform.position;
                    newPosition.z += 6f;
                    enemyMovement.transform.position = newPosition;
                }
            }
        }


        if (other.gameObject.CompareTag("Trench"))
        {
            tankMovementScript = enemyTank.GetComponent<EnemyTankMovement>();

            Debug.Log("tank touch");
            tankMovementScript.speed = 0f;

        }

    }
}
