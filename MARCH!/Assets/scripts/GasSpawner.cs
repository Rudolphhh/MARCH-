using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasSpawner : MonoBehaviour
{
    public GameObject gasPrefab;
    public Collider validZone;
    private bool isSpawningGas = false;
    public MoneyManager moneyManager;


    public void Start()
    {
        moneyManager = FindObjectOfType<MoneyManager>();
    }
    
    public void EnableGasPlacement()
    {

        if (moneyManager.money >= 125)
        {
            isSpawningGas = true;
            moneyManager.OdectiPenize(125);
                
        }

        
    }

    private void Update()
    {
        if (isSpawningGas && Input.GetMouseButtonDown(0))
        {
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                
                if (hit.collider == validZone)
                {
                    SpawnGas(hit.point);
                    isSpawningGas = false;
                }
                
            }
        }
    }

    private void SpawnGas(Vector3 position)
    {
        
        GameObject spawnedGas = Instantiate(gasPrefab, position, Quaternion.identity);

        
        Destroy(spawnedGas, 10f);
    }


}
