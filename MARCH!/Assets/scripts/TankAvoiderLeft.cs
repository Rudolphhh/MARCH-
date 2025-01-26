using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAvoiderLeft : MonoBehaviour
{
    public float moveSpeed = 2f;
    private bool isInZone = false;
    private Transform enemy;

    private void Update()
    {
        
        if (isInZone && enemy != null)
        {
            enemy.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("EnemySoldier"))
        {
            isInZone = true;
            enemy = other.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
        if (other.CompareTag("EnemySoldier"))
        {
            isInZone = false;
            enemy = null;
        }
    }
}
