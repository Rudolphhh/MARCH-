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


    private void Start()
    {
        
        ResetAndShuffleSpawnPoints();
    }

    public void SpawnRifler()
    {
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

    public void SpawnGunner()
    {
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
    public void SpawnSniper()
    {
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
