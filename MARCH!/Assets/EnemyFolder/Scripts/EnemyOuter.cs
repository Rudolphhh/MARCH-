using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyOuter : MonoBehaviour
{
    private List<GameObject> EnemysoldiersInTrench = new List<GameObject>();

    void Start()
    {

        InvokeRepeating("EnemyMarchForwardFromTheTrench", 10f, 10f);

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemySoldier"))
        {

            if (!EnemysoldiersInTrench.Contains(other.gameObject))
            {
                EnemysoldiersInTrench.Add(other.gameObject);
                Debug.Log("Enemy added to soldiersInTrench.");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("EnemySoldier"))
        {
            if (EnemysoldiersInTrench.Contains(other.gameObject))
            {
                EnemysoldiersInTrench.Remove(other.gameObject);
                Debug.Log("Enemy removed from soldiersInTrench.");
            }
        }
    }



    public void EnemyMarchForwardFromTheTrench()
    {

        for (int i = EnemysoldiersInTrench.Count - 1; i >= 0; i--)
        {
            GameObject soldierObj = EnemysoldiersInTrench[i];

            
            if (soldierObj == null)
            {
                EnemysoldiersInTrench.RemoveAt(i);
                Debug.Log("Removed a destroyed enemy from the list.");
                continue;
            }

            EnemyMovement soldier = soldierObj.GetComponent<EnemyMovement>();

            if (soldier != null)
            {
                Vector3 newPosition = soldier.transform.position;
                newPosition.x -= 5;
                newPosition.y -= 0.6f;
                soldier.transform.position = newPosition;
                soldier.isInTrench = false;
                soldier.isGoingForward = true;

                if (soldier.name.Contains("EnemyRifler"))
                {
                    soldier.speed = 2;
                }
                else if (soldier.name.Contains("EnemyGunner"))
                {
                    soldier.speed = 1;
                }
                else if (soldier.name.Contains("EnemySniper"))
                {
                    soldier.speed = 2;
                }
            }
        }

    }
}
