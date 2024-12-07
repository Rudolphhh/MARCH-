using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamager : MonoBehaviour
{
    public int damageAmount = 100; // Set damage amount

    // This method is called when the bullet enters a trigger collider
    void OnTriggerEnter(Collider other)
    {
        // Check if the collided object has the "enemySoldier" tag
        if (other.gameObject.CompareTag("Soldier"))
        {
            // Get the EnemyHealth component from the collided object
            Health soldierHelth = other.gameObject.GetComponent<Health>();

            // If the component exists, apply damage
            if (soldierHelth != null)
            {
                soldierHelth.HP -= damageAmount; // Subtract health from the enemy
                
            }

            // Destroy the bullet (optional)
            Destroy(gameObject);
        }
    }
}
