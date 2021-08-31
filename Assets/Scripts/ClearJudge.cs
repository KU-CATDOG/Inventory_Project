using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearJudge : MonoBehaviour
{
    Player player;
    MonsterClass[] Monster;
    public bool Clear = false;
    public bool GameOver = false;
    public GameObject curRoom;
    public testInvCon inv;
    MapLoadTest load;

    int befPlayerPos = -1;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>().GetComponent<Player>();
        Monster = FindObjectsOfType<MonsterClass>();
        load = FindObjectOfType<MapLoadTest>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inv.playerPosition != befPlayerPos)
        {
            befPlayerPos = inv.playerPosition;
            if (inv.occupiedRect_sword[inv.playerPosition] == 0)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (load.swordInstObject[i].name == "name")
                    {
                        curRoom = load.swordInstObject[i - 1];
                        break;
                    }
                }
            }
            if (inv.occupiedRect_shoe[inv.playerPosition] == 0)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (load.shoeInstObject[i].name == "name")
                    {
                        curRoom = load.shoeInstObject[i - 1];
                        break;
                    }
                }
            }
            if (inv.occupiedRect_shield[inv.playerPosition] == 0)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (load.shieldInstObject[i].name == "name")
                    {
                        curRoom = load.shieldInstObject[i - 1];
                        break;
                    }
                }
            }
            if (inv.occupiedRect_ring[inv.playerPosition] == 0)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (load.ringInstObject[i].name == "name")
                    {
                        curRoom = load.ringInstObject[i - 1];
                        break;
                    }
                }
            }
            if (inv.occupiedRect_armor[inv.playerPosition] == 0)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (load.armorInstObject[i].name == "name")
                    {
                        curRoom = load.armorInstObject[i - 1];
                        break;
                    }
                }
            }
        }

        if (player.health <= 0 && !GameOver)
        {
            GameOver = true;
            Debug.Log("GameOver");
        }

        int Cnt = curRoom.GetComponent<EnemyCounter>().MonsterCount;
        if (Cnt == 0 && !Clear)
        {
            Clear = true;
            Debug.Log("Clear");
        }
        if (Cnt != 0 && Clear)
        {
            Clear = false;
            Debug.Log("not Clear");
        }
    }
}
