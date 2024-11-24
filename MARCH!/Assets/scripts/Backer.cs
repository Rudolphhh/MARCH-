using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backer : MonoBehaviour
{
    private List<GameObject> soldiersInTheRangeOfGoingBackToTrench = new List<GameObject>();

    
    private TrenchLocker trenchlocker;

    void Start()
    {
        
        trenchlocker = FindObjectOfType<TrenchLocker>();

        
        
    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Soldier"))
        {
            if (!soldiersInTheRangeOfGoingBackToTrench.Contains(other.gameObject))
            {
                soldiersInTheRangeOfGoingBackToTrench.Add(other.gameObject);
                Debug.Log("Soldier is in the range of going back.");

            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (soldiersInTheRangeOfGoingBackToTrench.Contains(other.gameObject))
        {
            soldiersInTheRangeOfGoingBackToTrench.Remove(other.gameObject);
            Debug.Log("Soldier is out of the range of going back.");
        }
    }

    
    public void GoingBackToTheTrench()
    {
        
        foreach (GameObject soldierObj in soldiersInTheRangeOfGoingBackToTrench)
        {
            NormalSoldier soldier = soldierObj.GetComponent<NormalSoldier>();

            
            if (!trenchlocker.isLocked)
            {
                soldier.GoingBack();

            }
            else
            {
                Debug.Log("Trench is locked, soldier cannot go back.");
                return;
            }
        }
    }
}
