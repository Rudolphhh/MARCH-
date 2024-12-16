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
    }
}
