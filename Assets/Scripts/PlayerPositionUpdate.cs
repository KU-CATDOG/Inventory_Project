using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPositionUpdate : MonoBehaviour
{
    GameObject player;
    public testInvCon invCon;
    public MapLoadTest mapLoad;

    private void Start()
    {
        player = FindObjectOfType<Player>().gameObject;
    }

    void Update()
    {
        if (player.transform.position.x < -8)
        {
            invCon.playerPosition = -1;
            Debug.Log("You reached the end of the map!(1)");
        }
        else if (player.transform.position.x < 8)
        {
            if (player.transform.position.y < -5)
            {
                Debug.LogError("Player is out of bounds");
            }
            else if (player.transform.position.y < 4)
            {
                invCon.playerPosition = 0;
            }
            else if (player.transform.position.y < 13)
            {
                invCon.playerPosition = 1;
            }
            else if (player.transform.position.y < 22)
            {
                invCon.playerPosition = 2;
            }
            else if (player.transform.position.y < 31)
            {
                invCon.playerPosition = 3;
            }
            else if (player.transform.position.y < 40)
            {
                invCon.playerPosition = 4;
            }
            else if (player.transform.position.y < 49)
            {
                invCon.playerPosition = 5;
            }
            else if (player.transform.position.y < 58)
            {
                invCon.playerPosition = 6;
            }
            else if (player.transform.position.y < 67)
            {
                invCon.playerPosition = 7;
            }
            else if (player.transform.position.y < 76)
            {
                invCon.playerPosition = 8;
            }
            else
            {
                Debug.LogError("Player is out of bounds");
            }
        }
        else if (player.transform.position.x < 24)
        {
            if (player.transform.position.y < -5)
            {
                Debug.LogError("Player is out of bounds");
            }
            else if (player.transform.position.y < 4)
            {
                invCon.playerPosition = 9;
            }
            else if (player.transform.position.y < 13)
            {
                invCon.playerPosition = 10;
            }
            else if (player.transform.position.y < 22)
            {
                invCon.playerPosition = 11;
            }
            else if (player.transform.position.y < 31)
            {
                invCon.playerPosition = 12;
            }
            else if (player.transform.position.y < 40)
            {
                invCon.playerPosition = 13;
            }
            else if (player.transform.position.y < 49)
            {
                invCon.playerPosition = 14;
            }
            else if (player.transform.position.y < 58)
            {
                invCon.playerPosition = 15;
            }
            else if (player.transform.position.y < 67)
            {
                invCon.playerPosition = 16;
            }
            else if (player.transform.position.y < 76)
            {
                invCon.playerPosition = 17;
            }
            else
            {
                Debug.LogError("Player is out of bounds");
            }
        }
        else if (player.transform.position.x < 40)
        {
            if (player.transform.position.y < -5)
            {
                Debug.LogError("Player is out of bounds");
            }
            else if (player.transform.position.y < 4)
            {
                invCon.playerPosition = 18;
            }
            else if (player.transform.position.y < 13)
            {
                invCon.playerPosition = 19;
            }
            else if (player.transform.position.y < 22)
            {
                invCon.playerPosition = 20;
            }
            else if (player.transform.position.y < 31)
            {
                invCon.playerPosition = 21;
            }
            else if (player.transform.position.y < 40)
            {
                invCon.playerPosition = 22;
            }
            else if (player.transform.position.y < 49)
            {
                invCon.playerPosition = 23;
            }
            else if (player.transform.position.y < 58)
            {
                invCon.playerPosition = 24;
            }
            else if (player.transform.position.y < 67)
            {
                invCon.playerPosition = 25;
            }
            else if (player.transform.position.y < 76)
            {
                invCon.playerPosition = 26;
            }
            else
            {
                Debug.LogError("Player is out of bounds");
            }
        }
        else if (player.transform.position.x < 56)
        {
            if (player.transform.position.y < -5)
            {
                Debug.LogError("Player is out of bounds");
            }
            else if (player.transform.position.y < 4)
            {
                invCon.playerPosition = 27;
            }
            else if (player.transform.position.y < 13)
            {
                invCon.playerPosition = 28;
            }
            else if (player.transform.position.y < 22)
            {
                invCon.playerPosition = 29;
            }
            else if (player.transform.position.y < 31)
            {
                invCon.playerPosition = 30;
            }
            else if (player.transform.position.y < 40)
            {
                invCon.playerPosition = 31;
            }
            else if (player.transform.position.y < 49)
            {
                invCon.playerPosition = 32;
            }
            else if (player.transform.position.y < 58)
            {
                invCon.playerPosition = 33;
            }
            else if (player.transform.position.y < 67)
            {
                invCon.playerPosition = 34;
            }
            else if (player.transform.position.y < 76)
            {
                invCon.playerPosition = 35;
            }
            else
            {
                Debug.LogError("Player is out of bounds");
            }
        }
        else
        {
            invCon.playerPosition = 36;
            Debug.Log("You reached the end of the map!");
        }
        mapLoad.DestroySpawnedMap();
        invCon.GetNearbyItems();
        mapLoad.SpawnMap();
    }
}
