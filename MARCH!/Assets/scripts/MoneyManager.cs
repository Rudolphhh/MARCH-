using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public TextMeshProUGUI moneyText;
    public int money = 200;
    private float timeSinceLastIncome = 0f;

    void Start()
    {
        UpdateMoneyText(); // Aktualizace textu při startu
    }

    void Update()
    {
        // Přidá 7 peněz každou sekundu
        timeSinceLastIncome += Time.deltaTime;
        if (timeSinceLastIncome >= 1f)
        {
            money += 7;
            UpdateMoneyText();
            timeSinceLastIncome = 0f;
        }
    }

    // Metoda pro odečtení peněz
    public void OdectiPenize(int hodnotaOdecitanychPenez)
    {
        if (money >= hodnotaOdecitanychPenez)
        {
            money -= hodnotaOdecitanychPenez;
            UpdateMoneyText();
        }
        else
        {
            Debug.Log("Nedostatek peněz! Peníze nemohou jít pod nulu.");
        }
    }

    // Aktualizuje text zobrazující aktuální hodnotu peněz
    private void UpdateMoneyText()
    {
        moneyText.text = money.ToString();
    }
}
