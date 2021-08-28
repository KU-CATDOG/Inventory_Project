using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCollisionLateral : MonoBehaviour
{
    public Player player;
    public testInvCon invCon;
    private Vector2 savePos;

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
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        bool isSuccess;
        if (player.playerDirection == Player.PlayerDirection.left)
        {
            isSuccess = invCon.PlayerPositionShiftLeft();
            if (!isSuccess)
            {
                collision.transform.position = savePos;
            }
        }
        else if (player.playerDirection == Player.PlayerDirection.right)
        {
            isSuccess = invCon.PlayerPositionShiftRight();
            if (!isSuccess)
            {
                collision.transform.position = savePos;
            }
        }
        else
        {
            Debug.Log("ignore this");
        }
    }
}
