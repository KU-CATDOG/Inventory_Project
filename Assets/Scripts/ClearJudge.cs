using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearJudge : MonoBehaviour
{
    Player player;
    MonsterClass[] Monster;
    public bool Clear = false;
    public bool GameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>().GetComponent<Player>();
        Monster = FindObjectsOfType<MonsterClass>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.health <= 0 && !GameOver)
        {
            GameOver = true;
            Debug.Log("GameOver");
        }

        Monster = FindObjectsOfType<MonsterClass>();
        if (Monster.Length == 0 && !Clear)
        {
            Clear = true;
            Debug.Log("Clear");
        }
    }
}
