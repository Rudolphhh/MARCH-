using Palmmedia.ReportGenerator.Core.Parser.Analysis;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrenchSpawner : MonoBehaviour
{
    public GameObject trenchPrefab;
    public GameObject trenchButtonPrefab;
    public Collider spawnZone;
    private bool isSpawning = false;

    public GameObject trenchControls;

    void Update()
    {
        
        if (isSpawning && Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Ověříme, zda bylo kliknuto uvnitř zóny
            if (spawnZone.Raycast(ray, out hit, Mathf.Infinity))
            {
                
                Vector3 spawnPosition = hit.point;
                spawnPosition.y = -0.1600004f;
                spawnPosition.z = -2.111162f;

                
                var trench = Instantiate(trenchPrefab, spawnPosition, Quaternion.identity);
                var button = Instantiate(trenchButtonPrefab, trenchControls.transform);

                
                TrenchControlsMenu tb = button.GetComponent<TrenchControlsMenu>();
                TrenchUIPoint t = trench.GetComponent<TrenchUIPoint>();

                // Set trench to the button
                tb.SetTrench(t);

                isSpawning = false;
            }
        }
    }

    
    public void StartSpawning()
    {
        isSpawning = true;
    }


}

