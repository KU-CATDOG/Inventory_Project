using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCollisionLongitudinal : MonoBehaviour
{
    public Player player;
    public testInvCon invCon;
    private Vector2 savePos;
    public MapLoadTest mapLoad;

    private Player.PlayerDirection saveDirection;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        savePos = collision.transform.position;
        saveDirection = player.playerDirection;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        bool isSuccess;
        if (player.playerDirection == Player.PlayerDirection.up || player.playerDirection == Player.PlayerDirection.leftUp || player.playerDirection == Player.PlayerDirection.rightUp)
        {
            if (saveDirection == Player.PlayerDirection.up || saveDirection == Player.PlayerDirection.leftUp || saveDirection == Player.PlayerDirection.rightUp)
            {
                isSuccess = invCon.PlayerPositionShiftUp();
                if (!isSuccess)
                {
                    collision.transform.position = savePos;
                }
                else
                {
                    mapLoad.DestroySpawnedMap();
                    invCon.GetNearbyItems();
                    mapLoad.SpawnMap();
                }
            }

        }
        else if (player.playerDirection == Player.PlayerDirection.down || player.playerDirection == Player.PlayerDirection.leftDown || player.playerDirection == Player.PlayerDirection.rightDown)
        {
            if (saveDirection == Player.PlayerDirection.down || saveDirection == Player.PlayerDirection.leftDown || saveDirection == Player.PlayerDirection.rightDown)
            {
                isSuccess = invCon.PlayerPositionShiftDown();
                if (!isSuccess)
                {
                    collision.transform.position = savePos;
                }
                else
                {
                    mapLoad.DestroySpawnedMap();
                    invCon.GetNearbyItems();
                    mapLoad.SpawnMap();
                }
            }

        }
        else
        {
            Debug.Log("ignore this");
        }
    }
}
