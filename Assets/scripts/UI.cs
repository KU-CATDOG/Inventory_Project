using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UI : MonoBehaviour
{
    public GameObject MainUI;
    public GameObject SettingUI;
    public GameObject ExitUI;
    
    void Start()
    {
        MainUI.SetActive(true);
        SettingUI.SetActive(false);
        ExitUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        


    }
    
}
