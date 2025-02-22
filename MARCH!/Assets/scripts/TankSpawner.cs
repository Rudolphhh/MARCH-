using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class TankSpawner : MonoBehaviour
{
    public GameObject tank;

    public List<Transform> spawnPoints;

    private MoneyManager moneyManager;

    private void Start()
    {
        // Najdi MoneyManager ve scéně
        moneyManager = FindObjectOfType<MoneyManager>();
        
    }

    public void SpawnTank()
    {
        
        if (moneyManager.money >= 200)
        {
            
            moneyManager.OdectiPenize(200);

            
            Transform selectedSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)];
            Quaternion spawnRotation = Quaternion.Euler(0, 90, 0);

            Instantiate(tank, selectedSpawnPoint.position, spawnRotation);
        }
    }
}
