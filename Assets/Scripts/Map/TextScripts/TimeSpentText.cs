using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeSpentText : MonoBehaviour
{

    public Text timeSpentText;
    public TimeText TimeCount;
    
    private void Start()
    {
        timeSpentText.text = (TimeCount.min).ToString() + ":" + (Mathf.FloorToInt(TimeCount.time)).ToString() + " 동안 플레이하셨습니다.";
    }
    private void Update()
    {
        
        
    }
}