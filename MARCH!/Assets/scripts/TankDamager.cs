using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankDamager : MonoBehaviour
{
    public GameObject tank;
    public int damageAmount = 200;
    private TankHealth tankHealthScript;

    void Start()
    {
        // Získáme referenci na skript TankHealth z tanku
        tankHealthScript = tank.GetComponent<TankHealth>();

    }
    
    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("EnemySoldier"))
        {

            EnemyHealth enemyHealth = other.gameObject.GetComponent<EnemyHealth>();


            if (enemyHealth != null)
            {
                enemyHealth.HP -= damageAmount;

            }


            
        }
    }
}
