using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoSetting : MonoBehaviour
{
    private GameObject MainUI;
    private GameObject SettingUI;
    private GameObject ExitUI;

    // Start is called before the first frame update

    public void goSetting()
    {
        MainUI = GameObject.Find("MainMenu");
        SettingUI = GameObject.Find("SettingImage(temp)");
        ExitUI = GameObject.Find("ExitImage");
        MainUI.SetActive(false);
        SettingUI.SetActive(true);
        ExitUI.SetActive(false);
    }
}
