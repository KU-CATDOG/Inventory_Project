using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCollisionLateral : MonoBehaviour
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
        if (player.playerDirection == Player.PlayerDirection.left || player.playerDirection == Player.PlayerDirection.leftDown || player.playerDirection == Player.PlayerDirection.leftUp)
        {
            if (saveDirection == Player.PlayerDirection.left || saveDirection == Player.PlayerDirection.leftDown || saveDirection == Player.PlayerDirection.leftUp)
            {
                isSuccess = invCon.PlayerPositionShiftLeft();
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
        else if (player.playerDirection == Player.PlayerDirection.right || player.playerDirection == Player.PlayerDirection.rightUp || player.playerDirection == Player.PlayerDirection.rightDown)
        {
            if (saveDirection == Player.PlayerDirection.right || saveDirection == Player.PlayerDirection.rightUp || saveDirection == Player.PlayerDirection.rightDown)
            {
                isSuccess = invCon.PlayerPositionShiftRight();
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
