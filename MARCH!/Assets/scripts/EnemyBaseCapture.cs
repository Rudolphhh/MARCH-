using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyBaseCapture : MonoBehaviour
{
    
    public int captures = 3;

    
    public GameObject winScreen;

    
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Soldier"))
        {
            
            captures--;

            Debug.Log("Zbývající captures: " + captures);

            
            if (captures <= 0)
            {
                ShowWinScreen();
            }
        }
    }

    
    private void ShowWinScreen()
    {
        Debug.Log("Vítězství!");
        if (winScreen != null)
        {
            winScreen.SetActive(true);
        }
        else
        {
            Debug.LogWarning("WinScreen není přiřazen v Inspectoru!");
        }
    }

}
