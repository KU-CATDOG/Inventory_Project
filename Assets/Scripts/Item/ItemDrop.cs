using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    public ClearJudge clearJudge;
    public Transform shield;
    public Transform armor;
    public Transform shoes;
    public Transform sword;
    public Transform accessories;

    public MapLoadTest mapLoad;
    Player player;
    testInvCon invCon;

    public GameObject InventoryManager;
    public int dropOnce, dropCount;
    int pastplayerPos = 0;
    int curplayerPos;
    int tabPressed = 0;

    int swordSpawnCount = 1;
    int shieldSpawnCount = 1;
    int shoesSpawnCount = 1;
    int armorSpawnCount = 1;
    int accessorySpawnCount = 1;

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


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        invCon = InventoryManager.GetComponent<testInvCon>();
        dropOnce = 0; dropCount = 0;


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
        if (clearJudge.Clear == true && dropOnce == 0 && curplayerPos != -1 && tabPressed == 1)
        {
            dropDifferentItem(curplayerPos);
            invCon.GetNearbyItems();
            mapLoad.SpawnMap();
            dropOnce++;
        }
        if (clearJudge.Clear == false)
        {
            dropOnce = 0;
        }
    }

    private void dropDifferentItem(int Pos)
    {
        if (Pos != -1)
        {
            int a, b;
            a = Random.Range(0, 5);
            while (dropCount == 0)
            {
                switch (a)
                {
                    case 0:
                        if (invCon.occupiedRect_shield[Pos] != -1)//만약 같은 맵이면 다시 뽑기
                        {
                            break;
                        }
                        Instantiate(shield);
                        invCon.SpawnShield(shieldSpawnCount);

                        shieldSpawnCount++;
                        dropCount++;
                        break;

                    case 1:
                        if (invCon.occupiedRect_armor[Pos] != -1)
                        {
                            break;
                        }
                        Instantiate(armor);
                        invCon.SpawnArmor(armorSpawnCount);
                        armorSpawnCount++;
                        dropCount++;
                        break;

                    case 2:
                        if (invCon.occupiedRect_shoe[Pos] != -1)
                        {
                            break;
                        }
                        Instantiate(shoes);
                        invCon.SpawnShoe(shoesSpawnCount);
                        shoesSpawnCount++;
                        dropCount++;
                        break;

                    case 3:
                        if (invCon.occupiedRect_sword[Pos] != -1)
                        {
                            break;
                        }
                        Instantiate(sword);
                        invCon.SpawnSword(swordSpawnCount);
                        swordSpawnCount++;
                        dropCount++;
                        break;

                    case 4:
                        if (invCon.occupiedRect_ring[Pos] != -1)
                        {
                            break;
                        }
                        Instantiate(accessories);
                        invCon.SpawnRing(accessorySpawnCount);
                        accessorySpawnCount++;
                        dropCount++;
                        break;
                }
            }

            do
            {
                b = Random.Range(0, 5);
            } while (a == b);//서로 다른 아이템 뽑게 하기
            while (dropCount == 1)
            {
                switch (b)
                {
                    case 0:
                        if (invCon.occupiedRect_shield[Pos] != -1)//만약 같은 맵이면 다시 뽑기
                        {
                            break;
                        }
                        Instantiate(shield);
                        invCon.SpawnShield(shieldSpawnCount);

                        shieldSpawnCount++;
                        dropCount++;
                        break;

                    case 1:
                        if (invCon.occupiedRect_armor[Pos] != -1)
                        {
                            break;
                        }
                        Instantiate(armor);
                        invCon.SpawnArmor(armorSpawnCount);
                        armorSpawnCount++;
                        dropCount++;
                        break;

                    case 2:
                        if (invCon.occupiedRect_shoe[Pos] != -1)
                        {
                            break;
                        }
                        Instantiate(shoes);
                        invCon.SpawnShoe(shoesSpawnCount);
                        shoesSpawnCount++;
                        dropCount++;
                        break;

                    case 3:
                        if (invCon.occupiedRect_sword[Pos] != -1)
                        {
                            break;
                        }
                        Instantiate(sword);
                        invCon.SpawnSword(swordSpawnCount);
                        swordSpawnCount++;
                        dropCount++;
                        break;

                    case 4:
                        if (invCon.occupiedRect_ring[Pos] != -1)
                        {
                            break;
                        }
                        Instantiate(accessories);
                        invCon.SpawnRing(accessorySpawnCount);
                        accessorySpawnCount++;
                        dropCount++;
                        break;
                }
                dropCount = 0;
            }
        }
        else
        {
            Debug.Log("Player is at starting position");
        }
    }

}
