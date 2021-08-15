using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainUI : MonoBehaviour
{
    public GameObject mainScreen;
    public GameObject settingScreen;
    public GameObject exitScreen;


    public void gameStartButton()
    {
        SceneManager.LoadScene("MapLoadTest");
    }
    public void SettingButton()
    {
        settingScreen.SetActive(true);
        mainScreen.SetActive(false);
    }
    public void SettingOutButton()
    {
        settingScreen.SetActive(false);
        mainScreen.SetActive(true);
    }
    public void ExitQuestionButton()
    {
        exitScreen.SetActive(true);
        mainScreen.SetActive(false);
    }
    public void ExitYesButton()
    {
        Application.Quit();
    }
    public void ExitNoButton()
    {
        exitScreen.SetActive(false);
        mainScreen.SetActive(true);
    }
}
