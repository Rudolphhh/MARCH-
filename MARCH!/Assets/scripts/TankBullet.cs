using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankBullet : MonoBehaviour
{
    private float explosionRadius;
    private int explosionDamage;
    private GameObject explosionEffectPrefab;

    public void Setup(float radius, int damage, GameObject effectPrefab)
    {
        explosionRadius = radius;
        explosionDamage = damage;
        explosionEffectPrefab = effectPrefab;
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        Explode();
    }

    private void Explode()
    {
        
        if (explosionEffectPrefab != null)
        {
            Instantiate(explosionEffectPrefab, transform.position, Quaternion.identity);
        }

        // Detekce objektů v dosahu výbuchu
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (var hitCollider in hitColliders)
        {
            
            if (hitCollider.CompareTag("EnemySoldier"))
            {
                EnemyHealth enemyHealth = hitCollider.GetComponent<EnemyHealth>();
                if (enemyHealth != null)
                {
                    enemyHealth.HP -= explosionDamage;
                }
            }
            if (hitCollider.CompareTag("Soldier"))
            {
                Health health = hitCollider.GetComponent<Health>();
                if (health != null)
                {
                    health.HP -= explosionDamage;
                }
            }
        }

        
        Destroy(gameObject);
    }
}
