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

        if (FindObjectOfType<Player>() != null) // 플레이어가 살아있는지 확인해야함 !!
        {
            float distance = distToPlayer();
            if (distance <= Range)       // 플레이어가 시야 안에 들어왔다
            {
                if (distance <= attackRange) nextRoutines.Enqueue(NewActionRoutine(meleeAttack(0.5f, 0.25f, 1.0f)));    // 플레이어를 공격한다
                else nextRoutines.Enqueue(NewActionRoutine(moveTowardPlayer(MovementSpeed)));       // 플레이어를 향해 움직인다
            }
            else
                nextRoutines.Enqueue(NewActionRoutine(WaitRoutine(1f)));
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

        transform.position = Vector2.MoveTowards(transform.position, GetPlayerPos(), playerSpeed * speedMultiplier * Time.deltaTime); // 5f (플레이어 속도) * 몬스터 속도 비율
        yield return null;


    }
}
