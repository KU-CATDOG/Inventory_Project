using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomber : MonsterClass
{

    float attackRange;
    float playerSpeed = 5f;
    SpriteRenderer spriteRenderer;
    public Sprite idleSprite, shootSprite;
    bool isFirstMotion = true;
    public GameObject bomb, warning;
    protected override void Start()
    {
        base.Start();
        MaxHealth = Health = 60f;
        AttackDamage = 30f;
        Size = 1.5f;
        attackRange = 2.5f;
        spriteRenderer = GetComponent<SpriteRenderer>();
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
            nextRoutines.Enqueue(NewActionRoutine(motion(3f, 2f)));
            nextRoutines.Enqueue(NewActionRoutine(throwBomb(bomb, 3f)));

        }
        else nextRoutines.Enqueue(NewActionRoutine(WaitRoutine(1f)));

        return nextRoutines;
    }

    private IEnumerator motion(float idleDelay, float shootDelay)    //idle ����
    {
        if (isFirstMotion)
        {
            yield return new WaitForSeconds(idleDelay);
            isFirstMotion = false;
        }
        spriteRenderer.sprite = shootSprite;
        yield return new WaitForSeconds(shootDelay);
        spriteRenderer.sprite = idleSprite;
    }

    private IEnumerator throwBomb(GameObject bomb, float idleDelay)    //��ź ������
    {
        GameObject player = FindObjectOfType<Player>().gameObject;
        Vector2 dir = GetPlayerPos() - transform.position;
        GameObject b = Instantiate(bomb);

        //��ź ���� �� �߻�
        b.transform.position = transform.position;
        b.GetComponent<Bomb>().Damage = AttackDamage;
        b.GetComponent<Rigidbody2D>().AddForce(dir * 16.5f);
        
        //��� �� ����
        warning.transform.position = GetPlayerPos();
        warning.SetActive(true);
        yield return new WaitForSeconds(idleDelay);
        Destroy(b);
        //��� �� ���� �÷��̾ �ִ��� Ȯ��
        if ((GetPlayerPos().x <= warning.transform.position.x + 2 && GetPlayerPos().x >= warning.transform.position.x - 2) && (GetPlayerPos().y <= warning.transform.position.y + 2 && GetPlayerPos().y >= warning.transform.position.y - 2))
            player.GetComponent<Player>().GetDamaged(AttackDamage);
        warning.SetActive(false);
    }
}
