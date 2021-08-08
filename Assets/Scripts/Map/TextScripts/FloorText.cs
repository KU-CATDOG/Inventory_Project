using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloorText : MonoBehaviour
{
    
    public Text FloorUI;
    public MapTag Tag;
    

    // Update is called once per frame
    void Update()
    {
        FloorUI.text = (Tag.tag).ToString()+"Ãþ";
    }
}

