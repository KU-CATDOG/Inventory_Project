using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomber : MonsterClass
{

    float attackRange;
    float playerSpeed = 5f;
    public SpriteRenderer spriteRenderer;
    //public Sprite idleSprite, shootSprite;
    public Sprite front, back, side;
    bool isFirstMotion = true;
    public GameObject bomb, warning, player;
    Vector2 playerDir;
    protected override void Start()
    {
        base.Start();
        MaxHealth = Health = 60f;
        Size = 1.5f;
        attackRange = 2.5f;
        //spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }
    public override void GetDamaged(float damage)
    {
        base.GetDamaged(damage);
    }

    protected override Queue<IEnumerator> DecideNextRoutine()
    {
        Queue<IEnumerator> nextRoutines = new Queue<IEnumerator>();

        if (FindObjectOfType<Player>() != null) // 플레이어가 살아있는지 확인해야함 !!
        {
            nextRoutines.Enqueue(NewActionRoutine(shootSprite(bomb)));
            nextRoutines.Enqueue(NewActionRoutine(throwBomb(bomb, 3f)));
            nextRoutines.Enqueue(NewActionRoutine(shootSprite(bomb)));
            nextRoutines.Enqueue(NewActionRoutine(WaitRoutine(2f)));
        }
        else nextRoutines.Enqueue(NewActionRoutine(WaitRoutine(1f)));

        return nextRoutines;
    }

    private IEnumerator throwBomb(GameObject bomb, float idleDelay)    //폭탄 던지기
    {
        Vector2 dir = GetPlayerPos() - transform.position;
        GameObject b = Instantiate(bomb);

        //폭탄 생성 후 발사
        if (GetComponent<SpriteRenderer>().sprite == side)
        {
            if (GetComponent<SpriteRenderer>().flipX)
                b.transform.position = new Vector3(0.75f, -0.3f, 0);
            else
                b.transform.position = new Vector3(-0.75f, -0.3f, 0);
        }
        else if (GetComponent<SpriteRenderer>().sprite == back)
            b.transform.position = new Vector3(0, -0.3f, 0);
        else
            b.transform.position = new Vector3(0.15f, 0.06f, 0);
        b.GetComponent<Rigidbody2D>().AddForce(dir * 14.8f);
        
        //경고 존 생성
        warning.transform.position = GetPlayerPos();
        warning.SetActive(true);
        yield return new WaitForSeconds(idleDelay);
        Destroy(b);
        //경고 존 내에 플레이어가 있는지 확인
        if ((GetPlayerPos().x <= warning.transform.position.x + 1.5 && GetPlayerPos().x >= warning.transform.position.x - 1.5) && (GetPlayerPos().y <= warning.transform.position.y + 1.5 && GetPlayerPos().y >= warning.transform.position.y - 1.5))
            player.GetComponent<Player>().GetDamaged(b.GetComponent<Bomb>().Damage);
        warning.SetActive(false);
    }
    
    private IEnumerator shootSprite(GameObject bomb)
    {
        playerDir = player.transform.position.normalized;

        if (playerDir.x < -0.7f)
        {
            spriteRenderer.sprite = side;
            spriteRenderer.flipX = false;
            bomb.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            bomb.GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (playerDir.x > 0.7f)
        {
            spriteRenderer.sprite = side;
            spriteRenderer.flipX = true;
            bomb.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            bomb.GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
            bomb.GetComponent<SpriteRenderer>().flipX = false;
            if (playerDir.y > 0)
            {
                spriteRenderer.sprite = back;
                bomb.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -90f));
            }
            else
            {
                spriteRenderer.sprite = front;
                bomb.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90f));
            }
        }
        yield return null;
    }
}
