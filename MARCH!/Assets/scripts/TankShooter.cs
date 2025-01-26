using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShooter : MonoBehaviour
{
    [SerializeField]
    private GameObject BulletPrefab;
    [SerializeField]
    private Transform firePoint;
    [SerializeField]
    private float BulletSpeed = 30f;
    [SerializeField]
    private float reloadTime = 8f;
    [SerializeField]
    private float detectionRadius = 20f;
    [SerializeField]
    private float explosionRadius = 5f;
    [SerializeField]
    private int explosionDamage = 200;
    [SerializeField]
    private GameObject explosionEffectPrefab;

    private bool isReloading = false;
    private List<Transform> enemies = new List<Transform>();
    private Transform currentTarget;

    private void Update()
    {
        DetectEnemies();

        if (currentTarget != null)
        {
            AimAtCurrentTarget();
            TryShoot(currentTarget);
        }
    }

    private void DetectEnemies()
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

    private void AimAtCurrentTarget()
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

    public void TryShoot(Transform enemyTarget)
    {
        if (!isReloading && enemyTarget != null)
        {
            Shoot(enemyTarget);
            StartCoroutine(ReloadCoroutine());
        }
    }

    private void Shoot(Transform enemyTarget)
    {
        if (enemyTarget == null)
            return;

        Vector3 targetPosition = enemyTarget.position - new Vector3(0, -4f, 0);
        Vector3 directionToTarget = targetPosition - firePoint.position;
        Vector3 adjustedDirection = directionToTarget.normalized;

        GameObject projectile = Instantiate(BulletPrefab, firePoint.position, Quaternion.identity);

        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = adjustedDirection * BulletSpeed;
        }

        TankBullet tankProjectile = projectile.GetComponent<TankBullet>();
        if (tankProjectile != null)
        {
            tankProjectile.Setup(explosionRadius, explosionDamage, explosionEffectPrefab);
        }
    }



    private IEnumerator ReloadCoroutine()
    {
        isReloading = true;
        yield return new WaitForSeconds(reloadTime);
        isReloading = false;
    }
}
