using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debuffer : MonsterClass
{
    float playerSpeed = 5f;
    public float ShootPower = 500f;

    public GameObject Bullet_Prefab;

    bool DirReverse = false;
    Rigidbody2D rigid;

    protected override void Start()
    {
        base.Start();
        MaxHealth = Health = 50f;
        MovementSpeed = 0.33f;
        Range = 10f;
        Size = 1f;
        rigid = GetComponent<Rigidbody2D>();
    }
    protected override Queue<IEnumerator> DecideNextRoutine()
    {
        Queue<IEnumerator> nextRoutines = new Queue<IEnumerator>();

        if (FindObjectOfType<Player>() != null)
        {
            if (distToPlayer() <= Range)
            {
                Debug.Log("Aiming");
                nextRoutines.Enqueue(NewActionRoutine(WaitRoutine(3f)));
                nextRoutines.Enqueue(NewActionRoutine(Shoot(ShootPower, Bullet_Prefab)));
            }
            else
            {
                Vector3 RandDir = Random.insideUnitCircle.normalized;

                for (int i = 1; i <= 200; i++)
                {
                    nextRoutines.Enqueue(NewActionRoutine(MoveRandomly(MovementSpeed, RandDir)));
                }
                nextRoutines.Enqueue(NewActionRoutine(WaitRoutine(1.5f)));
            }
        }
        else nextRoutines.Enqueue(NewActionRoutine(WaitRoutine(1f)));

        return nextRoutines;
    }

    private IEnumerator MoveRandomly(float speedMultiplier, Vector3 dir)
    {
        if (DirReverse)
        {
            dir.x *= -1; dir.y *= -1;
        }
        rigid.MovePosition(transform.position + dir * speedMultiplier * Time.fixedDeltaTime * playerSpeed);

        yield return null;
    }
    private IEnumerator Shoot(float ShootPower, GameObject Bullet)
    {
        if (distToPlayer() <= Range)
        {
            Vector3 dir = (GetPlayerPos() - transform.position).normalized;

            GameObject bullet = Instantiate(Bullet);
            bullet.transform.position = transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            bullet.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            bullet.GetComponent<Rigidbody2D>().AddForce(ShootPower * dir);
        }

        yield return null;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
            DirReverse = !DirReverse;
    }
}
