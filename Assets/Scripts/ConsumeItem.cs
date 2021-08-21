using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumeItem : MonoBehaviour
{
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
            HealPlayer();
        if (Input.GetKeyDown(KeyCode.M))
            DamagePlayer();
    }

    void HealPlayer()
    {
        if (player.GetComponent<Player>().health + 10 <= player.GetComponent<Player>().maxHealth)
            player.GetComponent<Player>().health += 10;
        else
            player.GetComponent<Player>().health = player.GetComponent<Player>().maxHealth;
        Debug.Log(player.GetComponent<Player>().health);
    }

    void DamagePlayer()
    {
        player.GetComponent<Player>().health -= 8;
        Debug.Log(player.GetComponent<Player>().health);
    }
}
