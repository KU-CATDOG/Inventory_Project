using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonsterClass
{

    float attackRange;
    float playerSpeed = 5f;     
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
        player.GetComponent<Player>().GetDamaged(AttackDamage);
        yield return new WaitForSeconds(secondDelay);

    }
    private IEnumerator moveTowardPlayer(float speedMultiplier)     // �÷��̾ ���� �����δ�
    {
        //Debug.Log(GetPlayerPos());
        //Debug.Log(GetPlayerPos().normalized);
        //yield return MoveRoutine(GetPlayerPos().normalized, 10f);

        transform.position = Vector2.MoveTowards(transform.position, GetPlayerPos(), playerSpeed * speedMultiplier * Time.deltaTime); // 5f (�÷��̾� �ӵ�) * ���� �ӵ� ����
        yield return null;


    }
}
