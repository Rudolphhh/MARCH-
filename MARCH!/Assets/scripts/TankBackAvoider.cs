using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankBackAvoider : MonoBehaviour
{
    public GameObject tank;
    private TankHealth tankHealthScript;

    void Start()
    {
        tankHealthScript = tank.GetComponent<TankHealth>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Soldier"))
        {
            NormalSoldier soldier = other.gameObject.GetComponent<NormalSoldier>();

            if (tankHealthScript != null && tankHealthScript.isAlive)
            {
                Vector3 newPosition = soldier.transform.position;
                newPosition.z += 6f;
                soldier.transform.position = newPosition;
            }
            else
            {
                // Pokud je tank mrtvý, posuň vojáka po Z ose
                if (soldier != null)
                {
                    Vector3 newPosition = soldier.transform.position;
                    newPosition.z += 4f;
                    soldier.transform.position = newPosition;

                }
            }
        }
    }
}
