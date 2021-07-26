using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunnerTriggers : MonoBehaviour
{
    GameObject gunner;

    public enum Type
    {
        right,
        left,
        up,
        down,
    }
    public Type type;

    private void Start()
    {
        gunner = transform.parent.transform.parent.gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Wall"))
        {
            switch(type)
            {
                case Type.right:
                    gunner.GetComponent<RazorGunner>().contact_right = true;
                    break;
                case Type.left:
                    gunner.GetComponent<RazorGunner>().contact_left = true;
                    break;
                case Type.up:
                    gunner.GetComponent<RazorGunner>().contact_up = true;
                    break;
                case Type.down:
                    gunner.GetComponent<RazorGunner>().contact_down = true;
                    break;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            switch (type)
            {
                case Type.right:
                    gunner.GetComponent<RazorGunner>().contact_right = false;
                    break;
                case Type.left:
                    gunner.GetComponent<RazorGunner>().contact_left = false;
                    break;
                case Type.up:
                    gunner.GetComponent<RazorGunner>().contact_up = false;
                    break;
                case Type.down:
                    gunner.GetComponent<RazorGunner>().contact_down = false;
                    break;
            }
        }
    }
}
