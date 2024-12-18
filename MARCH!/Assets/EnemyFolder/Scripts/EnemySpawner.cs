using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyRifler;
    public GameObject enemyGunner;
    public GameObject enemySniper;

    public List<Transform> spawnPoints;
    private List<Transform> remainingPoints;

    public float spawnInterval = 20f;
    public int numEnemyRiflers = 3;
    public int numEnemyGunners = 2;
    public int numEnemySnipers = 1;

    private void Start()
    {
        ResetAndShuffleSpawnPoints();
        StartCoroutine(SpawnEnemiesRoutine());
    }

    private IEnumerator SpawnEnemiesRoutine()
    {
        while (true)
        {
            SpawnEnemies();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnEnemies()
    {
        for (int i = 0; i < numEnemyRiflers; i++)
        {
            SpawnEnemy(enemyRifler);
        }

        for (int i = 0; i < numEnemyGunners; i++)
        {
            SpawnEnemy(enemyGunner);
        }

        for (int i = 0; i < numEnemySnipers; i++)
        {
            SpawnEnemy(enemySniper);
        }
    }

    private void SpawnEnemy(GameObject enemyPrefab)
    {
        if (remainingPoints.Count == 0)
        {
            ResetAndShuffleSpawnPoints();
        }

        Transform spawnPoint = remainingPoints[0];
        remainingPoints.RemoveAt(0);

        Quaternion rotationOffset = Quaternion.Euler(0, -82, 0);
        Quaternion spawnRotation = spawnPoint.rotation * rotationOffset;

        Instantiate(enemyPrefab, spawnPoint.position, spawnRotation);
    }

    private void ResetAndShuffleSpawnPoints()
    {
        remainingPoints = new List<Transform>(spawnPoints);
        for (int i = 0; i < remainingPoints.Count; i++)
        {
            Transform temp = remainingPoints[i];
            int randomIndex = Random.Range(i, remainingPoints.Count);
            remainingPoints[i] = remainingPoints[randomIndex];
            remainingPoints[randomIndex] = temp;
        }
    }
}
