//#pragma warning disable IDE0090 // 'new(...)' ignore
//#pragma warning disable IDE0051 // 'new(...)' ignore
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using UnityEngine;




//public class testInvCon : MonoBehaviour
//{
//    [Header("#Wearable Items"), SerializeField]
//    private GameObject[] Armor = new GameObject[4];
//    [SerializeField]
//    private GameObject[] Shield = new GameObject[4];
//    [SerializeField]
//    private GameObject[] Shoe = new GameObject[4];
//    [SerializeField]
//    private GameObject[] Sword = new GameObject[4];
//    [SerializeField]
//    private GameObject[] Ring = new GameObject[4];
//    public GameObject item;
//    public GameObject playerPositionArrow;
//    public int playerPosition = 0;

//    [Header("#Ran Values")]
//    public List<int> armorRan = new List<int>();
//    public List<int> shieldRan = new List<int>();
//    public List<int> shoeRan = new List<int>();
//    public List<int> swordRan = new List<int>();
//    public List<int> ringRan = new List<int>();
//    public List<bool> displayArray;

//    #region Position List
//    [HideInInspector]
//    public List<Vector2> armorPosList = new List<Vector2>();
//    [HideInInspector]
//    public List<Vector2> shieldPosList = new List<Vector2>();
//    [HideInInspector]
//    public List<Vector2> shoePosList = new List<Vector2>();
//    [HideInInspector]
//    public List<Vector2> swordPosList = new List<Vector2>();
//    [HideInInspector]
//    public List<Vector2> ringPosList = new List<Vector2>();
//    [HideInInspector]
//    public List<bool> occupiedRect = new List<bool>();
//    public List<int> occupiedRect_armor = new List<int>();
//    public List<int> occupiedRect_shield = new List<int>();
//    public List<int> occupiedRect_sword = new List<int>();
//    public List<int> occupiedRect_shoe = new List<int>();
//    public List<int> occupiedRect_ring = new List<int>();
//    #endregion

//    #region Pointer List
//    [HideInInspector]
//    public List<Vector2> armorPointerList = new List<Vector2>();
//    [HideInInspector]
//    public List<Vector2> shieldPointerList = new List<Vector2>();
//    [HideInInspector]
//    public List<Vector2> shoePointerList = new List<Vector2>();
//    [HideInInspector]
//    public List<Vector2> swordPointerList = new List<Vector2>();
//    [HideInInspector]
//    public List<Vector2> ringPointerList = new List<Vector2>();
//    #endregion

//    private void Init()
//    {
//        //Armor
//        for (int i = 0; i < Constants.ARMORMAX.x; i++)
//        {
//            for (int j = 0; j < Constants.ARMORMAX.y; j++)
//            {
//                armorPosList.Add(new Vector2(-210 + (Constants.BLOCKSIZE.x + Constants.BLOCKGAP.x) * i, -297.5f + (Constants.BLOCKSIZE.y + Constants.BLOCKGAP.y) * j));
//            }
//        }
//        for (int i = 0; i < Constants.ARMORMAX.x - 1; i++)
//        {
//            for (int j = 0; j < Constants.ARMORMAX.y - 1; j++)
//            {
//                armorPointerList.Add(new Vector2(855 + (Constants.BLOCKSIZE.x + Constants.BLOCKGAP.x) * i, 285 + (Constants.BLOCKSIZE.y + Constants.BLOCKGAP.y) * j));
//            }
//        }

//        //Shield
//        for (int i = 0; i < Constants.SHIELDMAX.x; i++)
//        {
//            for (int j = 0; j < Constants.SHIELDMAX.y; j++)
//            {
//                shieldPosList.Add(new Vector2(-315 + (Constants.BLOCKSIZE.x + Constants.BLOCKGAP.x) * i, -297.5f + (Constants.BLOCKSIZE.y + Constants.BLOCKGAP.y) * j));
//            }
//        }
//        for (int i = 0; i < Constants.SHIELDMAX.x - 1; i++)
//        {
//            for (int j = 0; j < Constants.SHIELDMAX.y - 1; j++)
//            {
//                shieldPointerList.Add(new Vector2(750 + (Constants.BLOCKSIZE.x + Constants.BLOCKGAP.x) * i, 285 + (Constants.BLOCKSIZE.y + Constants.BLOCKGAP.y) * j));
//            }
//        }

//        //Shoe
//        for (int i = 0; i < Constants.SHOEMAX.x; i++)
//        {
//            for (int j = 0; j < Constants.SHOEMAX.y; j++)
//            {
//                shoePosList.Add(new Vector2(-210 + (Constants.BLOCKSIZE.x + Constants.BLOCKGAP.x) * i, -340 + (Constants.BLOCKSIZE.y + Constants.BLOCKGAP.y) * j));
//            }
//        }
//        for (int i = 0; i < Constants.SHOEMAX.x - 1; i++)
//        {
//            for (int j = 0; j < Constants.SHOEMAX.y - 1; j++)
//            {
//                shoePointerList.Add(new Vector2(855 + (Constants.BLOCKSIZE.x + Constants.BLOCKGAP.x) * i, 242.5f + (Constants.BLOCKSIZE.y + Constants.BLOCKGAP.y) * j));
//            }
//        }

//        //Sword
//        for (int i = 0; i < Constants.SWORDMAX.x; i++)
//        {
//            for (int j = 0; j < Constants.SWORDMAX.y; j++)
//            {
//                swordPosList.Add(new Vector2(-315 + (Constants.BLOCKSIZE.x + Constants.BLOCKGAP.x) * i, -255 + (Constants.BLOCKSIZE.y + Constants.BLOCKGAP.y) * j));
//            }
//        }
//        for (int i = 0; i < Constants.SWORDMAX.x - 1; i++)
//        {
//            for (int j = 0; j < Constants.SWORDMAX.y - 1; j++)
//            {
//                swordPointerList.Add(new Vector2(750 + (Constants.BLOCKSIZE.x + Constants.BLOCKGAP.x) * i, 327.5f + (Constants.BLOCKSIZE.y + Constants.BLOCKGAP.y) * j));
//            }
//        }

//        //Ring
//        for (int i = 0; i < Constants.RINGMAX.x; i++)
//        {
//            for (int j = 0; j < Constants.RINGMAX.y; j++)
//            {
//                ringPosList.Add(new Vector2(-315 + (Constants.BLOCKSIZE.x + Constants.BLOCKGAP.x) * i, -340 + (Constants.BLOCKSIZE.y + Constants.BLOCKGAP.y) * j));
//            }
//        }
//        for (int i = 0; i < Constants.RINGMAX.x - 1; i++)
//        {
//            for (int j = 0; j < Constants.RINGMAX.y - 1; j++)
//            {
//                ringPointerList.Add(new Vector2(750 + (Constants.BLOCKSIZE.x + Constants.BLOCKGAP.x) * i, 242.5f + (Constants.BLOCKSIZE.y + Constants.BLOCKGAP.y) * j));
//            }
//        }

//        //possiblePos
//        for (int i = 0; i < Constants.MAPSIZE.x; i++)
//        {
//            for (int j = 0; j < Constants.MAPSIZE.y; j++)
//            {
//                occupiedRect.Add(false);
//                occupiedRect_armor.Add(-1);
//                occupiedRect_shield.Add(-1);
//                occupiedRect_sword.Add(-1);
//                occupiedRect_shoe.Add(-1);
//                occupiedRect_ring.Add(-1);
//            }
//        }

//        for (int i = 0; i < 4; i++)
//        {
//            armorRan.Add(-1);
//            shieldRan.Add(-1);
//            swordRan.Add(-1);
//            shoeRan.Add(-1);
//            ringRan.Add(-1);
//        }
//    }


//    private void Awake()
//    {
//        Init();
//    }

//    // Start is called before the first frame update
//    void Start()
//    {
//        Spawn();
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        displayArray = occupiedRect;
//        DisplayPlayerPosition();
//    }

//    void Spawn()
//    {
//        SpawnArmor(0);
//        SpawnSword(0);
//        SpawnShield(0);
//        SpawnShoe(0);
//        SpawnRing(0);
//    }

//    void SpawnArmor(int i)
//    {
//        int k = 0;
//        int[] randArray = GetRandomInt(armorPosList.Count, 0, armorPosList.Count);
//        int ran = randArray[k];
//        while (k < armorPosList.Count)
//        {
//            if (ran < 8)
//            {
//                if (!occupiedRect[ran] && !occupiedRect[ran + 1] && !occupiedRect[ran + 9] && !occupiedRect[ran + 10])
//                {
//                    var go = Instantiate(Armor[i], armorPosList[ran], Quaternion.identity);
//                    go.transform.SetParent(item.transform, false);
//                    occupiedRect[ran] = true;
//                    occupiedRect[ran + 1] = true;
//                    occupiedRect[ran + 9] = true;
//                    occupiedRect[ran + 10] = true;
//                    occupiedRect_armor[ran] = i;
//                    occupiedRect_armor[ran + 1] = i;
//                    occupiedRect_armor[ran + 9] = i;
//                    occupiedRect_armor[ran + 10] = i;
//                    armorRan[i] = ran;
//                    return;
//                }
//                else
//                {
//                    k++;
//                    ran = randArray[k];
//                }
//            }
//            else if (ran < 16)
//            {
//                if (!occupiedRect[ran + 1] && !occupiedRect[ran + 2] && !occupiedRect[ran + 10] && !occupiedRect[ran + 11])
//                {
//                    var go = Instantiate(Armor[i], armorPosList[ran], Quaternion.identity);
//                    go.transform.SetParent(item.transform, false);
//                    occupiedRect[ran + 1] = true;
//                    occupiedRect[ran + 2] = true;
//                    occupiedRect[ran + 10] = true;
//                    occupiedRect[ran + 11] = true;
//                    occupiedRect_armor[ran + 1] = i;
//                    occupiedRect_armor[ran + 2] = i;
//                    occupiedRect_armor[ran + 10] = i;
//                    occupiedRect_armor[ran + 11] = i;
//                    armorRan[i] = ran;
//                    return;
//                }
//                else
//                {
//                    k++;
//                    ran = randArray[k];
//                }
//            }
//            else
//            {
//                if (!occupiedRect[ran + 2] && !occupiedRect[ran + 3] && !occupiedRect[ran + 11] && !occupiedRect[ran + 12])
//                {
//                    var go = Instantiate(Armor[i], armorPosList[ran], Quaternion.identity);
//                    go.transform.SetParent(item.transform, false);
//                    occupiedRect[ran + 2] = true;
//                    occupiedRect[ran + 3] = true;
//                    occupiedRect[ran + 11] = true;
//                    occupiedRect[ran + 12] = true;
//                    occupiedRect_armor[ran + 2] = i;
//                    occupiedRect_armor[ran + 3] = i;
//                    occupiedRect_armor[ran + 11] = i;
//                    occupiedRect_armor[ran + 12] = i;
//                    armorRan[i] = ran;
//                    return;
//                }
//                else
//                {
//                    k++;
//                    ran = randArray[k];
//                }
//            }
//        }

//    }
//    void SpawnSword(int i)
//    {
//        int k = 0;
//        int[] randArray = GetRandomInt(swordPosList.Count, 0, swordPosList.Count);
//        int ran = randArray[k];
//        while (k < swordPosList.Count)
//        {
//            if (ran < 7)
//            {
//                if (!occupiedRect[ran] && !occupiedRect[ran + 1] && !occupiedRect[ran + 2])
//                {
//                    var go = Instantiate(Sword[i], swordPosList[ran], Quaternion.identity);
//                    go.transform.SetParent(item.transform, false);
//                    occupiedRect[ran] = true;
//                    occupiedRect[ran + 1] = true;
//                    occupiedRect[ran + 2] = true;
//                    occupiedRect_sword[ran] = i;
//                    occupiedRect_sword[ran + 1] = i;
//                    occupiedRect_sword[ran + 2] = i;
//                    swordRan[i] = ran;
//                    return;
//                }
//                else
//                {
//                    k++;
//                    ran = randArray[k];
//                }
//            }
//            else if (ran < 14)
//            {
//                if (!occupiedRect[ran + 2] && !occupiedRect[ran + 3] && !occupiedRect[ran + 4])
//                {
//                    var go = Instantiate(Sword[i], swordPosList[ran], Quaternion.identity);
//                    go.transform.SetParent(item.transform, false);
//                    occupiedRect[ran + 2] = true;
//                    occupiedRect[ran + 3] = true;
//                    occupiedRect[ran + 4] = true;
//                    occupiedRect_sword[ran + 2] = i;
//                    occupiedRect_sword[ran + 3] = i;
//                    occupiedRect_sword[ran + 4] = i;
//                    swordRan[i] = ran;
//                    return;
//                }
//                else
//                {
//                    k++;
//                    ran = randArray[k];
//                }
//            }
//            else if (ran < 21)
//            {
//                if (!occupiedRect[ran + 4] && !occupiedRect[ran + 5] && !occupiedRect[ran + 6])
//                {
//                    var go = Instantiate(Sword[i], swordPosList[ran], Quaternion.identity);
//                    go.transform.SetParent(item.transform, false);
//                    occupiedRect[ran + 4] = true;
//                    occupiedRect[ran + 5] = true;
//                    occupiedRect[ran + 6] = true;
//                    occupiedRect_sword[ran + 4] = i;
//                    occupiedRect_sword[ran + 5] = i;
//                    occupiedRect_sword[ran + 6] = i;
//                    swordRan[i] = ran;
//                    return;
//                }
//                else
//                {
//                    k++;
//                    ran = randArray[k];
//                }
//            }
//            else
//            {
//                if (!occupiedRect[ran + 6] && !occupiedRect[ran + 7] && !occupiedRect[ran + 8])
//                {
//                    var go = Instantiate(Sword[i], swordPosList[ran], Quaternion.identity);
//                    go.transform.SetParent(item.transform, false);
//                    occupiedRect[ran + 6] = true;
//                    occupiedRect[ran + 7] = true;
//                    occupiedRect[ran + 8] = true;
//                    occupiedRect_sword[ran + 6] = i;
//                    occupiedRect_sword[ran + 7] = i;
//                    occupiedRect_sword[ran + 8] = i;
//                    swordRan[i] = ran;
//                    return;
//                }
//                else
//                {
//                    k++;
//                    ran = randArray[k];
//                }
//            }
//        }
//    }
//    void SpawnShield(int i)
//    {
//        int k = 0;
//        int[] randArray = GetRandomInt(shieldPosList.Count, 0, shieldPosList.Count);
//        int ran = randArray[k];
//        while (k < shieldPosList.Count)
//        {
//            if (ran < 8)
//            {
//                if (!occupiedRect[ran] && !occupiedRect[ran + 1])
//                {
//                    var go = Instantiate(Shield[i], shieldPosList[ran], Quaternion.identity);
//                    go.transform.SetParent(item.transform, false);
//                    occupiedRect[ran] = true;
//                    occupiedRect[ran + 1] = true;
//                    occupiedRect_shield[ran] = i;
//                    occupiedRect_shield[ran + 1] = i;
//                    shieldRan[i] = ran;
//                    return;
//                }
//                else
//                {
//                    k++;
//                    ran = randArray[k];
//                }
//            }
//            else if (ran < 16)
//            {
//                if (!occupiedRect[ran + 1] && !occupiedRect[ran + 2])
//                {
//                    var go = Instantiate(Shield[i], shieldPosList[ran], Quaternion.identity);
//                    go.transform.SetParent(item.transform, false);
//                    occupiedRect[ran + 1] = true;
//                    occupiedRect[ran + 2] = true;
//                    occupiedRect_shield[ran + 1] = i;
//                    occupiedRect_shield[ran + 2] = i;
//                    shieldRan[i] = ran;
//                    return;
//                }
//                else
//                {
//                    k++;
//                    ran = randArray[k];
//                }
//            }
//            else if (ran < 24)
//            {
//                if (!occupiedRect[ran + 2] && !occupiedRect[ran + 3])
//                {
//                    var go = Instantiate(Shield[i], shieldPosList[ran], Quaternion.identity);
//                    go.transform.SetParent(item.transform, false);
//                    occupiedRect[ran + 2] = true;
//                    occupiedRect[ran + 3] = true;
//                    occupiedRect_shield[ran + 2] = i;
//                    occupiedRect_shield[ran + 3] = i;
//                    shieldRan[i] = ran;
//                    return;
//                }
//                else
//                {
//                    k++;
//                    ran = randArray[k];
//                }
//            }
//            else
//            {
//                if (!occupiedRect[ran + 3] && !occupiedRect[ran + 4])
//                {
//                    var go = Instantiate(Shield[i], shieldPosList[ran], Quaternion.identity);
//                    go.transform.SetParent(item.transform, false);
//                    occupiedRect[ran + 3] = true;
//                    occupiedRect[ran + 4] = true;
//                    occupiedRect_shield[ran + 3] = i;
//                    occupiedRect_shield[ran + 4] = i;
//                    shieldRan[i] = ran;
//                    return;
//                }
//                else
//                {
//                    k++;
//                    ran = randArray[k];
//                }
//            }
//        }
//    }
//    void SpawnShoe(int i)
//    {
//        int k = 0;
//        int[] randArray = GetRandomInt(shoePosList.Count, 0, shoePosList.Count);
//        int ran = randArray[k];
//        while (k < shoePosList.Count)
//        {
//            if (!occupiedRect[ran] && !occupiedRect[ran + 9])
//            {
//                var go = Instantiate(Shoe[i], shoePosList[ran], Quaternion.identity);
//                go.transform.SetParent(item.transform, false);
//                occupiedRect[ran] = true;
//                occupiedRect[ran + 9] = true;
//                occupiedRect_ring[ran] = i;
//                occupiedRect_ring[ran + 9] = i;
//                shoeRan[i] = ran;
//                return;
//            }
//            else
//            {
//                k++;
//                ran = randArray[k];
//            }
//        }
//    }
//    void SpawnRing(int i)
//    {
//        int k = 0;
//        int[] randArray = GetRandomInt(ringPosList.Count, 0, ringPosList.Count);
//        int ran = randArray[k];
//        while (k < ringPosList.Count)
//        {
//            if (!occupiedRect[ran])
//            {
//                var go = Instantiate(Ring[i], ringPosList[ran], Quaternion.identity);
//                go.transform.SetParent(item.transform, false);
//                occupiedRect[ran] = true;
//                occupiedRect_ring[ran] = i;
//                ringRan[i] = ran;
//                return;
//            }
//            else
//            {
//                k++;
//                ran = randArray[k];
//            }
//        }
//    }

//    public int[] GetRandomInt(int length, int min, int max)
//    {
//        int[] randArray = new int[length];
//        bool isSame;
//        for (int i = 0; i < length; ++i)
//        {
//            while (true)
//            {
//                randArray[i] = Random.Range(min, max);
//                isSame = false;

//                for (int j = 0; j < i; ++j)
//                {
//                    if (randArray[j] == randArray[i])
//                    {
//                        isSame = true;
//                        break;
//                    }
//                }
//                if (!isSame) break;
//            }
//        }
//        return randArray;
//    }


//    public int GetPlayerPosition()
//    {
//        return playerPosition;
//    }


//    #region --PlayerPositionFunctions--
//    /// <summary>
//    /// temporary function
//    /// </summary>
//    public void PlayerPositionShiftUp()
//    {
//        if (playerPosition + 1 < 36 && occupiedRect[playerPosition + 1])
//        {
//            playerPosition += 1;
//        }
//        else
//        {
//            Debug.Log("Cannot move upwards");
//        }
//    }
//    /// <summary>
//    /// temporary function
//    /// </summary>
//    public void PlayerPositionShiftDown()
//    {
//        if (playerPosition - 1 >= 0 && occupiedRect[playerPosition - 1])
//        {
//            playerPosition -= 1;
//        }
//        else
//        {
//            Debug.Log("Cannot move downwards");
//        }
//    }
//    /// <summary>
//    /// temporary function
//    /// </summary>
//    public void PlayerPositionShiftLeft()
//    {
//        if (playerPosition - 9 >= 0 && occupiedRect[playerPosition - 9])
//        {
//            playerPosition -= 9;
//        }
//        else
//        {
//            Debug.Log("Cannot move left");
//        }
//    }
//    /// <summary>
//    /// temporary function
//    /// </summary>
//    public void PlayerPositionShiftRight()
//    {
//        if (playerPosition + 9 < 36 && occupiedRect[playerPosition + 9])
//        {
//            playerPosition += 9;
//        }
//        else
//        {
//            Debug.Log("Cannot move right");
//        }
//    }
//    #endregion

//    public void DisplayPlayerPosition()
//    {
//        if (playerPosition < 9)
//        {
//            for (int i = 0; i < 9; i++)
//            {
//                if (playerPosition == i)
//                {
//                    RectTransform rt = (RectTransform)playerPositionArrow.transform;
//                    rt.anchoredPosition = new Vector2(-315, -340 + i * 85);
//                }
//            }
//        }
//        else if (playerPosition < 18)
//        {
//            for (int i = 0; i < 9; i++)
//            {
//                if (playerPosition == 9 + i)
//                {
//                    RectTransform rt = (RectTransform)playerPositionArrow.transform;
//                    rt.anchoredPosition = new Vector2(-105, -340 + i * 85);
//                }
//            }
//        }
//        else if (playerPosition < 27)
//        {
//            for (int i = 0; i < 9; i++)
//            {
//                if (playerPosition == 18 + i)
//                {
//                    RectTransform rt = (RectTransform)playerPositionArrow.transform;
//                    rt.anchoredPosition = new Vector2(105, -340 + i * 85);
//                }
//            }
//        }
//        else
//        {
//            for (int i = 0; i < 9; i++)
//            {
//                if (playerPosition == 27 + i)
//                {
//                    RectTransform rt = (RectTransform)playerPositionArrow.transform;
//                    rt.anchoredPosition = new Vector2(315, -340 + i * 85);
//                }
//            }
//        }
//    }

//    public void GetNearbyItems()
//    {
//        List<int> currentRectList = new List<int>();
//        List<string> returnList = new List<string>();
//        int index = -1;                                         //0 for armor, 1 for shield, 2 for sword, 3 for shoe, 4 for ring
//        for (int i = 0; i < 36; i++)
//        {
//            if (playerPosition == i)
//            {
//                if (occupiedRect[playerPosition])
//                {
//                    if (occupiedRect_armor[playerPosition] != -1)
//                    {
//                        index = 0;
//                        for (int j = 0; j < 36; j++)
//                        {
//                            if (occupiedRect_armor[j] == occupiedRect_armor[playerPosition])
//                            {
//                                currentRectList.Add(j);
//                            }
//                        }
//                    }
//                    else if (occupiedRect_shield[playerPosition] != -1)
//                    {
//                        index = 1;
//                        for (int j = 0; j < 36; j++)
//                        {
//                            if (occupiedRect_shield[j] == occupiedRect_shield[playerPosition])
//                            {
//                                currentRectList.Add(j);
//                            }
//                        }
//                    }
//                    else if (occupiedRect_sword[playerPosition] != -1)
//                    {
//                        index = 2;
//                        for (int j = 0; j < 36; j++)
//                        {
//                            if (occupiedRect_sword[j] == occupiedRect_sword[playerPosition])
//                            {
//                                currentRectList.Add(j);
//                            }
//                        }
//                    }
//                    else if (occupiedRect_shoe[playerPosition] != -1)
//                    {
//                        index = 3;
//                        for (int j = 0; j < 36; j++)
//                        {
//                            if (occupiedRect_shoe[j] == occupiedRect_shoe[playerPosition])
//                            {
//                                currentRectList.Add(j);
//                            }
//                        }
//                    }
//                    else if (occupiedRect_ring[playerPosition] != -1)
//                    {
//                        index = 4;
//                        for (int j = 0; j < 36; j++)
//                        {
//                            if (occupiedRect_ring[j] == occupiedRect_ring[playerPosition])
//                            {
//                                currentRectList.Add(j);
//                            }
//                        }
//                    }
//                    else
//                    {
//                        Debug.Log("Value not valid");
//                    }
//                }
//                else
//                {
//                    Debug.Log("Player is not positioned on an item");
//                }
//            }
//        }
//        if (index != -1)
//        {
//            if (index == 0)
//            {
//                if (currentRectList[0] - 1 >= 0 && currentRectList[0] - 1 != 8 && currentRectList[0] - 1 != 17 && currentRectList[0] - 1 != 26)
//                {
//                    if (occupiedRect[currentRectList[0] - 1])
//                    {
//                        if (occupiedRect_armor[currentRectList[0] - 1] != -1)
//                        {
//                            returnList.Add("Armor" + occupiedRect_armor[currentRectList[0] - 1]);
//                        }
//                        else if (occupiedRect_shield[currentRectList[0] - 1] != -1)
//                        {
//                            returnList.Add("Shield" + occupiedRect_shield[currentRectList[0] - 1]);
//                        }
//                        else if (occupiedRect_sword[currentRectList[0] - 1] != -1)
//                        {
//                            returnList.Add("Sword" + occupiedRect_sword[currentRectList[0] - 1]);
//                        }
//                        else if (occupiedRect_shoe[currentRectList[0] - 1] != -1)
//                        {
//                            returnList.Add("Shoe" + occupiedRect_shoe[currentRectList[0] - 1]);
//                        }
//                        else
//                        {
//                            returnList.Add("Ring" + occupiedRect_ring[currentRectList[0] - 1]);
//                        }
//                    }
//                }
//                if (currentRectList[0] - 9 >= 0)
//                {
//                    if (occupiedRect[currentRectList[0] - 9])
//                    {
//                        if (occupiedRect_armor[currentRectList[0] - 9] != -1)
//                        {
//                            returnList.Add("Armor" + occupiedRect_armor[currentRectList[0] - 9]);
//                        }
//                        else if (occupiedRect_shield[currentRectList[0] - 9] != -1)
//                        {
//                            returnList.Add("Shield" + occupiedRect_shield[currentRectList[0] - 9]);
//                        }
//                        else if (occupiedRect_sword[currentRectList[0] - 9] != -1)
//                        {
//                            returnList.Add("Sword" + occupiedRect_sword[currentRectList[0] - 9]);
//                        }
//                        else if (occupiedRect_shoe[currentRectList[0] - 9] != -1)
//                        {
//                            returnList.Add("Shoe" + occupiedRect_shoe[currentRectList[0] - 9]);
//                        }
//                        else
//                        {
//                            returnList.Add("Ring" + occupiedRect_ring[currentRectList[0] - 9]);
//                        }
//                    }
                        
//                }
//                if (currentRectList[1] - 9 >= 0)
//                {
//                    if (occupiedRect[currentRectList[1] - 9])
//                    {
//                        if (occupiedRect_armor[currentRectList[1] - 9] != -1)
//                        {
//                            returnList.Add("Armor" + occupiedRect_armor[currentRectList[1] - 9]);
//                        }
//                        else if (occupiedRect_shield[currentRectList[1] - 9] != -1)
//                        {
//                            returnList.Add("Shield" + occupiedRect_shield[currentRectList[1] - 9]);
//                        }
//                        else if (occupiedRect_sword[currentRectList[1] - 9] != -1)
//                        {
//                            returnList.Add("Sword" + occupiedRect_sword[currentRectList[1] - 9]);
//                        }
//                        else if (occupiedRect_shoe[currentRectList[1] - 9] != -1)
//                        {
//                            returnList.Add("Shoe" + occupiedRect_shoe[currentRectList[1] - 9]);
//                        }
//                        else
//                        {
//                            returnList.Add("Ring" + occupiedRect_ring[currentRectList[1] - 9]);
//                        }
//                    }
//                }
//                if (currentRectList[1] + 1 != 9 && currentRectList[1] + 1 != 18 && currentRectList[1] + 1 != 27 && currentRectList[1] + 1 != 36)
//                {
//                    if (occupiedRect[currentRectList[1] + 1])
//                    {
//                        if (occupiedRect_armor[currentRectList[1] + 1] != -1)
//                        {
//                            returnList.Add("Armor" + occupiedRect_armor[currentRectList[1] + 1]);
//                        }
//                        else if (occupiedRect_shield[currentRectList[1] + 1] != -1)
//                        {
//                            returnList.Add("Shield" + occupiedRect_shield[currentRectList[1] + 1]);
//                        }
//                        else if (occupiedRect_sword[currentRectList[1] + 1] != -1)
//                        {
//                            returnList.Add("Sword" + occupiedRect_sword[currentRectList[1] + 1]);
//                        }
//                        else if (occupiedRect_shoe[currentRectList[1] + 1] != -1)
//                        {
//                            returnList.Add("Shoe" + occupiedRect_shoe[currentRectList[1] + 1]);
//                        }
//                        else
//                        {
//                            returnList.Add("Ring" + occupiedRect_ring[currentRectList[1] + 1]);
//                        }
//                    }
//                }
//                if (currentRectList[2] - 1 >= 0 && currentRectList[2] - 1 != 8 && currentRectList[2] - 1 != 17 && currentRectList[2] - 1 != 26)
//                {
//                    if (occupiedRect[currentRectList[2] - 1])
//                    {
//                        if (occupiedRect_armor[currentRectList[2] - 1] != -1)
//                        {
//                            returnList.Add("Armor" + occupiedRect_armor[currentRectList[2] - 1]);
//                        }
//                        else if (occupiedRect_shield[currentRectList[2] - 1] != -1)
//                        {
//                            returnList.Add("Shield" + occupiedRect_shield[currentRectList[2] - 1]);
//                        }
//                        else if (occupiedRect_sword[currentRectList[2] - 1] != -1)
//                        {
//                            returnList.Add("Sword" + occupiedRect_sword[currentRectList[2] - 1]);
//                        }
//                        else if (occupiedRect_shoe[currentRectList[2] - 1] != -1)
//                        {
//                            returnList.Add("Shoe" + occupiedRect_shoe[currentRectList[2] - 1]);
//                        }
//                        else
//                        {
//                            returnList.Add("Ring" + occupiedRect_ring[currentRectList[2] - 1]);
//                        }
//                    }
//                }
//                if (currentRectList[2] + 9 < 36)
//                {
//                    if (occupiedRect[currentRectList[2] + 9])
//                    {
//                        if (occupiedRect_armor[currentRectList[2] + 9] != -1)
//                        {
//                            returnList.Add("Armor" + occupiedRect_armor[currentRectList[2] + 9]);
//                        }
//                        else if (occupiedRect_shield[currentRectList[2] + 9] != -1)
//                        {
//                            returnList.Add("Shield" + occupiedRect_shield[currentRectList[2] + 9]);
//                        }
//                        else if (occupiedRect_sword[currentRectList[2] + 9] != -1)
//                        {
//                            returnList.Add("Sword" + occupiedRect_sword[currentRectList[2] + 9]);
//                        }
//                        else if (occupiedRect_shoe[currentRectList[2] + 9] != -1)
//                        {
//                            returnList.Add("Shoe" + occupiedRect_shoe[currentRectList[2] + 9]);
//                        }
//                        else
//                        {
//                            returnList.Add("Ring" + occupiedRect_ring[currentRectList[2] + 9]);
//                        }
//                    }
//                }
//                if (currentRectList[3] + 9 < 36)
//                {
//                    if (occupiedRect[currentRectList[3] + 9])
//                    {
//                        if (occupiedRect_armor[currentRectList[3] + 9] != -1)
//                        {
//                            returnList.Add("Armor" + occupiedRect_armor[currentRectList[3] + 9]);
//                        }
//                        else if (occupiedRect_shield[currentRectList[3] + 9] != -1)
//                        {
//                            returnList.Add("Shield" + occupiedRect_shield[currentRectList[3] + 9]);
//                        }
//                        else if (occupiedRect_sword[currentRectList[3] + 9] != -1)
//                        {
//                            returnList.Add("Sword" + occupiedRect_sword[currentRectList[3] + 9]);
//                        }
//                        else if (occupiedRect_shoe[currentRectList[3] + 9] != -1)
//                        {
//                            returnList.Add("Shoe" + occupiedRect_shoe[currentRectList[3] + 9]);
//                        }
//                        else
//                        {
//                            returnList.Add("Ring" + occupiedRect_ring[currentRectList[3] + 9]);
//                        }
//                    }
//                }
//                if (currentRectList[3] + 1 != 9 && currentRectList[3] + 1 != 18 && currentRectList[3] + 1 != 27 && currentRectList[3] + 1 != 36)
//                {
//                    if (occupiedRect[currentRectList[3] + 1])
//                    {
//                        if (occupiedRect_armor[currentRectList[3] + 1] != -1)
//                        {
//                            returnList.Add("Armor" + occupiedRect_armor[currentRectList[3] + 1]);
//                        }
//                        else if (occupiedRect_shield[currentRectList[3] + 1] != -1)
//                        {
//                            returnList.Add("Shield" + occupiedRect_shield[currentRectList[3] + 1]);
//                        }
//                        else if (occupiedRect_sword[currentRectList[3] + 1] != -1)
//                        {
//                            returnList.Add("Sword" + occupiedRect_sword[currentRectList[3] + 1]);
//                        }
//                        else if (occupiedRect_shoe[currentRectList[3] + 1] != -1)
//                        {
//                            returnList.Add("Shoe" + occupiedRect_shoe[currentRectList[3] + 1]);
//                        }
//                        else
//                        {
//                            returnList.Add("Ring" + occupiedRect_ring[currentRectList[3] + 1]);
//                        }
//                    }
//                }
//            }
//            else if (index == 1)
//            {
//                if (currentRectList[0] - 1 >= 0 && currentRectList[0] - 1 != 8 && currentRectList[0] - 1 != 17 && currentRectList[0] - 1 != 26)
//                {
//                    if (occupiedRect[currentRectList[0] - 1])
//                    {
//                        if (occupiedRect_armor[currentRectList[0] - 1] != -1)
//                        {
//                            returnList.Add("Armor" + occupiedRect_armor[currentRectList[0] - 1]);
//                        }
//                        else if (occupiedRect_shield[currentRectList[0] - 1] != -1)
//                        {
//                            returnList.Add("Shield" + occupiedRect_shield[currentRectList[0] - 1]);
//                        }
//                        else if (occupiedRect_sword[currentRectList[0] - 1] != -1)
//                        {
//                            returnList.Add("Sword" + occupiedRect_sword[currentRectList[0] - 1]);
//                        }
//                        else if (occupiedRect_shoe[currentRectList[0] - 1] != -1)
//                        {
//                            returnList.Add("Shoe" + occupiedRect_shoe[currentRectList[0] - 1]);
//                        }
//                        else
//                        {
//                            returnList.Add("Ring" + occupiedRect_ring[currentRectList[0] - 1]);
//                        }
//                    }
//                }
//                if (currentRectList[0] - 9 >= 0)
//                {
//                    if (occupiedRect[currentRectList[0] - 9])
//                    {
//                        if (occupiedRect_armor[currentRectList[0] - 9] != -1)
//                        {
//                            returnList.Add("Armor" + occupiedRect_armor[currentRectList[0] - 9]);
//                        }
//                        else if (occupiedRect_shield[currentRectList[0] - 9] != -1)
//                        {
//                            returnList.Add("Shield" + occupiedRect_shield[currentRectList[0] - 9]);
//                        }
//                        else if (occupiedRect_sword[currentRectList[0] - 9] != -1)
//                        {
//                            returnList.Add("Sword" + occupiedRect_sword[currentRectList[0] - 9]);
//                        }
//                        else if (occupiedRect_shoe[currentRectList[0] - 9] != -1)
//                        {
//                            returnList.Add("Shoe" + occupiedRect_shoe[currentRectList[0] - 9]);
//                        }
//                        else
//                        {
//                            returnList.Add("Ring" + occupiedRect_ring[currentRectList[0] - 9]);
//                        }
//                    }

//                }
//                if (currentRectList[0] + 9 < 36)
//                {
//                    if (occupiedRect[currentRectList[0] + 9])
//                    {
//                        if (occupiedRect_armor[currentRectList[0] + 9] != -1)
//                        {
//                            returnList.Add("Armor" + occupiedRect_armor[currentRectList[0] + 9]);
//                        }
//                        else if (occupiedRect_shield[currentRectList[0] + 9] != -1)
//                        {
//                            returnList.Add("Shield" + occupiedRect_shield[currentRectList[0] + 9]);
//                        }
//                        else if (occupiedRect_sword[currentRectList[0] + 9] != -1)
//                        {
//                            returnList.Add("Sword" + occupiedRect_sword[currentRectList[0] + 9]);
//                        }
//                        else if (occupiedRect_shoe[currentRectList[0] + 9] != -1)
//                        {
//                            returnList.Add("Shoe" + occupiedRect_shoe[currentRectList[0] + 9]);
//                        }
//                        else
//                        {
//                            returnList.Add("Ring" + occupiedRect_ring[currentRectList[0] + 9]);
//                        }
//                    }
//                }
//                if (currentRectList[1] + 1 != 9 && currentRectList[1] + 1 != 18 && currentRectList[1] + 1 != 27 && currentRectList[1] + 1 != 36)
//                {
//                    if (occupiedRect[currentRectList[1] + 1])
//                    {
//                        if (occupiedRect_armor[currentRectList[1] + 1] != -1)
//                        {
//                            returnList.Add("Armor" + occupiedRect_armor[currentRectList[1] + 1]);
//                        }
//                        else if (occupiedRect_shield[currentRectList[1] + 1] != -1)
//                        {
//                            returnList.Add("Shield" + occupiedRect_shield[currentRectList[1] + 1]);
//                        }
//                        else if (occupiedRect_sword[currentRectList[1] + 1] != -1)
//                        {
//                            returnList.Add("Sword" + occupiedRect_sword[currentRectList[1] + 1]);
//                        }
//                        else if (occupiedRect_shoe[currentRectList[1] + 1] != -1)
//                        {
//                            returnList.Add("Shoe" + occupiedRect_shoe[currentRectList[1] + 1]);
//                        }
//                        else
//                        {
//                            returnList.Add("Ring" + occupiedRect_ring[currentRectList[1] + 1]);
//                        }
//                    }
//                }
//                if (currentRectList[1] - 9 >= 0)
//                {
//                    if (occupiedRect[currentRectList[1] - 9])
//                    {
//                        if (occupiedRect_armor[currentRectList[1] - 9] != -1)
//                        {
//                            returnList.Add("Armor" + occupiedRect_armor[currentRectList[1] - 9]);
//                        }
//                        else if (occupiedRect_shield[currentRectList[1] - 9] != -1)
//                        {
//                            returnList.Add("Shield" + occupiedRect_shield[currentRectList[1] - 9]);
//                        }
//                        else if (occupiedRect_sword[currentRectList[1] - 9] != -1)
//                        {
//                            returnList.Add("Sword" + occupiedRect_sword[currentRectList[1] - 9]);
//                        }
//                        else if (occupiedRect_shoe[currentRectList[1] - 9] != -1)
//                        {
//                            returnList.Add("Shoe" + occupiedRect_shoe[currentRectList[1] - 9]);
//                        }
//                        else
//                        {
//                            returnList.Add("Ring" + occupiedRect_ring[currentRectList[1] - 9]);
//                        }
//                    }
//                }
//                if (currentRectList[1] + 9 < 36)
//                {
//                    if (occupiedRect[currentRectList[1] + 9])
//                    {
//                        if (occupiedRect_armor[currentRectList[1] + 9] != -1)
//                        {
//                            returnList.Add("Armor" + occupiedRect_armor[currentRectList[1] + 9]);
//                        }
//                        else if (occupiedRect_shield[currentRectList[1] + 9] != -1)
//                        {
//                            returnList.Add("Shield" + occupiedRect_shield[currentRectList[1] + 9]);
//                        }
//                        else if (occupiedRect_sword[currentRectList[1] + 9] != -1)
//                        {
//                            returnList.Add("Sword" + occupiedRect_sword[currentRectList[1] + 9]);
//                        }
//                        else if (occupiedRect_shoe[currentRectList[1] + 9] != -1)
//                        {
//                            returnList.Add("Shoe" + occupiedRect_shoe[currentRectList[1] + 9]);
//                        }
//                        else
//                        {
//                            returnList.Add("Ring" + occupiedRect_ring[currentRectList[1] + 9]);
//                        }
//                    }
//                }
//            }
//            else if (index == 2)
//            {
//                if (currentRectList[0] - 1 >= 0 && currentRectList[0] - 1 != 8 && currentRectList[0] - 1 != 17 && currentRectList[0] - 1 != 26)
//                {
//                    if (occupiedRect[currentRectList[0] - 1])
//                    {
//                        if (occupiedRect_armor[currentRectList[0] - 1] != -1)
//                        {
//                            returnList.Add("Armor" + occupiedRect_armor[currentRectList[0] - 1]);
//                        }
//                        else if (occupiedRect_shield[currentRectList[0] - 1] != -1)
//                        {
//                            returnList.Add("Shield" + occupiedRect_shield[currentRectList[0] - 1]);
//                        }
//                        else if (occupiedRect_sword[currentRectList[0] - 1] != -1)
//                        {
//                            returnList.Add("Sword" + occupiedRect_sword[currentRectList[0] - 1]);
//                        }
//                        else if (occupiedRect_shoe[currentRectList[0] - 1] != -1)
//                        {
//                            returnList.Add("Shoe" + occupiedRect_shoe[currentRectList[0] - 1]);
//                        }
//                        else
//                        {
//                            returnList.Add("Ring" + occupiedRect_ring[currentRectList[0] - 1]);
//                        }
//                    }
//                }
//                if (currentRectList[0] - 9 >= 0)
//                {
//                    if (occupiedRect[currentRectList[0] - 9])
//                    {
//                        if (occupiedRect_armor[currentRectList[0] - 9] != -1)
//                        {
//                            returnList.Add("Armor" + occupiedRect_armor[currentRectList[0] - 9]);
//                        }
//                        else if (occupiedRect_shield[currentRectList[0] - 9] != -1)
//                        {
//                            returnList.Add("Shield" + occupiedRect_shield[currentRectList[0] - 9]);
//                        }
//                        else if (occupiedRect_sword[currentRectList[0] - 9] != -1)
//                        {
//                            returnList.Add("Sword" + occupiedRect_sword[currentRectList[0] - 9]);
//                        }
//                        else if (occupiedRect_shoe[currentRectList[0] - 9] != -1)
//                        {
//                            returnList.Add("Shoe" + occupiedRect_shoe[currentRectList[0] - 9]);
//                        }
//                        else
//                        {
//                            returnList.Add("Ring" + occupiedRect_ring[currentRectList[0] - 9]);
//                        }
//                    }
//                }
//                if (currentRectList[0] + 9 < 36)
//                {
//                    if (occupiedRect[currentRectList[0] + 9])
//                    {
//                        if (occupiedRect_armor[currentRectList[0] + 9] != -1)
//                        {
//                            returnList.Add("Armor" + occupiedRect_armor[currentRectList[0] + 9]);
//                        }
//                        else if (occupiedRect_shield[currentRectList[0] + 9] != -1)
//                        {
//                            returnList.Add("Shield" + occupiedRect_shield[currentRectList[0] + 9]);
//                        }
//                        else if (occupiedRect_sword[currentRectList[0] + 9] != -1)
//                        {
//                            returnList.Add("Sword" + occupiedRect_sword[currentRectList[0] + 9]);
//                        }
//                        else if (occupiedRect_shoe[currentRectList[0] + 9] != -1)
//                        {
//                            returnList.Add("Shoe" + occupiedRect_shoe[currentRectList[0] + 9]);
//                        }
//                        else
//                        {
//                            returnList.Add("Ring" + occupiedRect_ring[currentRectList[0] + 9]);
//                        }
//                    }
//                }
//                if (currentRectList[1] - 9 >= 0)
//                {
//                    if (occupiedRect[currentRectList[1] - 9])
//                    {
//                        if (occupiedRect_armor[currentRectList[1] - 9] != -1)
//                        {
//                            returnList.Add("Armor" + occupiedRect_armor[currentRectList[1] - 9]);
//                        }
//                        else if (occupiedRect_shield[currentRectList[1] - 9] != -1)
//                        {
//                            returnList.Add("Shield" + occupiedRect_shield[currentRectList[1] - 9]);
//                        }
//                        else if (occupiedRect_sword[currentRectList[1] - 9] != -1)
//                        {
//                            returnList.Add("Sword" + occupiedRect_sword[currentRectList[1] - 9]);
//                        }
//                        else if (occupiedRect_shoe[currentRectList[1] - 9] != -1)
//                        {
//                            returnList.Add("Shoe" + occupiedRect_shoe[currentRectList[1] - 9]);
//                        }
//                        else
//                        {
//                            returnList.Add("Ring" + occupiedRect_ring[currentRectList[1] - 9]);
//                        }
//                    }
//                }
//                if (currentRectList[1] + 9 < 36)
//                {
//                    if (occupiedRect[currentRectList[1] + 9])
//                    {
//                        if (occupiedRect_armor[currentRectList[1] + 9] != -1)
//                        {
//                            returnList.Add("Armor" + occupiedRect_armor[currentRectList[1] + 9]);
//                        }
//                        else if (occupiedRect_shield[currentRectList[1] + 9] != -1)
//                        {
//                            returnList.Add("Shield" + occupiedRect_shield[currentRectList[1] + 9]);
//                        }
//                        else if (occupiedRect_sword[currentRectList[1] + 9] != -1)
//                        {
//                            returnList.Add("Sword" + occupiedRect_sword[currentRectList[1] + 9]);
//                        }
//                        else if (occupiedRect_shoe[currentRectList[1] + 9] != -1)
//                        {
//                            returnList.Add("Shoe" + occupiedRect_shoe[currentRectList[1] + 9]);
//                        }
//                        else
//                        {
//                            returnList.Add("Ring" + occupiedRect_ring[currentRectList[1] + 9]);
//                        }
//                    }
//                }
//                if (currentRectList[2] + 1 != 9 && currentRectList[2] + 1 != 18 && currentRectList[2] + 1 != 27 && currentRectList[2] + 1 != 36)
//                {
//                    if (occupiedRect[currentRectList[2] + 1])
//                    {
//                        if (occupiedRect_armor[currentRectList[2] + 1] != -1)
//                        {
//                            returnList.Add("Armor" + occupiedRect_armor[currentRectList[2] + 1]);
//                        }
//                        else if (occupiedRect_shield[currentRectList[2] + 1] != -1)
//                        {
//                            returnList.Add("Shield" + occupiedRect_shield[currentRectList[2] + 1]);
//                        }
//                        else if (occupiedRect_sword[currentRectList[2] + 1] != -1)
//                        {
//                            returnList.Add("Sword" + occupiedRect_sword[currentRectList[2] + 1]);
//                        }
//                        else if (occupiedRect_shoe[currentRectList[2] + 1] != -1)
//                        {
//                            returnList.Add("Shoe" + occupiedRect_shoe[currentRectList[2] + 1]);
//                        }
//                        else
//                        {
//                            returnList.Add("Ring" + occupiedRect_ring[currentRectList[2] + 1]);
//                        }
//                    }
//                }
//                if (currentRectList[2] - 9 >= 0)
//                {
//                    if (occupiedRect[currentRectList[2] - 9])
//                    {
//                        if (occupiedRect_armor[currentRectList[2] - 9] != -1)
//                        {
//                            returnList.Add("Armor" + occupiedRect_armor[currentRectList[2] - 9]);
//                        }
//                        else if (occupiedRect_shield[currentRectList[2] - 9] != -1)
//                        {
//                            returnList.Add("Shield" + occupiedRect_shield[currentRectList[2] - 9]);
//                        }
//                        else if (occupiedRect_sword[currentRectList[2] - 9] != -1)
//                        {
//                            returnList.Add("Sword" + occupiedRect_sword[currentRectList[2] - 9]);
//                        }
//                        else if (occupiedRect_shoe[currentRectList[2] - 9] != -1)
//                        {
//                            returnList.Add("Shoe" + occupiedRect_shoe[currentRectList[2] - 9]);
//                        }
//                        else
//                        {
//                            returnList.Add("Ring" + occupiedRect_ring[currentRectList[2] - 9]);
//                        }
//                    }
//                }
//                if (currentRectList[2] + 9 < 36)
//                {
//                    if (occupiedRect[currentRectList[2] + 9])
//                    {
//                        if (occupiedRect_armor[currentRectList[2] + 9] != -1)
//                        {
//                            returnList.Add("Armor" + occupiedRect_armor[currentRectList[2] + 9]);
//                        }
//                        else if (occupiedRect_shield[currentRectList[2] + 9] != -1)
//                        {
//                            returnList.Add("Shield" + occupiedRect_shield[currentRectList[2] + 9]);
//                        }
//                        else if (occupiedRect_sword[currentRectList[2] + 9] != -1)
//                        {
//                            returnList.Add("Sword" + occupiedRect_sword[currentRectList[2] + 9]);
//                        }
//                        else if (occupiedRect_shoe[currentRectList[2] + 9] != -1)
//                        {
//                            returnList.Add("Shoe" + occupiedRect_shoe[currentRectList[2] + 9]);
//                        }
//                        else
//                        {
//                            returnList.Add("Ring" + occupiedRect_ring[currentRectList[2] + 9]);
//                        }
//                    }
//                }
//            }
//            else if (index == 3)
//            {
//                if (currentRectList[0] - 1 >= 0 && currentRectList[0] - 1 != 8 && currentRectList[0] - 1 != 17 && currentRectList[0] - 1 != 26)
//                {
//                    if (occupiedRect[currentRectList[0] - 1])
//                    {
//                        if (occupiedRect_armor[currentRectList[0] - 1] != -1)
//                        {
//                            returnList.Add("Armor" + occupiedRect_armor[currentRectList[0] - 1]);
//                        }
//                        else if (occupiedRect_shield[currentRectList[0] - 1] != -1)
//                        {
//                            returnList.Add("Shield" + occupiedRect_shield[currentRectList[0] - 1]);
//                        }
//                        else if (occupiedRect_sword[currentRectList[0] - 1] != -1)
//                        {
//                            returnList.Add("Sword" + occupiedRect_sword[currentRectList[0] - 1]);
//                        }
//                        else if (occupiedRect_shoe[currentRectList[0] - 1] != -1)
//                        {
//                            returnList.Add("Shoe" + occupiedRect_shoe[currentRectList[0] - 1]);
//                        }
//                        else
//                        {
//                            returnList.Add("Ring" + occupiedRect_ring[currentRectList[0] - 1]);
//                        }
//                    }
//                }
//                if (currentRectList[0] - 9 >= 0)
//                {
//                    if (occupiedRect[currentRectList[0] - 9])
//                    {
//                        if (occupiedRect_armor[currentRectList[0] - 9] != -1)
//                        {
//                            returnList.Add("Armor" + occupiedRect_armor[currentRectList[0] - 9]);
//                        }
//                        else if (occupiedRect_shield[currentRectList[0] - 9] != -1)
//                        {
//                            returnList.Add("Shield" + occupiedRect_shield[currentRectList[0] - 9]);
//                        }
//                        else if (occupiedRect_sword[currentRectList[0] - 9] != -1)
//                        {
//                            returnList.Add("Sword" + occupiedRect_sword[currentRectList[0] - 9]);
//                        }
//                        else if (occupiedRect_shoe[currentRectList[0] - 9] != -1)
//                        {
//                            returnList.Add("Shoe" + occupiedRect_shoe[currentRectList[0] - 9]);
//                        }
//                        else
//                        {
//                            returnList.Add("Ring" + occupiedRect_ring[currentRectList[0] - 9]);
//                        }
//                    }
//                }
//                if (currentRectList[0] + 1 != 9 && currentRectList[0] + 1 != 18 && currentRectList[0] + 1 != 27 && currentRectList[0] + 1 != 36)
//                {
//                    if (occupiedRect[currentRectList[0] + 1])
//                    {
//                        if (occupiedRect_armor[currentRectList[0] + 1] != -1)
//                        {
//                            returnList.Add("Armor" + occupiedRect_armor[currentRectList[0] + 1]);
//                        }
//                        else if (occupiedRect_shield[currentRectList[0] + 1] != -1)
//                        {
//                            returnList.Add("Shield" + occupiedRect_shield[currentRectList[0] + 1]);
//                        }
//                        else if (occupiedRect_sword[currentRectList[0] + 1] != -1)
//                        {
//                            returnList.Add("Sword" + occupiedRect_sword[currentRectList[0] + 1]);
//                        }
//                        else if (occupiedRect_shoe[currentRectList[0] + 1] != -1)
//                        {
//                            returnList.Add("Shoe" + occupiedRect_shoe[currentRectList[0] + 1]);
//                        }
//                        else
//                        {
//                            returnList.Add("Ring" + occupiedRect_ring[currentRectList[0] + 1]);
//                        }
//                    }
//                }
//                if (currentRectList[1] - 1 >= 0 && currentRectList[1] - 1 != 8 && currentRectList[1] - 1 != 17 && currentRectList[1] - 1 != 26)
//                {
//                    if (occupiedRect[currentRectList[1] - 1])
//                    {
//                        if (occupiedRect_armor[currentRectList[1] - 1] != -1)
//                        {
//                            returnList.Add("Armor" + occupiedRect_armor[currentRectList[1] - 1]);
//                        }
//                        else if (occupiedRect_shield[currentRectList[1] - 1] != -1)
//                        {
//                            returnList.Add("Shield" + occupiedRect_shield[currentRectList[1] - 1]);
//                        }
//                        else if (occupiedRect_sword[currentRectList[1] - 1] != -1)
//                        {
//                            returnList.Add("Sword" + occupiedRect_sword[currentRectList[1] - 1]);
//                        }
//                        else if (occupiedRect_shoe[currentRectList[1] - 1] != -1)
//                        {
//                            returnList.Add("Shoe" + occupiedRect_shoe[currentRectList[1] - 1]);
//                        }
//                        else
//                        {
//                            returnList.Add("Ring" + occupiedRect_ring[currentRectList[1] - 1]);
//                        }
//                    }
//                }
//                if (currentRectList[1] + 9 < 36)
//                {
//                    if (occupiedRect[currentRectList[1] + 9])
//                    {
//                        if (occupiedRect_armor[currentRectList[1] + 9] != -1)
//                        {
//                            returnList.Add("Armor" + occupiedRect_armor[currentRectList[1] + 9]);
//                        }
//                        else if (occupiedRect_shield[currentRectList[1] + 9] != -1)
//                        {
//                            returnList.Add("Shield" + occupiedRect_shield[currentRectList[1] + 9]);
//                        }
//                        else if (occupiedRect_sword[currentRectList[1] + 9] != -1)
//                        {
//                            returnList.Add("Sword" + occupiedRect_sword[currentRectList[1] + 9]);
//                        }
//                        else if (occupiedRect_shoe[currentRectList[1] + 9] != -1)
//                        {
//                            returnList.Add("Shoe" + occupiedRect_shoe[currentRectList[1] + 9]);
//                        }
//                        else
//                        {
//                            returnList.Add("Ring" + occupiedRect_ring[currentRectList[1] + 9]);
//                        }
//                    }
//                }
//                if (currentRectList[1] + 1 != 9 && currentRectList[1] + 1 != 18 && currentRectList[1] + 1 != 27 && currentRectList[1] + 1 != 36)
//                {
//                    if (occupiedRect[currentRectList[1] + 1])
//                    {
//                        if (occupiedRect_armor[currentRectList[1] + 1] != -1)
//                        {
//                            returnList.Add("Armor" + occupiedRect_armor[currentRectList[1] + 1]);
//                        }
//                        else if (occupiedRect_shield[currentRectList[1] + 1] != -1)
//                        {
//                            returnList.Add("Shield" + occupiedRect_shield[currentRectList[1] + 1]);
//                        }
//                        else if (occupiedRect_sword[currentRectList[1] + 1] != -1)
//                        {
//                            returnList.Add("Sword" + occupiedRect_sword[currentRectList[1] + 1]);
//                        }
//                        else if (occupiedRect_shoe[currentRectList[1] + 1] != -1)
//                        {
//                            returnList.Add("Shoe" + occupiedRect_shoe[currentRectList[1] + 1]);
//                        }
//                        else
//                        {
//                            returnList.Add("Ring" + occupiedRect_ring[currentRectList[1] + 1]);
//                        }
//                    }
//                }
//            }
//            else if (index == 4)
//            {
//                if (currentRectList[0] - 1 >= 0 && currentRectList[0] - 1 != 8 && currentRectList[0] - 1 != 17 && currentRectList[0] - 1 != 26)
//                {
//                    if (occupiedRect[currentRectList[0] - 1])
//                    {
//                        if (occupiedRect_armor[currentRectList[0] - 1] != -1)
//                        {
//                            returnList.Add("Armor" + occupiedRect_armor[currentRectList[0] - 1]);
//                        }
//                        else if (occupiedRect_shield[currentRectList[0] - 1] != -1)
//                        {
//                            returnList.Add("Shield" + occupiedRect_shield[currentRectList[0] - 1]);
//                        }
//                        else if (occupiedRect_sword[currentRectList[0] - 1] != -1)
//                        {
//                            returnList.Add("Sword" + occupiedRect_sword[currentRectList[0] - 1]);
//                        }
//                        else if (occupiedRect_shoe[currentRectList[0] - 1] != -1)
//                        {
//                            returnList.Add("Shoe" + occupiedRect_shoe[currentRectList[0] - 1]);
//                        }
//                        else
//                        {
//                            returnList.Add("Ring" + occupiedRect_ring[currentRectList[0] - 1]);
//                        }
//                    }
//                }
//                if (currentRectList[0] - 9 >= 0)
//                {
//                    if (occupiedRect[currentRectList[0] - 9])
//                    {
//                        if (occupiedRect_armor[currentRectList[0] - 9] != -1)
//                        {
//                            returnList.Add("Armor" + occupiedRect_armor[currentRectList[0] - 9]);
//                        }
//                        else if (occupiedRect_shield[currentRectList[0] - 9] != -1)
//                        {
//                            returnList.Add("Shield" + occupiedRect_shield[currentRectList[0] - 9]);
//                        }
//                        else if (occupiedRect_sword[currentRectList[0] - 9] != -1)
//                        {
//                            returnList.Add("Sword" + occupiedRect_sword[currentRectList[0] - 9]);
//                        }
//                        else if (occupiedRect_shoe[currentRectList[0] - 9] != -1)
//                        {
//                            returnList.Add("Shoe" + occupiedRect_shoe[currentRectList[0] - 9]);
//                        }
//                        else
//                        {
//                            returnList.Add("Ring" + occupiedRect_ring[currentRectList[0] - 9]);
//                        }
//                    }
//                }
//                if (currentRectList[0] + 9 < 36)
//                {
//                    if (occupiedRect[currentRectList[0] + 9])
//                    {
//                        if (occupiedRect_armor[currentRectList[0] + 9] != -1)
//                        {
//                            returnList.Add("Armor" + occupiedRect_armor[currentRectList[0] + 9]);
//                        }
//                        else if (occupiedRect_shield[currentRectList[0] + 9] != -1)
//                        {
//                            returnList.Add("Shield" + occupiedRect_shield[currentRectList[0] + 9]);
//                        }
//                        else if (occupiedRect_sword[currentRectList[0] + 9] != -1)
//                        {
//                            returnList.Add("Sword" + occupiedRect_sword[currentRectList[0] + 9]);
//                        }
//                        else if (occupiedRect_shoe[currentRectList[0] + 9] != -1)
//                        {
//                            returnList.Add("Shoe" + occupiedRect_shoe[currentRectList[0] + 9]);
//                        }
//                        else
//                        {
//                            returnList.Add("Ring" + occupiedRect_ring[currentRectList[0] + 9]);
//                        }
//                    }
//                }
//                if (currentRectList[0] + 1 != 9 && currentRectList[0] + 1 != 18 && currentRectList[0] + 1 != 27 && currentRectList[0] + 1 != 36)
//                {
//                    if (occupiedRect[currentRectList[0] + 1])
//                    {
//                        if (occupiedRect_armor[currentRectList[0] + 1] != -1)
//                        {
//                            returnList.Add("Armor" + occupiedRect_armor[currentRectList[0] + 1]);
//                        }
//                        else if (occupiedRect_shield[currentRectList[0] + 1] != -1)
//                        {
//                            returnList.Add("Shield" + occupiedRect_shield[currentRectList[0] + 1]);
//                        }
//                        else if (occupiedRect_sword[currentRectList[0] + 1] != -1)
//                        {
//                            returnList.Add("Sword" + occupiedRect_sword[currentRectList[0] + 1]);
//                        }
//                        else if (occupiedRect_shoe[currentRectList[0] + 1] != -1)
//                        {
//                            returnList.Add("Shoe" + occupiedRect_shoe[currentRectList[0] + 1]);
//                        }
//                        else
//                        {
//                            returnList.Add("Ring" + occupiedRect_ring[currentRectList[0] + 1]);
//                        }
//                    }
//                }
//            }
//        }
//        returnList = returnList.Distinct().ToList();
//        for (int j = 0; j < returnList.Count; j++)
//        {
//            Debug.Log(returnList[j]);
//        }
//        //return returnList;
//    }


//}