using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamager : MonoBehaviour
{
    public int damageAmount = 100;

    
    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Soldier"))
        {
            
            Health soldierHelth = other.gameObject.GetComponent<Health>();

            
            if (soldierHelth != null)
            {
                soldierHelth.HP -= damageAmount;
                
            }

            
            Destroy(gameObject);
        }
    }
}
