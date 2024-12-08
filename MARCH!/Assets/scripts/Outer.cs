using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using UnityEngine;
using UnityEngine.UI;

public class Outer : MonoBehaviour
{
    private List<GameObject> soldiersInTrench = new List<GameObject>();

    [SerializeField]
    private TrenchLocker trenchlocker;

    
    void Start()
    {
        
        if (trenchlocker == null)
        {
            trenchlocker = FindObjectOfType<TrenchLocker>();
        }
        InvokeRepeating("HandleMarch",2f, 2f);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Soldier"))
        {
            
            if (!soldiersInTrench.Contains(other.gameObject))
            {
                soldiersInTrench.Add(other.gameObject);
                Debug.Log("Player added to soldiersInTrench.");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Soldier"))
        {
            if (soldiersInTrench.Contains(other.gameObject))
            {
                soldiersInTrench.Remove(other.gameObject);
                Debug.Log("Player removed from soldiersInTrench.");
            }
        }
    }

    

    public void MarchForwardFromTheTrench()
    {

        for (int i = soldiersInTrench.Count - 1; i >= 0; i--)
        {
            GameObject soldierObj = soldiersInTrench[i];

            // Check if the soldier is null (destroyed)
            if (soldierObj == null)
            {
                soldiersInTrench.RemoveAt(i);
                Debug.Log("Removed a destroyed soldier from the list.");
                continue;
            }

            NormalSoldier soldier = soldierObj.GetComponent<NormalSoldier>();

            if (soldier != null)
            {
                Vector3 newPosition = soldier.transform.position;
                newPosition.x += 5;
                newPosition.y -= 0.6f;
                soldier.transform.position = newPosition;
                soldier.isInTrench = false;
                soldier.isGoingForward = true;

                if (soldier.name.Contains("Rifler"))
                {
                    soldier.speed = 2;
                }
                else if (soldier.name.Contains("Gunner"))
                {
                    soldier.speed = 1;
                }
                else if (soldier.name.Contains("Sniper"))
                {
                    soldier.speed = 2;
                }
            }
        }
    }


    public void HandleMarch()
    {
        if (trenchlocker != null && trenchlocker.isLocked)
        {
            Debug.Log("HandleMarch called with soldiers count: " + soldiersInTrench.Count);
            MarchForwardFromTheTrench();
        }
        else
        {
            Debug.Log("waiting for button click go");
        }
    }

}
