using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aimer : MonoBehaviour
{
    [SerializeField]
    public float detectionRadius = 10f;
    public Shooter shooter;

    private List<Transform> enemies = new List<Transform>();
    private Transform currentTarget;

    void Update()
    {
        DetectEnemies();

        if (currentTarget != null)
        {
            AimAtCurrentTarget();
            shooter.TryShoot();
        }
    }

    void DetectEnemies()
    {
        Collider[] detectedObjects = Physics.OverlapSphere(transform.position, detectionRadius);

        
        enemies.Clear();

        
        foreach (var obj in detectedObjects)
        {
            if (obj.CompareTag("EnemySoldier"))
            {
                enemies.Add(obj.transform);
            }
        }


        
        currentTarget = enemies.Count > 0 ? enemies[0] : null;
    }

    void AimAtCurrentTarget()
    {
        if (currentTarget != null)
        {
            
            Vector3 offset = new Vector3(0, 2f, 0);
            Vector3 direction = (currentTarget.position + offset - transform.position).normalized;

            
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);

            
            if (currentTarget == null || !currentTarget.CompareTag("EnemySoldier"))
            {
                enemies.Remove(currentTarget);
                currentTarget = enemies.Count > 0 ? enemies[0] : null;
            }
        }
    }
}
