using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEndText : MonoBehaviour
{
    public ClearJudge clearJudge;
    public Text gameEndText;

    // Start is called before the first frame update
    void Start()
    {
        if (clearJudge.GameOver)
        {
            gameEndText.text = "�׾����ϴ�!";
        }
        else
        {
            gameEndText.text = "���� Ŭ����!";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
