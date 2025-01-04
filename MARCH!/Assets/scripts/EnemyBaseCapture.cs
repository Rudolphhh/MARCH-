using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
            UnlockNewLevl();
            Time.timeScale = 0f;
        }
        else
        {
            Debug.LogWarning("WinScreen není přiřazen v Inspectoru!");
        }
    }

    void UnlockNewLevl()
    {
        if(SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedIndex"))
        {
            PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("UnlockedLevl", PlayerPrefs.GetInt("UnlockedLevl", 1) + 1);
            PlayerPrefs.Save();
        }
    }



}
