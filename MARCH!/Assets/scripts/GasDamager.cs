using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasDamager : MonoBehaviour
{
    public int damageAmount = 25;
    public float damageInterval = 0.5f;

    private HashSet<EnemyHealth> enemiesInGas = new HashSet<EnemyHealth>();

    private void Start()
    {
        
        StartCoroutine(DamageEnemiesOverTime());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemySoldier"))
        {
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemiesInGas.Add(enemyHealth);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("EnemySoldier"))
        {
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
            if (enemyHealth != null && enemiesInGas.Contains(enemyHealth))
            {
                enemiesInGas.Remove(enemyHealth);
            }
        }
    }

    private IEnumerator DamageEnemiesOverTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(damageInterval);

            foreach (var enemy in enemiesInGas)
            {
                if (enemy != null)
                {
                    enemy.HP -= damageAmount;
                }
            }
        }
    }
}
