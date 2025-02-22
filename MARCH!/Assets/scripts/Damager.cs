using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour
{

    public int damageAmount = 100;

    
    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("EnemySoldier"))
        {
            
            EnemyHealth enemyHealth = other.gameObject.GetComponent<EnemyHealth>();

            
            if (enemyHealth != null)
            {
                enemyHealth.HP -= damageAmount;
                
            }

            
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("EnemySoldier"))
        {

            EnemyTankHealth soldierHelth = other.gameObject.GetComponent<EnemyTankHealth>();


            if (soldierHelth != null)
            {
                soldierHelth.HP -= damageAmount;

            }


            Destroy(gameObject);
        }
    }


}
