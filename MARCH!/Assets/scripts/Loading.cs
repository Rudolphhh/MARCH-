using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Loading : MonoBehaviour
{
    public TextMeshProUGUI marchText;
    public float updateInterval = 1f;

    private int exclamationCount = 1;

    void Start()
    {
        StartCoroutine(UpdateMarchText());
    }

    IEnumerator UpdateMarchText()
    {
        while (true)
        {
            
            marchText.text = "MARCH" + new string('!', exclamationCount);

            
            exclamationCount++;
            if (exclamationCount > 3)
                exclamationCount = 1;

            yield return new WaitForSeconds(updateInterval);
        }
    }
}
