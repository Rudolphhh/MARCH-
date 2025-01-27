using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outer : MonoBehaviour
{
    private List<GameObject> soldiersInTrench = new List<GameObject>();
    private Dictionary<GameObject, int> originalHPs = new Dictionary<GameObject, int>(); // Sledování původních HP

    [SerializeField]
    private TrenchLocker trenchlocker;

    void Start()
    {
        if (trenchlocker == null)
        {
            trenchlocker = FindObjectOfType<TrenchLocker>();
        }
        InvokeRepeating("HandleMarch", 2f, 2f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Soldier"))
        {
            if (!soldiersInTrench.Contains(other.gameObject))
            {
                soldiersInTrench.Add(other.gameObject);
                Debug.Log("Player added to soldiersInTrench.");

                Health health = other.GetComponent<Health>();
                if (health != null)
                {
                    if (!originalHPs.ContainsKey(other.gameObject))
                    {
                        originalHPs[other.gameObject] = health.HP;
                    }
                    health.HP *= 2;
                    Debug.Log($"Soldier {other.name} HP doubled to {health.HP}.");
                }
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

                Health health = other.GetComponent<Health>();
                if (health != null && originalHPs.ContainsKey(other.gameObject))
                {
                    health.HP = originalHPs[other.gameObject];
                    Debug.Log($"Soldier {other.name} HP restored to {health.HP}.");
                    originalHPs.Remove(other.gameObject);
                }
            }
        }
    }

    public List<GameObject> GetSoldiersInTrench()
    {
        return soldiersInTrench;
    }

    public void MarchForwardFromTheTrench()
    {
        for (int i = soldiersInTrench.Count - 1; i >= 0; i--)
        {
            GameObject soldierObj = soldiersInTrench[i];

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