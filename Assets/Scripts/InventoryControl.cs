using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//static class Constants
//{
//    public static readonly Vector2 BLOCKSIZE = new Vector2(200, 75);
//    public static readonly Vector2 BLOCKGAP = new Vector2(10, 10);

//    public static readonly Vector2 ARMORSIZE = new Vector2(2, 2);
//    public static readonly Vector2 SHIELDSIZE = new Vector2(1, 2);
//    public static readonly Vector2 SHOESIZE = new Vector2(2, 1);
//    public static readonly Vector2 SWORDSIZE = new Vector2(1, 3);
//    public static readonly Vector2 RINGSIZE = new Vector2(1, 1);
//    public static readonly Vector2 MAPSIZE = new Vector2(4, 9);

//    public static readonly Vector2 ARMORMAX = new Vector2(3, 8);
//    public static readonly Vector2 SHIELDMAX = new Vector2(4, 8);
//    public static readonly Vector2 SHOEMAX = new Vector2(3, 9);
//    public static readonly Vector2 SWORDMAX = new Vector2(4, 7);
//    public static readonly Vector2 RINGMAX = new Vector2(4, 9);
//}


public class InventoryControl : MonoBehaviour
{
    [Header("#장비아이템"), SerializeField]
    private GameObject Armor;
    [SerializeField]
    private GameObject Shield, Shoe, Sword, Ring;
    public GameObject item;

    //[Header("#타겟"), SerializeField]
    //private GameObject Target;

    #region Position List
    [HideInInspector]
    public List<Vector2> armorPosList = new List<Vector2>();
    [HideInInspector]
    public List<Vector2> shieldPosList = new List<Vector2>();
    [HideInInspector]
    public List<Vector2> shoePosList = new List<Vector2>();
    [HideInInspector]
    public List<Vector2> swordPosList = new List<Vector2>();
    [HideInInspector]
    public List<Vector2> ringPosList = new List<Vector2>();
    [HideInInspector]
    public List<bool> occupiedRect = new List<bool>();
    #endregion

    #region Pointer List
    [HideInInspector]
    public List<Vector2> armorPointerList = new List<Vector2>();
    [HideInInspector]
    public List<Vector2> shieldPointerList = new List<Vector2>();
    [HideInInspector]
    public List<Vector2> shoePointerList = new List<Vector2>();
    [HideInInspector]
    public List<Vector2> swordPointerList = new List<Vector2>();
    [HideInInspector]
    public List<Vector2> ringPointerList = new List<Vector2>();
    #endregion

    private void Init()
    {
        //Armor
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                armorPosList.Add(new Vector2(-210 + 210 * i, -297.5f + 85 * j));
            }
        }
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                armorPointerList.Add(new Vector2(855 + 210 * i, 285 + 85 * j));
            }
        }

        //Shield
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                shieldPosList.Add(new Vector2(-315 + 210 * i, -297.5f + 85 * j));
            }
        }
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                shieldPointerList.Add(new Vector2(750 + 210 * i, 285 + 85 * j));
            }
        }

        //Shoe
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                shoePosList.Add(new Vector2(-210 + 210 * i, -340 + 85 * j));
            }
        }
        for (int i = 0; i < 3 - 1; i++)
        {
            for (int j = 0; j < 9 - 1; j++)
            {
                shoePointerList.Add(new Vector2(855 + 210 * i, 242.5f + 85 * j));
            }
        }

        //Sword
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                swordPosList.Add(new Vector2(-315 + 210 * i, -255 + 85 * j));
            }
        }
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                swordPointerList.Add(new Vector2(750 + 210 * i, 327.5f + 85 * j));
            }
        }

        //Ring
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                ringPosList.Add(new Vector2(-315 + 210 * i, -340 + 85 * j));
            }
        }
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                ringPointerList.Add(new Vector2(750 + 210 * i, 242.5f + 85 * j));
            }
        }

        //possiblePos
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                occupiedRect.Add(false);
            }
        }
    }


    private void Awake()
    {
        Init();
    }

    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Input.mousePosition);
    }

    void Spawn()
    {
        SpawnArmor();
        //SpawnSword();
        //SpawnShield();
        //SpawnShoe();
        //SpawnRing();
    }


    void SpawnArmor()
    {
        int k = 0;
        int[] randArray = getRandomInt(armorPosList.Count, 0, armorPosList.Count);
        int ran = randArray[k];
        while (k < armorPosList.Count)
        {
            if (ran < 8)
            {
                if (!occupiedRect[ran] && !occupiedRect[ran + 1] && !occupiedRect[ran + 9] && !occupiedRect[ran + 10])
                {
                    var go = Instantiate(Armor, armorPosList[ran], Quaternion.identity);
                    go.transform.SetParent(item.transform, false);
                    occupiedRect[ran] = true;
                    occupiedRect[ran + 1] = true;
                    occupiedRect[ran + 9] = true;
                    occupiedRect[ran + 10] = true;
                    return;
                }
                else
                {
                    k++;
                    ran = randArray[k];
                }
            }
            else if (ran < 16)
            {
                if (!occupiedRect[ran + 1] && !occupiedRect[ran + 2] && !occupiedRect[ran + 10] && !occupiedRect[ran + 11])
                {
                    var go = Instantiate(Armor, armorPosList[ran], Quaternion.identity);
                    go.transform.SetParent(item.transform, false);
                    occupiedRect[ran + 1] = true;
                    occupiedRect[ran + 2] = true;
                    occupiedRect[ran + 10] = true;
                    occupiedRect[ran + 11] = true;
                    return;
                }
                else
                {
                    k++;
                    ran = randArray[k];
                }
            }
            else
            {
                if (!occupiedRect[ran + 2] && !occupiedRect[ran + 3] && !occupiedRect[ran + 11] && !occupiedRect[ran + 12])
                {
                    var go = Instantiate(Armor, armorPosList[ran], Quaternion.identity);
                    go.transform.SetParent(item.transform, false);
                    occupiedRect[ran + 2] = true;
                    occupiedRect[ran + 3] = true;
                    occupiedRect[ran + 11] = true;
                    occupiedRect[ran + 12] = true;
                    return;
                }
                else
                {
                    k++;
                    ran = randArray[k];
                }
            }
        }
    }

    void SpawnSword()
    {
        int k = 0;
        int[] randArray = getRandomInt(swordPosList.Count, 0, swordPosList.Count);
        int ran = randArray[k];
        while (k < swordPosList.Count)
        {
            if (ran < 7)
            {
                if (!occupiedRect[ran] && !occupiedRect[ran + 1] && !occupiedRect[ran + 2])
                {
                    var go = Instantiate(Sword, swordPosList[ran], Quaternion.identity);
                    go.transform.SetParent(item.transform, false);
                    occupiedRect[ran] = true;
                    occupiedRect[ran + 1] = true;
                    occupiedRect[ran + 2] = true;
                    return;
                }
                else
                {
                    k++;
                    ran = randArray[k];
                }
            }
            else if (ran < 14)
            {
                if (!occupiedRect[ran + 2] && !occupiedRect[ran + 3] && !occupiedRect[ran + 4])
                {
                    var go = Instantiate(Sword, swordPosList[ran], Quaternion.identity);
                    go.transform.SetParent(item.transform, false);
                    occupiedRect[ran + 2] = true;
                    occupiedRect[ran + 3] = true;
                    occupiedRect[ran + 4] = true;
                    return;
                }
                else
                {
                    k++;
                    ran = randArray[k];
                }
            }
            else if (ran < 21)
            {
                if (!occupiedRect[ran + 4] && !occupiedRect[ran + 5] && !occupiedRect[ran + 6])
                {
                    var go = Instantiate(Sword, swordPosList[ran], Quaternion.identity);
                    go.transform.SetParent(item.transform, false);
                    occupiedRect[ran + 4] = true;
                    occupiedRect[ran + 5] = true;
                    occupiedRect[ran + 6] = true;
                    return;
                }
                else
                {
                    k++;
                    ran = randArray[k];
                }
            }
            else
            {
                if (!occupiedRect[ran + 6] && !occupiedRect[ran + 7] && !occupiedRect[ran + 8])
                {
                    var go = Instantiate(Sword, swordPosList[ran], Quaternion.identity);
                    go.transform.SetParent(item.transform, false);
                    occupiedRect[ran + 6] = true;
                    occupiedRect[ran + 7] = true;
                    occupiedRect[ran + 8] = true;
                    return;
                }
                else
                {
                    k++;
                    ran = randArray[k];
                }
            }
        }
    }

    void SpawnShield()
    {
        int k = 0;
        int[] randArray = getRandomInt(shieldPosList.Count, 0, shieldPosList.Count);
        int ran = randArray[k];
        while (k < shieldPosList.Count)
        {
            if (ran < 8)
            {
                if (!occupiedRect[ran] && !occupiedRect[ran + 1])
                {
                    var go = Instantiate(Shield, shieldPosList[ran], Quaternion.identity);
                    go.transform.SetParent(item.transform, false);
                    occupiedRect[ran] = true;
                    occupiedRect[ran + 1] = true;
                    return;
                }
                else
                {
                    k++;
                    ran = randArray[k];
                }
            }
            else if (ran < 16)
            {
                if (!occupiedRect[ran + 1] && !occupiedRect[ran + 2])
                {
                    var go = Instantiate(Shield, shieldPosList[ran], Quaternion.identity);
                    go.transform.SetParent(item.transform, false);
                    occupiedRect[ran + 1] = true;
                    occupiedRect[ran + 2] = true;
                    return;
                }
                else
                {
                    k++;
                    ran = randArray[k];
                }
            }
            else if (ran < 24)
            {
                if (!occupiedRect[ran + 2] && !occupiedRect[ran + 3])
                {
                    var go = Instantiate(Shield, shieldPosList[ran], Quaternion.identity);
                    go.transform.SetParent(item.transform, false);
                    occupiedRect[ran + 2] = true;
                    occupiedRect[ran + 3] = true;
                    return;
                }
                else
                {
                    k++;
                    ran = randArray[k];
                }
            }
            else
            {
                if (!occupiedRect[ran + 3] && !occupiedRect[ran + 4])
                {
                    var go = Instantiate(Shield, shieldPosList[ran], Quaternion.identity);
                    go.transform.SetParent(item.transform, false);
                    occupiedRect[ran + 3] = true;
                    occupiedRect[ran + 4] = true;
                    return;
                }
                else
                {
                    k++;
                    ran = randArray[k];
                }
            }
        }
    }

    void SpawnShoe()
    {
        int k = 0;
        int[] randArray = getRandomInt(shoePosList.Count, 0, shoePosList.Count);
        int ran = randArray[k];
        while (k < shoePosList.Count)
        {
            if (!occupiedRect[ran] && !occupiedRect[ran + 9])
            {
                var go = Instantiate(Shoe, shoePosList[ran], Quaternion.identity);
                go.transform.SetParent(item.transform, false);
                occupiedRect[ran] = true;
                occupiedRect[ran + 9] = true;
                return;
            }
            else
            {
                k++;
                ran = randArray[k];
            }
        }
    }

    void SpawnRing()
    {
        int k = 0;
        int[] randArray = getRandomInt(ringPosList.Count, 0, ringPosList.Count);
        int ran = randArray[k];
        while (k < ringPosList.Count)
        {
            if (!occupiedRect[ran])
            {
                var go = Instantiate(Ring, ringPosList[ran], Quaternion.identity);
                go.transform.SetParent(item.transform, false);
                occupiedRect[ran] = true;
                return;
            }
            else
            {
                k++;
                ran = randArray[k];
            }
        }
    }

    public int[] getRandomInt(int length, int min, int max)
    {
        int[] randArray = new int[length];
        bool isSame;

        for (int i = 0; i < length; ++i)
        {
            while (true)
            {
                randArray[i] = Random.Range(min, max);
                isSame = false;

                for (int j = 0; j < i; ++j)
                {
                    if (randArray[j] == randArray[i])
                    {
                        isSame = true;
                        break;
                    }
                }
                if (!isSame) break;
            }
        }
        return randArray;
    }


}

