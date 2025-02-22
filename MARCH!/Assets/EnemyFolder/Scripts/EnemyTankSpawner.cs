using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankSpawner : MonoBehaviour
{

    public GameObject Enemytank;

    public List<Transform> spawnPoints;

    public float spawnInterval = 40f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("EnemySpawnTank", spawnInterval, spawnInterval);
    }

    // Update is called once per frame
    public void EnemySpawnTank()
    {

        
        Transform selectedSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)];
        Quaternion spawnRotation = Quaternion.Euler(0, 270, 0);

        Instantiate(Enemytank, selectedSpawnPoint.position, spawnRotation);
        
    }
}
