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
        timeSpentText.text = (TimeCount.min).ToString() + ":" + (Mathf.FloorToInt(TimeCount.time)).ToString() + " ���� �÷����ϼ̽��ϴ�.";
    }
    private void Update()
    {
        
        
    }
}