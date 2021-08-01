using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowBullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 10f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
            Destroy(this.gameObject);
        if(collision.gameObject == FindObjectOfType<Player>().gameObject)
        {
            collision.GetComponent<Player>().moveSpeed /= 2;
            Invoke("PlayerSpeedRecover", 3.0f);
            this.gameObject.SetActive(false);
            Destroy(this.gameObject, 3.1f);
        }
    }
    private void PlayerSpeedRecover()
    {
        GameObject.FindObjectOfType<Player>().moveSpeed *= 2;
    }
}
