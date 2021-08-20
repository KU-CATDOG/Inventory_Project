using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordTrap : MonoBehaviour
{
    GameObject player;
    public Sprite idle, attacking;
    SpriteRenderer spriteRenderer;
    bool myCoroutineRunning = false;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>().gameObject;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.name == "Player" && !myCoroutineRunning)
            StartCoroutine(Damage());
    }

    private IEnumerator Damage()
    {
        myCoroutineRunning = true;
        yield return new WaitForSeconds(1f);    //일정 시간?
        spriteRenderer.sprite = attacking;
        //시간이 지난 후 위에 있는지 판정
        if (spriteRenderer.sprite == attacking && (player.transform.position.x <= transform.position.x + 1 && player.transform.position.x >= transform.position.x - 1)
            && (player.transform.position.y <= transform.position.y + 1 && player.transform.position.y >= transform.position.y - 1))
            player.GetComponent<Player>().GetDamaged(5f);
        yield return new WaitForSeconds(1f);
        spriteRenderer.sprite = idle;
        if ((player.transform.position.x <= transform.position.x + 1 && player.transform.position.x >= transform.position.x - 1)
            && (player.transform.position.y <= transform.position.y + 1 && player.transform.position.y >= transform.position.y - 1))
            StartCoroutine(Damage());
        myCoroutineRunning = false;
    }
}
