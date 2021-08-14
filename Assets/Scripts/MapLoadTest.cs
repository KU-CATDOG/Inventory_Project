using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapLoadTest : MonoBehaviour
{
    public testInvCon invCon;
    public GameObject grid;
    private List<int> itemLocationList;
    public List<GameObject> armorMap;
    public List<GameObject> shieldMap;
    public List<GameObject> swordMap;
    public List<GameObject> shoeMap;
    public List<GameObject> ringMap;
    public List<int> spawnedRect_armor = new List<int>();
    public List<int> spawnedRect_shield = new List<int>();
    public List<int> spawnedRect_sword = new List<int>();
    public List<int> spawnedRect_shoe = new List<int>();
    public List<int> spawnedRect_ring = new List<int>();
    private List<GameObject> instObjs = new List<GameObject>();
    private GameObject armorInstObject;
    private GameObject shieldInstObject;
    private GameObject swordInstObject;
    private GameObject shoeInstObject;
    private GameObject ringInstObject;

    // Start is called before the first frame update
    void Start()
    {
        itemLocationList = invCon.itemLocationList;
        for (int i = 0; i < 36; i++)
        {
            spawnedRect_armor.Add(-1);
            spawnedRect_shield.Add(-1);
            spawnedRect_sword.Add(-1);
            spawnedRect_shoe.Add(-1);
            spawnedRect_ring.Add(-1);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// currently available for only one item per type
    /// </summary>
    public void SpawnMap()
    {
        List<int> positionList = new List<int>();
        for (int i = 0; i < 5; i++)
        {
            positionList.Add(-1);
        }
        for (int i = 0; i < 20; i++)
        {
            if (itemLocationList[i] != -1)
            {
                if (i < 4)
                {
                    for (int j = 0; j < 36; j++)
                    {
                        if (invCon.occupiedRect_armor[j] == i)
                        {
                            positionList[0] = j;
                            break;
                        }
                    }
                }
                else if (i < 8)
                {
                    for (int j = 0; j < 36; j++)
                    {
                        if (invCon.occupiedRect_shield[j] == i % 4)
                        {
                            positionList[1] = j;
                            break;
                        }
                    }
                }
                else if (i < 12)
                {
                    for (int j = 0; j < 36; j++)
                    {
                        if (invCon.occupiedRect_sword[j] == i % 4)
                        {
                            positionList[2] = j;
                            break;
                        }
                    }
                }
                else if (i < 16)
                {
                    for (int j = 0; j < 36; j++)
                    {
                        if (invCon.occupiedRect_shoe[j] == i % 4)
                        {
                            positionList[3] = j;
                            break;
                        }
                    }
                }
                else if (i < 20)
                {
                    for (int j = 0; j < 36; j++)
                    {
                        if (invCon.occupiedRect_ring[j] == i % 4)
                        {
                            positionList[4] = j;
                            break;
                        }
                    }
                }
            }
        }
        if (positionList[0] != -1)
        {
            int ran = Random.Range(0, armorMap.Count);
            int pos = CheckAdjacent(0, positionList[0]);
            if (pos != -1)
            {
                if (spawnedRect_armor[pos] == -1 && spawnedRect_armor[pos + 1] == -1 && spawnedRect_armor[pos + 9] == -1 && spawnedRect_armor[pos + 10] == -1)
                {
                    Debug.Log(pos);
                    Vector2 posVec2;
                    posVec2.x = (pos / 9 * 16) + 7;
                    posVec2.y = (pos % 9 * 9);
                    GameObject go = Instantiate(armorMap[ran], posVec2, Quaternion.identity);
                    go.transform.SetParent(grid.transform, false);
                    spawnedRect_armor[pos] = 0;
                    spawnedRect_armor[pos + 1] = 0;
                    spawnedRect_armor[pos + 9] = 0;
                    spawnedRect_armor[pos + 10] = 0;
                    armorInstObject = go;
                }

            }

        }

        //if (positionList[1] != -1)
        //{
        //    int ran = Random.Range(0, shieldMap.Count);
        //    int pos = CheckAdjacent(1, positionList[1]);
        //    if (pos != -1)
        //    {
        //        var go = Instantiate(shieldMap[ran], Vector2.zero, Quaternion.identity);
        //        go.transform.SetParent(grid.transform, false);
        //    }
        //}
        if (positionList[2] != -1)
        {
            int ran = Random.Range(0, swordMap.Count);
            int pos = CheckAdjacent(2, positionList[2]);
            if (pos != -1)
            {
                if (spawnedRect_sword[pos] == -1 && spawnedRect_sword[pos + 1] == -1 && spawnedRect_sword[pos + 2] == -1)
                {
                    Debug.Log(pos);
                    Vector2 posVec2;
                    posVec2.x = pos / 9 * 16;
                    posVec2.y = (pos % 9 * 9) + 9;
                    GameObject go = Instantiate(swordMap[ran], posVec2, Quaternion.identity);
                    go.transform.SetParent(grid.transform, false);
                    spawnedRect_sword[pos] = 0;
                    spawnedRect_sword[pos + 1] = 0;
                    spawnedRect_sword[pos + 2] = 0;
                    swordInstObject = go;
                }

                //else
                //{
                //    if (invCon.occupiedRect_sword[pos] != -1 && invCon.occupiedRect_sword[pos + 1] != -1 && invCon.occupiedRect_sword[pos + 2] != -1)
                //    {

                //    }
                //    else
                //    {
                //        Destroy(swordInstObject);
                //        spawnedRect_sword[pos] = -1;
                //        spawnedRect_sword[pos + 1] = -1;
                //        spawnedRect_sword[pos + 2] = -1;
                //    }
                //}

            }

        }
        if (positionList[3] != -1)
        {
            int ran = Random.Range(0, shoeMap.Count);
            int pos = CheckAdjacent(3, positionList[3]);
            if (pos != -1)
            {
                if (spawnedRect_shoe[pos] == -1 && spawnedRect_shoe[pos + 9] == -1)
                {
                    Debug.Log(pos);
                    Vector2 posVec2;
                    posVec2.x = (pos / 9 * 16) + 7;
                    posVec2.y = pos % 9 * 9;
                    GameObject go = Instantiate(shoeMap[ran], posVec2, Quaternion.identity);
                    go.transform.SetParent(grid.transform, false);
                    spawnedRect_shoe[pos] = 0;
                    spawnedRect_shoe[pos + 9] = 0;
                    shoeInstObject = go;
                }
                //else
                //{
                //    if (invCon.occupiedRect_shoe[pos] != -1 && invCon.occupiedRect_shoe[pos + 9] != -1)
                //    {

                //    }
                //    else
                //    {
                //        Destroy(shoeInstObject);
                //        spawnedRect_shoe[pos] = -1;
                //        spawnedRect_shoe[pos + 9] = -1;
                //    }
                //}

            }

        }
        //if (positionList[4] != -1)
        //{
        //    int ran = Random.Range(0, ringMap.Count);
        //    int pos = CheckAdjacent(4, positionList[4]);
        //    if (pos != -1)
        //    {
        //        var go = Instantiate(ringMap[ran], Vector2.zero, Quaternion.identity);
        //        go.transform.SetParent(grid.transform, false);
        //    }
        //}


    }

    public void DestroySpawnedMap()
    {
        for (int k = 0; k < 36; k++)
        {
            if (spawnedRect_armor[k] == 0)
            {
                if (invCon.occupiedRect_armor[k] == -1)
                {
                    Destroy(armorInstObject);
                    spawnedRect_armor[k] = -1;
                    spawnedRect_armor[k + 1] = -1;
                    spawnedRect_armor[k + 9] = -1;
                    spawnedRect_armor[k + 10] = -1;
                }
            }
            if (spawnedRect_shield[k] == 0)
            {
                if (invCon.occupiedRect_shield[k] == -1)
                {
                    Destroy(shieldInstObject);
                    spawnedRect_shield[k] = -1;
                    spawnedRect_shield[k + 1] = -1;
                }
            }
            if (spawnedRect_sword[k] == 0)
            {
                if (invCon.occupiedRect_sword[k] == -1)
                {
                    Destroy(swordInstObject);
                    spawnedRect_sword[k] = -1;
                    spawnedRect_sword[k + 1] = -1;
                    spawnedRect_sword[k + 2] = -1;
                }
            }
            if (spawnedRect_shoe[k] == 0)
            {
                if (invCon.occupiedRect_shoe[k] == -1)
                {
                    Destroy(shoeInstObject);
                    spawnedRect_shoe[k] = -1;
                    spawnedRect_shoe[k + 9] = -1;
                }
            }
            if (spawnedRect_ring[k] == 0)
            {
                if (invCon.occupiedRect_ring[k] == -1)
                {
                    Destroy(ringInstObject);
                    spawnedRect_ring[k] = -1;
                }
            }

        }
    }

    /// <summary>
    /// returns smallest coord of the cell, -1 if type not in range 0-4
    /// first argument: 0 for armor, 1 for shield, 2 for sword, 3 for shoe, 4 for ring
    /// second argument: known cell
    /// </summary>
    int CheckAdjacent(int type, int cell)
    {
        int returnVar = cell;
        if (type == 0)
        {
            if (cell - 10 >= 0)
            {
                if (invCon.occupiedRect_armor[cell - 10] == invCon.occupiedRect_armor[cell])
                {
                    if (returnVar > cell - 10)
                    {
                        returnVar = cell - 10;
                    }
                }
            }
            if (cell - 9 >= 0)
            {
                if (invCon.occupiedRect_armor[cell - 9] == invCon.occupiedRect_armor[cell])
                {
                    if (returnVar > cell - 9)
                    {
                        returnVar = cell - 9;
                    }
                }
            }
            if (cell - 9 >= 0)
            {
                if (invCon.occupiedRect_armor[cell - 8] == invCon.occupiedRect_armor[cell])
                {
                    if (returnVar > cell - 8)
                    {
                        returnVar = cell - 8;
                    }
                }
            }
            if (cell - 1 >= 0)
            {
                if (invCon.occupiedRect_armor[cell - 1] == invCon.occupiedRect_armor[cell])
                {
                    if (returnVar > cell - 1)
                    {
                        returnVar = cell - 1;
                    }
                }
            }
            if (cell + 1 < 36)
            {
                if (invCon.occupiedRect_armor[cell + 1] == invCon.occupiedRect_armor[cell])
                {
                    if (returnVar > cell + 1)
                    {
                        returnVar = cell + 1;
                    }
                }
            }
            if (cell + 8 < 36)
            {
                if (invCon.occupiedRect_armor[cell + 8] == invCon.occupiedRect_armor[cell])
                {
                    if (returnVar > cell + 8)
                    {
                        returnVar = cell + 8;
                    }
                }
            }
            if (cell + 9 < 36)
            {
                if (invCon.occupiedRect_armor[cell + 9] == invCon.occupiedRect_armor[cell])
                {
                    if (returnVar > cell + 9)
                    {
                        returnVar = cell + 9;
                    }
                }
            }
            if (cell + 10 < 36)
            {
                if (invCon.occupiedRect_armor[cell + 10] == invCon.occupiedRect_armor[cell])
                {
                    if (returnVar > cell + 10)
                    {
                        returnVar = cell + 10;
                    }
                }
            }
            return returnVar;
        }
        else if (type == 1)
        {
            if (cell - 10 >= 0)
            {
                if (invCon.occupiedRect_ring[cell - 10] == invCon.occupiedRect_ring[cell])
                {
                    if (returnVar > cell - 10)
                    {
                        returnVar = cell - 10;
                    }
                }
            }
            if (cell - 9 >= 0)
            {
                if (invCon.occupiedRect_ring[cell - 9] == invCon.occupiedRect_ring[cell])
                {
                    if (returnVar > cell - 9)
                    {
                        returnVar = cell - 9;
                    }
                }
            }
            if (cell - 9 >= 0)
            {
                if (invCon.occupiedRect_ring[cell - 8] == invCon.occupiedRect_ring[cell])
                {
                    if (returnVar > cell - 8)
                    {
                        returnVar = cell - 8;
                    }
                }
            }
            if (cell - 1 >= 0)
            {
                if (invCon.occupiedRect_ring[cell - 1] == invCon.occupiedRect_ring[cell])
                {
                    if (returnVar > cell - 1)
                    {
                        returnVar = cell - 1;
                    }
                }
            }
            if (cell + 1 < 36)
            {
                if (invCon.occupiedRect_ring[cell + 1] == invCon.occupiedRect_ring[cell])
                {
                    if (returnVar > cell + 1)
                    {
                        returnVar = cell + 1;
                    }
                }
            }
            if (cell + 8 < 36)
            {
                if (invCon.occupiedRect_ring[cell + 8] == invCon.occupiedRect_ring[cell])
                {
                    if (returnVar > cell + 8)
                    {
                        returnVar = cell + 8;
                    }
                }
            }
            if (cell + 9 < 36)
            {
                if (invCon.occupiedRect_ring[cell + 9] == invCon.occupiedRect_ring[cell])
                {
                    if (returnVar > cell + 9)
                    {
                        returnVar = cell + 9;
                    }
                }
            }
            if (cell + 10 < 36)
            {
                if (invCon.occupiedRect_ring[cell + 10] == invCon.occupiedRect_ring[cell])
                {
                    if (returnVar > cell + 10)
                    {
                        returnVar = cell + 10;
                    }
                }
            }
            return returnVar;
        }
        else if (type == 2)
        {
            if (cell - 10 >= 0)
            {
                if (invCon.occupiedRect_sword[cell - 10] == invCon.occupiedRect_sword[cell])
                {
                    if (returnVar > cell - 10)
                    {
                        returnVar = cell - 10;
                    }
                }
            }
            if (cell - 9 >= 0)
            {
                if (invCon.occupiedRect_sword[cell - 9] == invCon.occupiedRect_sword[cell])
                {
                    if (returnVar > cell - 9)
                    {
                        returnVar = cell - 9;
                    }
                }
            }
            if (cell - 9 >= 0)
            {
                if (invCon.occupiedRect_sword[cell - 8] == invCon.occupiedRect_sword[cell])
                {
                    if (returnVar > cell - 8)
                    {
                        returnVar = cell - 8;
                    }
                }
            }
            if (cell - 1 >= 0)
            {
                if (invCon.occupiedRect_sword[cell - 1] == invCon.occupiedRect_sword[cell])
                {
                    if (returnVar > cell - 1)
                    {
                        returnVar = cell - 1;
                    }
                }
            }
            if (cell + 1 < 36)
            {
                if (invCon.occupiedRect_sword[cell + 1] == invCon.occupiedRect_sword[cell])
                {
                    if (returnVar > cell + 1)
                    {
                        returnVar = cell + 1;
                    }
                }
            }
            if (cell + 8 < 36)
            {
                if (invCon.occupiedRect_sword[cell + 8] == invCon.occupiedRect_sword[cell])
                {
                    if (returnVar > cell + 8)
                    {
                        returnVar = cell + 8;
                    }
                }
            }
            if (cell + 9 < 36)
            {
                if (invCon.occupiedRect_sword[cell + 9] == invCon.occupiedRect_sword[cell])
                {
                    if (returnVar > cell + 9)
                    {
                        returnVar = cell + 9;
                    }
                }
            }
            if (cell + 10 < 36)
            {
                if (invCon.occupiedRect_sword[cell + 10] == invCon.occupiedRect_sword[cell])
                {
                    if (returnVar > cell + 10)
                    {
                        returnVar = cell + 10;
                    }
                }
            }
            return returnVar;
        }
        else if (type == 3)
        {
            if (cell - 10 >= 0)
            {
                if (invCon.occupiedRect_shoe[cell - 10] == invCon.occupiedRect_shoe[cell])
                {
                    if (returnVar > cell - 10)
                    {
                        returnVar = cell - 10;
                    }
                }
            }
            if (cell - 9 >= 0)
            {
                if (invCon.occupiedRect_shoe[cell - 9] == invCon.occupiedRect_shoe[cell])
                {
                    if (returnVar > cell - 9)
                    {
                        returnVar = cell - 9;
                    }
                }
            }
            if (cell - 9 >= 0)
            {
                if (invCon.occupiedRect_shoe[cell - 8] == invCon.occupiedRect_shoe[cell])
                {
                    if (returnVar > cell - 8)
                    {
                        returnVar = cell - 8;
                    }
                }
            }
            if (cell - 1 >= 0)
            {
                if (invCon.occupiedRect_shoe[cell - 1] == invCon.occupiedRect_shoe[cell])
                {
                    if (returnVar > cell - 1)
                    {
                        returnVar = cell - 1;
                    }
                }
            }
            if (cell + 1 < 36)
            {
                if (invCon.occupiedRect_shoe[cell + 1] == invCon.occupiedRect_shoe[cell])
                {
                    if (returnVar > cell + 1)
                    {
                        returnVar = cell + 1;
                    }
                }
            }
            if (cell + 8 < 36)
            {
                if (invCon.occupiedRect_shoe[cell + 8] == invCon.occupiedRect_shoe[cell])
                {
                    if (returnVar > cell + 8)
                    {
                        returnVar = cell + 8;
                    }
                }
            }
            if (cell + 9 < 36)
            {
                if (invCon.occupiedRect_shoe[cell + 9] == invCon.occupiedRect_shoe[cell])
                {
                    if (returnVar > cell + 9)
                    {
                        returnVar = cell + 9;
                    }
                }
            }
            if (cell + 10 < 36)
            {
                if (invCon.occupiedRect_shoe[cell + 10] == invCon.occupiedRect_shoe[cell])
                {
                    if (returnVar > cell + 10)
                    {
                        returnVar = cell + 10;
                    }
                }
            }
            return returnVar;
        }
        else if (type == 4)
        {
            if (cell - 10 >= 0)
            {
                if (invCon.occupiedRect_ring[cell - 10] == invCon.occupiedRect_ring[cell])
                {
                    if (returnVar > cell - 10)
                    {
                        returnVar = cell - 10;
                    }
                }
            }
            if (cell - 9 >= 0)
            {
                if (invCon.occupiedRect_ring[cell - 9] == invCon.occupiedRect_ring[cell])
                {
                    if (returnVar > cell - 9)
                    {
                        returnVar = cell - 9;
                    }
                }
            }
            if (cell - 9 >= 0)
            {
                if (invCon.occupiedRect_ring[cell - 8] == invCon.occupiedRect_ring[cell])
                {
                    if (returnVar > cell - 8)
                    {
                        returnVar = cell - 8;
                    }
                }
            }
            if (cell - 1 >= 0)
            {
                if (invCon.occupiedRect_ring[cell - 1] == invCon.occupiedRect_ring[cell])
                {
                    if (returnVar > cell - 1)
                    {
                        returnVar = cell - 1;
                    }
                }
            }
            if (cell + 1 < 36)
            {
                if (invCon.occupiedRect_ring[cell + 1] == invCon.occupiedRect_ring[cell])
                {
                    if (returnVar > cell + 1)
                    {
                        returnVar = cell + 1;
                    }
                }
            }
            if (cell + 8 < 36)
            {
                if (invCon.occupiedRect_ring[cell + 8] == invCon.occupiedRect_ring[cell])
                {
                    if (returnVar > cell + 8)
                    {
                        returnVar = cell + 8;
                    }
                }
            }
            if (cell + 9 < 36)
            {
                if (invCon.occupiedRect_ring[cell + 9] == invCon.occupiedRect_ring[cell])
                {
                    if (returnVar > cell + 9)
                    {
                        returnVar = cell + 9;
                    }
                }
            }
            if (cell + 10 < 36)
            {
                if (invCon.occupiedRect_ring[cell + 10] == invCon.occupiedRect_ring[cell])
                {
                    if (returnVar > cell + 10)
                    {
                        returnVar = cell + 10;
                    }
                }
            }
            return returnVar;
        }
        else return -1;
    }

    //public void CheckBegin()
    //{
    //    if (!invCon.occupiedRect[0])
    //    {
    //        Debug.Log("Cannot move player");
    //    }
    //    else
    //    {
    //        if (spawnedRect_armor[0] == -1 && spawnedRect_shield[0] == -1 && spawnedRect_shoe[0] == -1 && spawnedRect_sword[0] == -1 || spawnedRect_ring[0] == -1)
    //        {
    //            Debug.Log("Nothing is spawned yet");
    //        }
    //        else
    //        {
    //            invCon.playerPosition = 0;
    //        }
    //    }
    //}
}
