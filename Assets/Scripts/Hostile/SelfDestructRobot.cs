using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SelfDestructRobot : MonsterClass
{
    private Rigidbody rb;
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    float attackRange;
    float playerSpeed = 5f;
    protected override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody>();
        MaxHealth = Health = 50f;
        AttackDamage = 60f;
        MovementSpeed = 1.5f;
        Range = 6f;
        Size = 1f;
        attackRange = 0.5f;
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

        if (FindObjectOfType<Player>() != null) // 플레이어가 살아있는지 확인해야함 !!
        {
            float distance =  distToPlayer();
            if (distance <= Range)       // 플레이어가 시야 안에 들어왔다
            {
                if (distance <= attackRange) {
                    nextRoutines.Enqueue(NewActionRoutine(explosion(1.5f)));    // 플레이어를 공격한다
                    
                } 
                else nextRoutines.Enqueue(NewActionRoutine(moveTowardPlayer(MovementSpeed)));       // 플레이어를 향해 움직인다
            }
            else
                nextRoutines.Enqueue(NewActionRoutine(MoveRandom(MovementSpeed)));
        }
        else nextRoutines.Enqueue(NewActionRoutine(WaitRoutine(1f)));

        return nextRoutines;
    }
    private IEnumerator explosion(float firstDelay)   // 플레이어에게 근접공격
    {
        GameObject player = FindObjectOfType<Player>().gameObject;
        GameObject zombie = FindObjectOfType<Zombie>().gameObject;
        spriteRenderer.sprite = sprites[1];
        yield return new WaitForSeconds(firstDelay);
        if(distToPlayer()<= 1.5f)
        {
            player.GetComponent<Player>().GetDamaged(AttackDamage);
        }
        
        Destroy(gameObject);
    }
    private IEnumerator moveTowardPlayer(float speedMultiplier)     // 플레이어를 향해 움직인다
    {
        //Debug.Log(GetPlayerPos());
        //Debug.Log(GetPlayerPos().normalized);
        //yield return MoveRoutine(GetPlayerPos().normalized, 10f);
        Vector3 direction = (Vector2)(GetPlayerPos() - GetObjectPos()).normalized;

        rb.MovePosition(rb.position + direction * playerSpeed * speedMultiplier * Time.fixedDeltaTime);// 5f (플레이어 속도) * 몬스터 속도 비율
        yield return null;


    }
    private IEnumerator MoveRandom(float speedMultiplier)     // 플레이어를 향해 움직인다
    {
        //Debug.Log(GetPlayerPos());
        //Debug.Log(GetPlayerPos().normalized);
        //yield return MoveRoutine(GetPlayerPos().normalized, 10f);
        Vector3 ObjectPos = GetObjectPos();
        Vector3 vector1 = new Vector3 (1, 0, 0);
        Vector3 vector2 = new Vector3 (0, 1, 0);
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
