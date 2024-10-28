using System.Collections;
using System.Collections.Generic;
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
        InvokeRepeating("HandleMarch", 1f, 1f);
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
        
        foreach (GameObject soldierObj in soldiersInTrench)
        {
            NormalSoldier soldier = soldierObj.GetComponent<NormalSoldier>();

            if (soldier != null)
            {
                Vector3 newPosition = soldier.transform.position;
                newPosition.x += 5;
                newPosition.y -= 0.6f;
                soldier.transform.position = newPosition;
                soldier.isInTrench = false;
                soldier.speed = 3;
                soldier.isGoingForward = true;
            }
        }
    }


    public void HandleMarch()
    {
        
        if (trenchlocker != null && trenchlocker.isLocked)
        {
            
            MarchForwardFromTheTrench();
        }
        else
        {
            Debug.Log("waiting for button click go");
        }
        
    }
}
