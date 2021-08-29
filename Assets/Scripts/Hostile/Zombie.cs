using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonsterClass
{

    float attackRange;
    float playerSpeed = 5f;
    public Rigidbody2D rb;
    public Sprite front, back, left, right;
    public SpriteRenderer spriteRenderer;
    public Animator anim;
    //public Animation anim;

    protected override void Start()
    {
        base.Start();
        MaxHealth = Health = 35f;
        AttackDamage = 8f;
        MovementSpeed = 0.5f;
        Range = 7f;
        Size = 1f;
        attackRange = 2f;
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
            float distance = distToPlayer();
            if (distance <= Range)       // �÷��̾ �þ� �ȿ� ���Դ�
            {
                if (distance <= attackRange) nextRoutines.Enqueue(NewActionRoutine(meleeAttack(0.5f, 0.25f, 1.0f)));    // �÷��̾ �����Ѵ�
                else nextRoutines.Enqueue(NewActionRoutine(moveTowardPlayer(MovementSpeed)));       // �÷��̾ ���� �����δ�
            }
            else
                nextRoutines.Enqueue(NewActionRoutine(WaitRoutine(1f)));
        }
        else nextRoutines.Enqueue(NewActionRoutine(WaitRoutine(1f)));

        return nextRoutines;
    }
    private IEnumerator meleeAttack(float firstDelay, float onHit, float secondDelay)   // �÷��̾�� ��������
    {
        GameObject player = FindObjectOfType<Player>().gameObject;
        yield return new WaitForSeconds(firstDelay);
        //�����̴� �ִϸ��̼�
        if (spriteRenderer.sprite == left)
        {
            anim.SetBool("LeftAttack", true);
            anim.SetBool("RightAttack", false);
            anim.SetBool("FrontAttack", false);
            anim.SetBool("BackAttack", false);
        }
        else if (spriteRenderer.sprite == right)
        {
            anim.SetBool("LeftAttack", false);
            anim.SetBool("RightAttack", true);
            anim.SetBool("FrontAttack", false);
            anim.SetBool("BackAttack", false);
        }
        else if (spriteRenderer.sprite == back)
        {
            anim.SetBool("LeftAttack", false);
            anim.SetBool("RightAttack", false);
            anim.SetBool("FrontAttack", false);
            anim.SetBool("BackAttack", true);
        }
        else
        {
            anim.SetBool("LeftAttack", false);
            anim.SetBool("RightAttack", false);
            anim.SetBool("FrontAttack", true);
            anim.SetBool("BackAttack", false);
        }
        player.GetComponent<Player>().GetDamaged(AttackDamage);
        yield return new WaitForSeconds(secondDelay);

    }
    private IEnumerator moveTowardPlayer(float speedMultiplier)     // �÷��̾ ���� �����δ�
    {
        Vector2 direction = (Vector2)(GetPlayerPos() - GetObjectPos()).normalized;
        rb.MovePosition(rb.position + direction * playerSpeed * speedMultiplier * Time.fixedDeltaTime);
        if (direction.x < -0.7f)
        {
            anim.SetBool("OnLeft", true);
            anim.SetBool("OnRight", false);
            anim.SetBool("OnFront", false);
            anim.SetBool("OnBack", false);
        }
        else if (direction.x > 0.7f)
        {
            anim.SetBool("OnLeft", false);
            anim.SetBool("OnRight", true);
            anim.SetBool("OnFront", false);
            anim.SetBool("OnBack", false);
        }
        else
        {
            if (direction.y > 0)
            {
                anim.SetBool("OnLeft", false);
                anim.SetBool("OnRight", false);
                anim.SetBool("OnFront", false);
                anim.SetBool("OnBack", true);
            }
            else
            {
                anim.SetBool("OnLeft", false);
                anim.SetBool("OnRight", false);
                anim.SetBool("OnFront", true);
                anim.SetBool("OnBack", false);
            }
        }
        yield return null;
    }
}
