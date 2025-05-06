using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalniTitulky : MonoBehaviour
{
    // Jméno scény, na kterou se má přepnout
    public string sceneName;

    // Tuto metodu můžeš napojit na tlačítko ve Unity (OnClick)
    public void SwitchScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
