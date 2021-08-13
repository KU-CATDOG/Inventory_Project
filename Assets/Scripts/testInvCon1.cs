//#pragma warning disable IDE0090 // 'new(...)' ignore
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;


//public class testInvCon : MonoBehaviour
//{
//    [Header("#Wearable Items"), SerializeField]
//    private GameObject Armor;
//    [SerializeField]
//    private GameObject Shield, Shoe, Sword, Ring;
//    public GameObject item;
//    public int armorRan, shieldRan, shoeRan, swordRan, ringRan;
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
//            }
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
//    }

//    void Spawn()
//    {
//        SpawnArmor();
//        SpawnSword();
//        SpawnShield();
//        SpawnShoe();
//        SpawnRing();
//    }

//    void SpawnArmor()
//    {
//        int k = 0;
//        int[] randArray = getRandomInt(armorPosList.Count, 0, armorPosList.Count);
//        int ran = randArray[k];
//        while (k < armorPosList.Count)
//        {
//            if (ran < 8)
//            {
//                if (!occupiedRect[ran] && !occupiedRect[ran + 1] && !occupiedRect[ran + 9] && !occupiedRect[ran + 10])
//                {
//                    var go = Instantiate(Armor, armorPosList[ran], Quaternion.identity);
//                    go.transform.SetParent(item.transform, false);
//                    occupiedRect[ran] = true;
//                    occupiedRect[ran + 1] = true;
//                    occupiedRect[ran + 9] = true;
//                    occupiedRect[ran + 10] = true;
//                    armorRan = ran;
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
//                    var go = Instantiate(Armor, armorPosList[ran], Quaternion.identity);
//                    go.transform.SetParent(item.transform, false);
//                    occupiedRect[ran + 1] = true;
//                    occupiedRect[ran + 2] = true;
//                    occupiedRect[ran + 10] = true;
//                    occupiedRect[ran + 11] = true;
//                    armorRan = ran;
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
//                    var go = Instantiate(Armor, armorPosList[ran], Quaternion.identity);
//                    go.transform.SetParent(item.transform, false);
//                    occupiedRect[ran + 2] = true;
//                    occupiedRect[ran + 3] = true;
//                    occupiedRect[ran + 11] = true;
//                    occupiedRect[ran + 12] = true;
//                    armorRan = ran;
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
//    void SpawnSword()
//    {
//        int k = 0;
//        int[] randArray = getRandomInt(swordPosList.Count, 0, swordPosList.Count);
//        int ran = randArray[k];
//        while (k < swordPosList.Count)
//        {
//            if (ran < 7)
//            {
//                if (!occupiedRect[ran] && !occupiedRect[ran + 1] && !occupiedRect[ran + 2])
//                {
//                    var go = Instantiate(Sword, swordPosList[ran], Quaternion.identity);
//                    go.transform.SetParent(item.transform, false);
//                    occupiedRect[ran] = true;
//                    occupiedRect[ran + 1] = true;
//                    occupiedRect[ran + 2] = true;
//                    swordRan = ran;
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
//                    var go = Instantiate(Sword, swordPosList[ran], Quaternion.identity);
//                    go.transform.SetParent(item.transform, false);
//                    occupiedRect[ran + 2] = true;
//                    occupiedRect[ran + 3] = true;
//                    occupiedRect[ran + 4] = true;
//                    swordRan = ran;
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
//                    var go = Instantiate(Sword, swordPosList[ran], Quaternion.identity);
//                    go.transform.SetParent(item.transform, false);
//                    occupiedRect[ran + 4] = true;
//                    occupiedRect[ran + 5] = true;
//                    occupiedRect[ran + 6] = true;
//                    swordRan = ran;
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
//                    var go = Instantiate(Sword, swordPosList[ran], Quaternion.identity);
//                    go.transform.SetParent(item.transform, false);
//                    occupiedRect[ran + 6] = true;
//                    occupiedRect[ran + 7] = true;
//                    occupiedRect[ran + 8] = true;
//                    swordRan = ran;
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
//    void SpawnShield()
//    {
//        int k = 0;
//        int[] randArray = getRandomInt(shieldPosList.Count, 0, shieldPosList.Count);
//        int ran = randArray[k];
//        while (k < shieldPosList.Count)
//        {
//            if (ran < 8)
//            {
//                if (!occupiedRect[ran] && !occupiedRect[ran + 1])
//                {
//                    var go = Instantiate(Shield, shieldPosList[ran], Quaternion.identity);
//                    go.transform.SetParent(item.transform, false);
//                    occupiedRect[ran] = true;
//                    occupiedRect[ran + 1] = true;
//                    shieldRan = ran;
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
//                    var go = Instantiate(Shield, shieldPosList[ran], Quaternion.identity);
//                    go.transform.SetParent(item.transform, false);
//                    occupiedRect[ran + 1] = true;
//                    occupiedRect[ran + 2] = true;
//                    shieldRan = ran;
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
//                    var go = Instantiate(Shield, shieldPosList[ran], Quaternion.identity);
//                    go.transform.SetParent(item.transform, false);
//                    occupiedRect[ran + 2] = true;
//                    occupiedRect[ran + 3] = true;
//                    shieldRan = ran;
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
//                    var go = Instantiate(Shield, shieldPosList[ran], Quaternion.identity);
//                    go.transform.SetParent(item.transform, false);
//                    occupiedRect[ran + 3] = true;
//                    occupiedRect[ran + 4] = true;
//                    shieldRan = ran;
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
//    void SpawnShoe()
//    {
//        int k = 0;
//        int[] randArray = getRandomInt(shoePosList.Count, 0, shoePosList.Count);
//        int ran = randArray[k];
//        while (k < shoePosList.Count)
//        {
//            if (!occupiedRect[ran] && !occupiedRect[ran + 9])
//            {
//                var go = Instantiate(Shoe, shoePosList[ran], Quaternion.identity);
//                go.transform.SetParent(item.transform, false);
//                occupiedRect[ran] = true;
//                occupiedRect[ran + 9] = true;
//                shoeRan = ran;
//                return;
//            }
//            else
//            {
//                k++;
//                ran = randArray[k];
//            }
//        }
//    }
//    void SpawnRing()
//    {
//        int k = 0;
//        int[] randArray = getRandomInt(ringPosList.Count, 0, ringPosList.Count);
//        int ran = randArray[k];
//        while (k < ringPosList.Count)
//        {
//            if (!occupiedRect[ran])
//            {
//                var go = Instantiate(Ring, ringPosList[ran], Quaternion.identity);
//                go.transform.SetParent(item.transform, false);
//                occupiedRect[ran] = true;
//                ringRan = ran;
//                return;
//            }
//            else
//            {
//                k++;
//                ran = randArray[k];
//            }
//        }
//    }

//    public int[] getRandomInt(int length, int min, int max)
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


//}

