using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropSelect : MonoBehaviour
{
    public ClearJudge clearJudge;
    //public Transform shield;
    //public Transform armor;
    //public Transform shoes;
    //public Transform sword;
    //public Transform accessories;

    public MapLoadTest mapLoad;
    public InGameUI inGameUI;
    Player player;
    testInvCon invCon;

    public GameObject InventoryManager;
    public int makeOnce, makeCount;
    int pastplayerPos = 0;
    int curplayerPos;
    int tabPressed = 0;

    public int swordSpawnCount = 1;
    public int shieldSpawnCount = 1;
    public int shoesSpawnCount = 1;
    public int armorSpawnCount = 1;
    public int accessorySpawnCount = 1;

    int curShieldOccupied;
    int curSwordOccupied;
    int curShoesOccupied;
    int curArmorOccupied;
    int curAccessoryOccupied;

    int pastShieldOccupied = -1;
    int pastSwordOccupied = -1;
    int pastShoesOccupied = -1;
    int pastArmorOccupied = -1;
    int pastAccessoryOccupied = -1;

    

    public int Item1;//1 방패, 2 검, 3 신발, 4 갑옷, 5 장신구
    public int Item2;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        invCon = InventoryManager.GetComponent<testInvCon>();
        makeOnce = 0; makeCount = 0;


    }

    // Update is called once per frame
    void Update()
    {
        curplayerPos = invCon.playerPosition;


        /*if(curplayerPos != pastplayerPos&& tabPressed == 1)
        {
            curShieldOccupied = invCon.occupiedRect_shield[curplayerPos];
            curSwordOccupied = invCon.occupiedRect_sword[curplayerPos];
            curShoesOccupied = invCon.occupiedRect_shoe[curplayerPos];
            curArmorOccupied = invCon.occupiedRect_armor[curplayerPos];
            curAccessoryOccupied = invCon.occupiedRect_ring[curplayerPos];
            if (curShieldOccupied == pastShieldOccupied && pastSwordOccupied == curSwordOccupied && pastShoesOccupied == curShoesOccupied && curArmorOccupied == pastArmorOccupied && pastAccessoryOccupied == curAccessoryOccupied)
            {
                //같은 맵에 계속 있음
            }
            else
            {
                dropOnce = 0;
                clearJudge.Clear = false;
                Debug.Log("different map");
                //다른 맵으로 이동
            }
            pastShieldOccupied = curShieldOccupied;
            pastSwordOccupied = curSwordOccupied;
            pastShoesOccupied = curShoesOccupied;
            pastArmorOccupied = curArmorOccupied;
            pastAccessoryOccupied = curAccessoryOccupied;
            pastplayerPos = curplayerPos;
            //Debug.Log(invCon.occupiedRect_shield[1]);
            
        }*/
        if (tabPressed == 0)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                tabPressed = 1;

            }
        }
        if (clearJudge.Clear == true && makeOnce == 0 && curplayerPos != -1 && tabPressed == 1)
        {
            makeDifferentItem(curplayerPos,0,0);
            invCon.GetNearbyItems();
            mapLoad.SpawnMap();
            makeOnce++;
            inGameUI.goItemSelectScreen();
        }
        if (clearJudge.Clear == false)
        {
            makeOnce = 0;
        }
    }

    private void makeDifferentItem(int Pos,int a,int b)
    {
        if (Pos != -1)
        {
            
            
            while (makeCount == 0)
            {
                a = Random.Range(0, 5);
                switch (a)
                {
                    
                    case 0:
                        if (invCon.occupiedRect_shield[Pos] != -1)//만약 같은 맵이면 다시 뽑기
                        {
                            break;
                        }
                        else
                        {
                            Item1 = 1;
                            makeCount++;
                        }
                        break;

                    case 1:
                        if (invCon.occupiedRect_armor[Pos] != -1)
                        {
                            break;
                        }
                        else
                        {
                            Item1 = 2;
                            makeCount++;
                        }

                        break;

                    case 2:
                        if (invCon.occupiedRect_shoe[Pos] != -1)
                        {
                            break;
                        }
                        else
                        {
                            Item1 = 3;
                            makeCount++;
                        }
                        break;

                    case 3:
                        if (invCon.occupiedRect_sword[Pos] != -1)
                        {
                            break;
                        }
                        else
                        {
                            Item1 = 4;
                            makeCount++;
                        }
                        break;

                    case 4:
                        if (invCon.occupiedRect_ring[Pos] != -1)
                        {
                            break;
                        }
                        else
                        {
                            Item1 = 5;
                            makeCount++;
                        }
                        break;
                }
            }

            
            while (makeCount == 1)
            {
                do
                {
                    b = Random.Range(0, 5);
                } while (a == b);//서로 다른 아이템 뽑게 하기
            switch (b)
                {
                    case 0:
                        if (invCon.occupiedRect_shield[Pos] != -1)//만약 같은 맵이면 다시 뽑기
                        {
                            break;
                        }
                        else
                        {
                            Item2 = 1;
                            makeCount++;
                        }
                        break;

                    case 1:
                        if (invCon.occupiedRect_armor[Pos] != -1)
                        {
                            break;
                        }
                        else
                        {
                            Item2 = 2;
                            makeCount++;
                        }

                        break;

                    case 2:
                        if (invCon.occupiedRect_shoe[Pos] != -1)
                        {
                            break;
                        }
                        else
                        {
                            Item2 = 3;
                            makeCount++;
                        }
                        break;

                    case 3:
                        if (invCon.occupiedRect_sword[Pos] != -1)
                        {
                            break;
                        }
                        else
                        {
                            Item2 = 4;
                            makeCount++;
                        }
                        break;

                    case 4:
                        if (invCon.occupiedRect_ring[Pos] != -1)
                        {
                            break;
                        }
                        else
                        {
                            Item2 = 5;
                            makeCount++;
                        }
                        break;
                }
                
            }
            makeCount = 0;
            Debug.Log("Item1=" + Item1);
            Debug.Log("Item2=" + Item2);
        }
        else
        {
            Debug.Log("Player is at starting position");
        }
    }

}