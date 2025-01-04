using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCaptures : MonoBehaviour
{
    public int captures = 3;


    public GameObject loseScreen;


    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("EnemySoldier"))
        {

            captures--;

            Debug.Log("Zbývající captures: " + captures);


            if (captures <= 0)
            {
                ShowLoseScreen();
            }
        }
    }


    private void ShowLoseScreen()
    {
        Debug.Log("Prohra!");
        if (loseScreen != null)
        {
            loseScreen.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            Debug.LogWarning("LoseScreen není přiřazen v Inspectoru!");
        }
    }
}
