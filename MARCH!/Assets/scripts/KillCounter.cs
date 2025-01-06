using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KillCounter : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro1;
    public TextMeshProUGUI textMeshPro2;

    public int enemiesKilled;

    private void Awake()
    {
        UpdateKillText();
    }

    // Metoda pro zvýšení počtu zabitých nepřátel
    public void AddKill()
    {
        enemiesKilled++;
        UpdateKillText();
    }

    // Aktualizuje text
    private void UpdateKillText()
    {
        textMeshPro1.text = "You killed: " + enemiesKilled;
        textMeshPro2.text = "You killed: " + enemiesKilled;
    }

}
