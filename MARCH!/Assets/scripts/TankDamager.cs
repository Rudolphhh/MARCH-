using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankDamager : MonoBehaviour
{
    public GameObject tank;
    public int damageAmount = 200;
    private TankHealth tankHealthScript;
    private TankMovement tankMovementScript;

    void Start()
    {

        tankHealthScript = tank.GetComponent<TankHealth>();

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EnemySoldier"))
        {
            EnemyHealth enemyHealth = other.gameObject.GetComponent<EnemyHealth>();
            EnemyMovement enemyMovement = other.gameObject.GetComponent<EnemyMovement>();

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
            tankMovementScript = tank.GetComponent<TankMovement>();

            Debug.Log("tank touch");
            tankMovementScript.speed = 0f;
            
        }

    }
}
