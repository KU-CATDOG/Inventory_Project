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

        if (FindObjectOfType<Player>() != null) // �÷��̾ ����ִ��� Ȯ���ؾ��� !!
        {
            float distance =  distToPlayer();
            if (distance <= Range)       // �÷��̾ �þ� �ȿ� ���Դ�
            {
                if (distance <= attackRange) {
                    nextRoutines.Enqueue(NewActionRoutine(explosion(1.5f)));    // �÷��̾ �����Ѵ�
                    
                } 
                else nextRoutines.Enqueue(NewActionRoutine(moveTowardPlayer(MovementSpeed)));       // �÷��̾ ���� �����δ�
            }
            else
                nextRoutines.Enqueue(NewActionRoutine(MoveRandom(MovementSpeed)));
        }
        else nextRoutines.Enqueue(NewActionRoutine(WaitRoutine(1f)));

        return nextRoutines;
    }
    private IEnumerator explosion(float firstDelay)   // �÷��̾�� ��������
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
    private IEnumerator moveTowardPlayer(float speedMultiplier)     // �÷��̾ ���� �����δ�
    {
        //Debug.Log(GetPlayerPos());
        //Debug.Log(GetPlayerPos().normalized);
        //yield return MoveRoutine(GetPlayerPos().normalized, 10f);
        Vector3 direction = (Vector2)(GetPlayerPos() - GetObjectPos()).normalized;

        rb.MovePosition(rb.position + direction * playerSpeed * speedMultiplier * Time.fixedDeltaTime);// 5f (�÷��̾� �ӵ�) * ���� �ӵ� ����
        yield return null;


    }
    private IEnumerator MoveRandom(float speedMultiplier)     // �÷��̾ ���� �����δ�
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
        transform.position = Vector2.MoveTowards(transform.position, ObjectPos, playerSpeed * speedMultiplier * Time.deltaTime); // 5f (�÷��̾� �ӵ�) * ���� �ӵ� ����
        yield return null;


    }
}
