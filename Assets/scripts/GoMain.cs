using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Application.Quit();
//gameObject.SetActive(false);






public class GoMain : MonoBehaviour
{
    private GameObject MainUI;
    private GameObject SettingUI;
    private GameObject ExitUI;

    // Start is called before the first frame update

    public void goMain()
    {
        MainUI = GameObject.Find("MainMenu");
        SettingUI = GameObject.Find("SettingImage(temp)");
        ExitUI = GameObject.Find("ExitImage");
        MainUI.SetActive(true);
        SettingUI.SetActive(false);
        ExitUI.SetActive(false);
    }


}



