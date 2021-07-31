using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainUI : MonoBehaviour
{
    public void gameStartButton()
    {
        SceneManager.LoadScene("map0");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
