using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject Rifler;
    public GameObject Gunner;
    public GameObject Sniper;

    public List<Transform> spawnPoints;                   
    private List<Transform> remainingPoints;              

    MoneyManager moneyManager;

    private void Start()
    {
        moneyManager = FindObjectOfType<MoneyManager>();

        ResetAndShuffleSpawnPoints();
    }

    public void SpawnRifler()
    {
        if (moneyManager.money >= 10)
        {
            moneyManager.OdectiPenize(10);
            if (remainingPoints.Count == 0)
            {

                ResetAndShuffleSpawnPoints();
            }


            Transform spawnPoint = remainingPoints[0];
            remainingPoints.RemoveAt(0);


            Quaternion rotationOffset = Quaternion.Euler(0, 90, 0);
            Quaternion spawnRotation = spawnPoint.rotation * rotationOffset;


            Instantiate(Rifler, spawnPoint.position, spawnRotation);
        }
        
    }

    public void SpawnGunner()
    {
        if (moneyManager.money >= 20)
        {
            moneyManager.OdectiPenize(20);
            if (remainingPoints.Count == 0)
            {

                ResetAndShuffleSpawnPoints();
            }


            Transform spawnPoint = remainingPoints[0];
            remainingPoints.RemoveAt(0);


            Quaternion rotationOffset = Quaternion.Euler(0, 90, 0);
            Quaternion spawnRotation = spawnPoint.rotation * rotationOffset;


            Instantiate(Gunner, spawnPoint.position, spawnRotation);
        }
        
    }
    public void SpawnSniper()
    {
        if(moneyManager.money >= 35)
        {
            moneyManager.OdectiPenize(35);
            if (remainingPoints.Count == 0)
            {

                ResetAndShuffleSpawnPoints();
            }


            Transform spawnPoint = remainingPoints[0];
            remainingPoints.RemoveAt(0);


            Quaternion rotationOffset = Quaternion.Euler(0, 90, 0);
            Quaternion spawnRotation = spawnPoint.rotation * rotationOffset;


            Instantiate(Sniper, spawnPoint.position, spawnRotation);
        }
        
        
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
