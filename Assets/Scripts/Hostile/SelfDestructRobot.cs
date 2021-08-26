using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SelfDestructRobot : MonsterClass
{
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    public Transform hit;
    public LayerMask enemyLayers;
    float attackRange;

    float playerSpeed = 5f;
    protected override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody2D>();
        MaxHealth = Health = 50f;
        AttackDamage = 60f;
        MovementSpeed = 1.5f;
        Range = 6f;
        Size = 1f;
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

        if (FindObjectOfType<Player>() != null) // �÷��̾ ����ִ��� Ȯ���ؾ��� !!
        {
            float distance =  distToPlayer();
            if (distance <= Range)       // �÷��̾ �þ� �ȿ� ���Դ�
            {
                if (distance <= attackRange) {
                    Debug.Log("triggered");
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
        
        //spriteRenderer.sprite = sprites[1];
        yield return new WaitForSeconds(firstDelay);
        if(distToPlayer()<= 2f)
        {
            player.GetComponent<Player>().GetDamaged(AttackDamage);
        }
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(hit.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<MonsterClass>().GetDamaged(AttackDamage);
        }
        Destroy(gameObject);
    }
    private IEnumerator moveTowardPlayer(float speedMultiplier)     // �÷��̾ ���� �����δ�
    {
        //Debug.Log(GetPlayerPos());
        //Debug.Log(GetPlayerPos().normalized);
        //yield return MoveRoutine(GetPlayerPos().normalized, 10f);
        Vector2 direction = (Vector2)(GetPlayerPos() - GetObjectPos()).normalized;
        if(direction.x>0&& direction.x> Mathf.Abs(direction.y))//���������� ��
        {
            spriteRenderer.sprite = sprites[1];
        }
        else if(direction.x < 0 && direction.x < -Mathf.Abs(direction.y))
        {
            spriteRenderer.sprite = sprites[2];
        }
        else
        {
            spriteRenderer.sprite = sprites[0];
        }

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
