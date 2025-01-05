using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseButttonMenu : MonoBehaviour
{
    public GameObject PauseMenu;

    public void PauseButton()
    {

        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        
    }

    public void UnPauseButton()
    {

        PauseMenu.SetActive(false);
        Time.timeScale = 1f;

    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }
    public void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentSceneIndex + 1);
        Time.timeScale = 1f;
    }

    public void LoadCurrentLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentSceneIndex);
        Time.timeScale = 1f;
    }

}
