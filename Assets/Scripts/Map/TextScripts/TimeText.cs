using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeText : MonoBehaviour
{

    public Text timeText;
    public MapTag Tag;
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
        timeText.text = (Tag.tag).ToString()+"층에서 \n 보낸 시간: " +(min).ToString()+":"+(Mathf.FloorToInt(time) ).ToString();
    }
}