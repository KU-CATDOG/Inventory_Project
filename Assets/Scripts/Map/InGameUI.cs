using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    public GameObject gameScreen;
    public GameObject pauseScreen;
    public GameObject settingScreen;
    public GameObject exitScreen;
    
    public void PauseButton()
    {
        pauseScreen.SetActive(true);
        gameScreen.SetActive(false);
    }
    public void ContinueButton()
    {
        pauseScreen.SetActive(false);
        gameScreen.SetActive(true);
    }

    public void SettingButton()
    {
        settingScreen.SetActive(true);
        pauseScreen.SetActive(false);
    }
    public void SettingOutButton()
    {
        settingScreen.SetActive(false);
        pauseScreen.SetActive(true);
    }
    public void ExitQuestionButton()
    {
        exitScreen.SetActive(true);
        pauseScreen.SetActive(false);
    }
    public void ExitYesButton()
    {
        Application.Quit();
    }
    public void ExitNoButton()
    {
        exitScreen.SetActive(false);
        pauseScreen.SetActive(true);
    }
}
