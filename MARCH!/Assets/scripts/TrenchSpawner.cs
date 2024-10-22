using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrenchSpawner : MonoBehaviour
{
    public GameObject trenchPrefab; // Prefab zákopu
    public Collider spawnZone; // Kolizní zóna pro spawnování
    private bool isSpawning = false; // Označení, zda je ve stavu spawnování

    void Update()
    {
        // Pokud je povoleno spawnování a klikne se levým tlačítkem myši
        if (isSpawning && Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Ověříme, zda bylo kliknuto uvnitř zóny
            if (spawnZone.Raycast(ray, out hit, Mathf.Infinity))
            {
                // Získání pozice kliknutí a úprava souřadnic Y a Z
                Vector3 spawnPosition = hit.point;
                spawnPosition.y = -0.1600004f; // Nastavení Y na -3
                spawnPosition.z = -2.111162f; // Uzamčení Z na -1.17

                // Spawn prefabriku zákopu na upravené pozici
                Instantiate(trenchPrefab, spawnPosition, Quaternion.identity);
                isSpawning = false; // Vypneme stav spawnování po jednom umístění
            }
        }
    }

    // Funkce pro aktivaci spawnování
    public void StartSpawning()
    {
        isSpawning = true;
    }


}

