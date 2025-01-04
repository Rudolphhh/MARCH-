using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{
    public Button[] firstSectionButtons;
    public Button[] secondSectionButtons;
    public Button[] thirdSectionButtons;

    private void Awake()
    {
        
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevl", 1);
        bool isSecondSectionUnlocked = PlayerPrefs.GetInt("SecondSectionUnlocked", 0) == 1;
        bool isThirdSectionUnlocked = PlayerPrefs.GetInt("ThirdSectionUnlocked", 0) == 1;

        
        for (int i = 0; i < firstSectionButtons.Length; i++)
        {
            firstSectionButtons[i].interactable = i < unlockedLevel;
        }

        
        if (unlockedLevel > firstSectionButtons.Length && !isSecondSectionUnlocked)
        {
            PlayerPrefs.SetInt("SecondSectionUnlocked", 1);
            isSecondSectionUnlocked = true;
        }

        
        for (int i = 0; i < secondSectionButtons.Length; i++)
        {
            secondSectionButtons[i].interactable = isSecondSectionUnlocked && i < (unlockedLevel - firstSectionButtons.Length);
        }

        
        if (unlockedLevel > firstSectionButtons.Length + secondSectionButtons.Length && !isThirdSectionUnlocked)
        {
            PlayerPrefs.SetInt("ThirdSectionUnlocked", 1);
            isThirdSectionUnlocked = true;
        }

        
        for (int i = 0; i < thirdSectionButtons.Length; i++)
        {
            thirdSectionButtons[i].interactable = isThirdSectionUnlocked && i < (unlockedLevel - firstSectionButtons.Length - secondSectionButtons.Length);
        }
    }


    public void SerbianOpenLevel(int levelId)
    {
        string levelName = "SerbianFront" + levelId;
        SceneManager.LoadScene(levelName);
    }

    public void RussianOpenLevel(int levelId)
    {
        string levelName = "RussianFront" + levelId;
        SceneManager.LoadScene(levelName);
    }

    public void FrenchOpenLevel(int levelId)
    {
        string levelName = "FrenchFront" + levelId;
        SceneManager.LoadScene(levelName);
    }



}
