using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumeItem : MonoBehaviour
{
    GameObject player;
    int itemCount;
    bool isInRoom = false;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>().gameObject;
        itemCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
            HealPlayer();
        if (Input.GetKeyDown(KeyCode.M))
            DamagePlayer();
        if (Input.GetKeyDown(KeyCode.N))
            itemCount++;
        if (Input.GetKeyDown(KeyCode.R))
            isInRoom = !isInRoom;
    }

    /*public void Consume()
    {
        if (itemCount > 0)
        {
            //function
            itemCount--;
        }
        else
        {
            Debug.Log("There's no items!");
        }
    }*/

    void HealPlayer()   //힐 기능, 아이템 개수에 따라 사용 제한
    {
        if (itemCount > 0 && !isInRoom)
        {
            //function
            if (player.GetComponent<Player>().health + 10 <= player.GetComponent<Player>().maxHealth)
                player.GetComponent<Player>().health += 10;
            else
                player.GetComponent<Player>().health = player.GetComponent<Player>().maxHealth;
            Debug.Log(player.GetComponent<Player>().health);
            
            itemCount--;
        }
        else
        {
            Debug.Log("There's no items!");
        }
    }

    void DamagePlayer()
    {
        player.GetComponent<Player>().health -= 8;
        Debug.Log(player.GetComponent<Player>().health);
    }
}
