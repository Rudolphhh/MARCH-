
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrenchSpawner : MonoBehaviour
{
    public GameObject trenchPrefab;
    public GameObject trenchButtonPrefab;
    public GameObject trenchPreviewPrefab;
    public Collider spawnZone;
    public GameObject trenchControls;
    MoneyManager moneyManager;
    private bool isSpawning = false;
    private GameObject previewTrench;
    private int trenchCount = 0;
    private int maxTrenches = 3;
    private List<GameObject> trenches = new List<GameObject>();

    private void Start()
    {
        moneyManager = FindObjectOfType<MoneyManager>();
    }


    void Update()
    {
        if (isSpawning && trenchCount < maxTrenches)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            bool canPlace = spawnZone.Raycast(ray, out hit, Mathf.Infinity);

            if (canPlace)
            {
                Vector3 spawnPosition = hit.point;
                spawnPosition.y = -0.1600004f;
                spawnPosition.z = -2.111162f;

                
                bool isFarEnoughFromTrenches = true;
                foreach (var trench in trenches)
                {
                    if (Mathf.Abs(trench.transform.position.x - spawnPosition.x) < 11f)
                    {
                        isFarEnoughFromTrenches = false;
                        break;
                    }
                }

                
                bool isAreaClearOfSoldiers = true;
                Collider[] nearbyColliders = Physics.OverlapSphere(spawnPosition, 6f);
                foreach (var collider in nearbyColliders)
                {
                    if (collider.CompareTag("Soldier") )
                    {
                        isAreaClearOfSoldiers = false;
                        break;
                    }
                }

                bool isAreaClearOfEnemySoldiers = true;
                Collider[] nearbyEnemyColliders = Physics.OverlapSphere(spawnPosition, 6f);
                foreach (var collider in nearbyColliders)
                {
                    if (collider.CompareTag("EnemySoldier"))
                    {
                        isAreaClearOfEnemySoldiers = false;
                        break;
                    }
                }

                if (isFarEnoughFromTrenches && isAreaClearOfSoldiers && isAreaClearOfEnemySoldiers)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        var trench = Instantiate(trenchPrefab, spawnPosition, Quaternion.identity);
                        trenches.Add(trench);

                        var button = Instantiate(trenchButtonPrefab, trenchControls.transform);
                        TrenchControlsMenu tb = button.GetComponent<TrenchControlsMenu>();
                        TrenchUIPoint t = trench.GetComponent<TrenchUIPoint>();
                        tb.SetTrench(t);

                        Destroy(previewTrench);
                        isSpawning = false;
                        trenchCount++;
                    }
                    else
                    {
                        if (previewTrench == null)
                        {
                            previewTrench = Instantiate(trenchPreviewPrefab, spawnPosition, Quaternion.identity);
                            SetPreviewMaterial(previewTrench, true);
                        }
                        else
                        {
                            previewTrench.transform.position = spawnPosition;
                            SetPreviewMaterial(previewTrench, true);
                        }
                    }
                }
                else
                {
                    if (previewTrench != null)
                    {
                        SetPreviewMaterial(previewTrench, false);
                    }
                }
            }
            else
            {
                if (previewTrench != null)
                {
                    SetPreviewMaterial(previewTrench, false);
                }
            }
        }
    }

    public void StartSpawning()
    {
        if (moneyManager.money >= 100)
        {
            if (trenchCount < maxTrenches)
            {
                isSpawning = true;
                moneyManager.OdectiPenize(100);
                if (previewTrench != null)
                {
                    Destroy(previewTrench);
                }
            }
            else
            {
                Debug.Log("Maximální počet zákopů již byl dosažen.");
            }
        }
        
    }

    private void SetPreviewMaterial(GameObject previewObject, bool canPlace)
    {
        var renderers = previewObject.GetComponentsInChildren<Renderer>();
        foreach (var renderer in renderers)
        {
            Color color = canPlace ? Color.green : Color.red;
            color.a = 0.5f;
            renderer.material.color = color;
        }
    }



}

