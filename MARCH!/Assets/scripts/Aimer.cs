using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aimer : MonoBehaviour
{
    [SerializeField]
    public float detectionRadius = 10f; // Detection range for enemies
    public Shooter shooter; // Reference to Shooter script

    private List<Transform> enemies = new List<Transform>();
    private Transform currentTarget;

    void Update()
    {
        DetectEnemies();

        if (currentTarget != null)
        {
            AimAtCurrentTarget();
            shooter.TryShoot(); // Attempt to shoot at the current target
        }
    }

    void DetectEnemies()
    {
        Collider[] detectedObjects = Physics.OverlapSphere(transform.position, detectionRadius);

        // Clear the list of enemies
        enemies.Clear();

        // Add objects with the tag "EnemySoldier" to the list
        foreach (var obj in detectedObjects)
        {
            if (obj.CompareTag("EnemySoldier"))
            {
                enemies.Add(obj.transform);
            }
        }

        // Update the current target
        currentTarget = enemies.Count > 0 ? enemies[0] : null;
    }

    void AimAtCurrentTarget()
    {
        if (currentTarget != null)
        {
            // Přidání offsetu pro zaměření na hrudník místo nohou
            Vector3 offset = new Vector3(0, 2f, 0); // Upravte hodnotu Y dle výšky nepřítele
            Vector3 direction = (currentTarget.position + offset - transform.position).normalized;

            // Rotace směrem k cíli
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);

            // Kontrola, zda je současný cíl stále platný
            if (currentTarget == null || !currentTarget.CompareTag("EnemySoldier"))
            {
                enemies.Remove(currentTarget);
                currentTarget = enemies.Count > 0 ? enemies[0] : null;
            }
        }
    }
}
