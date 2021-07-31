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

        if (FindObjectOfType<Player>() != null) // 플레이어가 살아있는지 확인해야함 !!
        {
            float distance = distToPlayer();
            if (distance <= attackRange) nextRoutines.Enqueue(NewActionRoutine(touchDamage(1.0f)));    // 플레이어를 공격한다
            else nextRoutines.Enqueue(NewActionRoutine(moveTowardPlayer(MovementSpeed)));       // 플레이어를 향해 움직인다
        }
        else nextRoutines.Enqueue(NewActionRoutine(WaitRoutine(1f)));

        return nextRoutines;
    }

    private IEnumerator touchDamage(float delay)    //플레이어와 닿으면 대미지를 입힌다
    {
        GameObject player = FindObjectOfType<Player>().gameObject;
        player.GetComponent<Player>().GetDamaged(AttackDamage);
        yield return new WaitForSeconds(delay);
    }

    private IEnumerator moveTowardPlayer(float speedMultiplier)     // 플레이어를 향해 움직인다
    {
        transform.position = Vector2.MoveTowards(transform.position, GetPlayerPos(), playerSpeed * speedMultiplier * Time.deltaTime); // 5f (플레이어 속도) * 몬스터 속도 비율
        yield return null;
    }
}
