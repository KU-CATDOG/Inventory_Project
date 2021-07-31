using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuffyFlesh : MonsterClass
{

    float attackRange;
    float playerSpeed = 5f;
    protected override void Start()
    {
        base.Start();
        MaxHealth = Health = 100f;
        AttackDamage = 10f;
        MovementSpeed = 0.2f;
        Size = 2f;
        attackRange = 2.5f;
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
            if (distance <= attackRange) nextRoutines.Enqueue(NewActionRoutine(touchDamage(1.0f)));    // �÷��̾ �����Ѵ�
            else nextRoutines.Enqueue(NewActionRoutine(moveTowardPlayer(MovementSpeed)));       // �÷��̾ ���� �����δ�
        }
        else nextRoutines.Enqueue(NewActionRoutine(WaitRoutine(1f)));

        return nextRoutines;
    }

    private IEnumerator touchDamage(float delay)    //�÷��̾�� ������ ������� ������
    {
        GameObject player = FindObjectOfType<Player>().gameObject;
        player.GetComponent<Player>().GetDamaged(AttackDamage);
        yield return new WaitForSeconds(delay);
    }

    private IEnumerator moveTowardPlayer(float speedMultiplier)     // �÷��̾ ���� �����δ�
    {
        transform.position = Vector2.MoveTowards(transform.position, GetPlayerPos(), playerSpeed * speedMultiplier * Time.deltaTime); // 5f (�÷��̾� �ӵ�) * ���� �ӵ� ����
        yield return null;
    }
}
