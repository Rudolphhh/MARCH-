using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadManager : MonoBehaviour
{
    public static string sceneToLoad;

    public static void LoadScene(string sceneName)
    {
        sceneToLoad = sceneName;
        SceneManager.LoadScene("LoadingScene");
    }
}
