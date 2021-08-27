using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Berserker : MonsterClass
{
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    float attackRange;
    float playerSpeed = 5f;
    protected override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody2D>();
        MaxHealth = Health = 80f;
        //Health = 10f; //반피 이하 실험용
        AttackDamage = 15f;
        MovementSpeed = 0.75f;
        Range = 7f;
        Size = 2f;
        attackRange = 2f;
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprites[0];



    }
    public override void GetDamaged(float damage)
    {
        base.GetDamaged(damage);
        
    }
    protected override Queue<IEnumerator> DecideNextRoutine()
    {
        Queue<IEnumerator> nextRoutines = new Queue<IEnumerator>();
        if (Health < MaxHealth / 2)
        {
            AttackDamage = 30f;
            MovementSpeed = 1.5f;
            //spriteRenderer.sprite = sprites[1];
        }
        if (FindObjectOfType<Player>() != null) // 플레이어가 살아있는지 확인해야함 !!
        {
            float distance = distToPlayer();
            if (distance <= Range)       // 플레이어가 시야 안에 들어왔다
            {
                if (distance <= attackRange)
                {
                    nextRoutines.Enqueue(NewActionRoutine(meleeAttack(0.5f, 0.25f, 1.0f)));    // 플레이어를 공격한다

                }
                else nextRoutines.Enqueue(NewActionRoutine(moveTowardPlayer(MovementSpeed)));       // 플레이어를 향해 움직인다
            }
            else
                nextRoutines.Enqueue(NewActionRoutine(MoveRandom(MovementSpeed)));
        }
        else nextRoutines.Enqueue(NewActionRoutine(WaitRoutine(1f)));

        return nextRoutines;
    }
    private IEnumerator meleeAttack(float firstDelay, float onHit, float secondDelay)   // 플레이어에게 근접공격
    {
        GameObject player = FindObjectOfType<Player>().gameObject;
        yield return new WaitForSeconds(firstDelay);
        player.GetComponent<Player>().GetDamaged(AttackDamage);
        yield return new WaitForSeconds(secondDelay);

    }
    private IEnumerator moveTowardPlayer(float speedMultiplier)     // 플레이어를 향해 움직인다
    {
        //Debug.Log(GetPlayerPos());
        //Debug.Log(GetPlayerPos().normalized);
        //yield return MoveRoutine(GetPlayerPos().normalized, 10f);
        Vector2 direction = (Vector2)(GetPlayerPos() - GetObjectPos()).normalized;
        if (direction.x > 0 && direction.x > Mathf.Abs(direction.y))//오른쪽으로 감
        {
            spriteRenderer.sprite = sprites[1];
        }
        else if (direction.x < 0 && direction.x < -Mathf.Abs(direction.y))
        {
            spriteRenderer.sprite = sprites[2];
        }
        else if (direction.y > 0)
        {
            spriteRenderer.sprite = sprites[3];
        }
        else
        {
            spriteRenderer.sprite = sprites[0];
        }

        rb.MovePosition(rb.position + direction * playerSpeed * speedMultiplier * Time.fixedDeltaTime);// 5f (플레이어 속도) * 몬스터 속도 비율
        yield return null;


    }
    private IEnumerator MoveRandom(float speedMultiplier)     // 플레이어를 향해 움직인다
    {
        //Debug.Log(GetPlayerPos());
        //Debug.Log(GetPlayerPos().normalized);
        //yield return MoveRoutine(GetPlayerPos().normalized, 10f);
        Vector3 ObjectPos = GetObjectPos();
        Vector3 vector1 = new Vector3(2, 0, 0);
        Vector3 vector2 = new Vector3(0, 2, 0);
        int a = Random.Range(0, 4);
        switch (a)
        {
            case 0:
                ObjectPos += vector1;
                break;
            case 1:
                ObjectPos += vector2;
                break;
            case 2:
                ObjectPos -= vector1;
                break;
            case 3:
                ObjectPos -= vector2;
                break;

        }
        transform.position = Vector2.MoveTowards(transform.position, ObjectPos, playerSpeed * speedMultiplier * Time.deltaTime); // 5f (플레이어 속도) * 몬스터 속도 비율
        yield return null;


    }
}