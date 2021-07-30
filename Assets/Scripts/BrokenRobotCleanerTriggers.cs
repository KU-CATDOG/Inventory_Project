using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenRobotCleanerTriggers : MonoBehaviour
{
    GameObject monster;

    public enum Dir
    {
        right,
        left,
        up,
        down,
    }
    public Dir dir;

    private void Start()
    {
        monster = transform.parent.transform.parent.gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Wall"))
        {
            switch(dir)
            {
                case Dir.right:
                    monster.GetComponent<BrokenRobotCleaner>().Contact_rWall = true;
                    break;
                case Dir.left:
                    monster.GetComponent<BrokenRobotCleaner>().Contact_lWall = true;
                    break;
                case Dir.up:
                    monster.GetComponent<BrokenRobotCleaner>().Contact_uWall = true;
                    break;
                case Dir.down:
                    monster.GetComponent<BrokenRobotCleaner>().Contact_dWall = true;
                    break;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            switch (dir)
            {
                case Dir.right:
                    monster.GetComponent<BrokenRobotCleaner>().Contact_rWall = false;
                    break;
                case Dir.left:
                    monster.GetComponent<BrokenRobotCleaner>().Contact_lWall = false;
                    break;
                case Dir.up:
                    monster.GetComponent<BrokenRobotCleaner>().Contact_uWall = false;
                    break;
                case Dir.down:
                    monster.GetComponent<BrokenRobotCleaner>().Contact_dWall = false;
                    break;
            }
        }
    }
}
