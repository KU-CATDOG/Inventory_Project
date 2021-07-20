using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSave : MonoBehaviour
{
    public Text timeTxt;
    public Text scoreTxt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Save()
    {
        PlayerPrefs.SetInt("Score", int.Parse(timeTxt.text));
        scoreTxt.text = PlayerPrefs.GetInt("Score").ToString();
    }
}
