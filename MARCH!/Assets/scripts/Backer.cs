using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backer : MonoBehaviour
{
    private List<GameObject> soldiersInTheRangeOfGoingBackToTrench = new List<GameObject>();

    void Start()
    {

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
        if (other.CompareTag("Soldier"))
        {
            if (soldiersInTheRangeOfGoingBackToTrench.Contains(other.gameObject))
            {
                soldiersInTheRangeOfGoingBackToTrench.Remove(other.gameObject);
                Debug.Log("Soldier is out of the range of going back.");
            }
        }
    }

    // Method that gets called when the button is pressed
    public void GoingBackToTheTrench()
    {
        foreach (GameObject soldierObj in soldiersInTheRangeOfGoingBackToTrench)
        {
            NormalSoldier soldier = soldierObj.GetComponent<NormalSoldier>();

            if (soldier != null)
            {
                soldier.GoingBack();
            }
        }
    }
}
