using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    GameObject player;
    public float Damage;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>().gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
            Destroy(this.gameObject);
        else if (collision.gameObject == player)
        {
            player.GetComponent<Player>().GetDamaged(Damage);
            Destroy(this.gameObject);
        }
    }
}
