using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour
{
    public int damageAmount = 100; // Set damage amount

    // This method is called when the bullet enters a trigger collider
    void OnTriggerEnter(Collider other)
    {
        // Check if the collided object has the "enemySoldier" tag
        if (other.gameObject.CompareTag("EnemySoldier"))
        {
            // Get the EnemyHealth component from the collided object
            EnemyHealth enemyHealth = other.gameObject.GetComponent<EnemyHealth>();

            // If the component exists, apply damage
            if (enemyHealth != null)
            {
                enemyHealth.HP -= damageAmount; // Subtract health from the enemy
                Debug.Log("hitted");
            }

            // Destroy the bullet (optional)
            Destroy(gameObject);
        }
    }
}
