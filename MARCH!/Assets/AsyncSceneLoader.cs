using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AsyncSceneLoader : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(LoadAsync());
    }

    IEnumerator LoadAsync()
    {
        string sceneName = loadManager.sceneToLoad;

        if (string.IsNullOrEmpty(sceneName))
        {
            Debug.LogError("⚠️ Žádná cílová scéna není nastavena!");
            yield break;
        }

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        while (!operation.isDone)
        {
            yield return null;
        }
    }
}
