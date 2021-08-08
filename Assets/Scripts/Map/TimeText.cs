using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeText : MonoBehaviour
{

    public Text timeText;
    
    private float time;
    private int min;
    private void Start()
    {
        min = 0;
    }
    private void Update()
    {
        time += Time.deltaTime;
        if (time >= 60){
            min = min + 1;
            time = time - 60;
        }
        timeText.text = "½Ã°£: " +"\n"+(min).ToString()+":"+(Mathf.FloorToInt(time) ).ToString();
    }
}