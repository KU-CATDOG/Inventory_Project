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

    public Sprite[] sprites = new Sprite[4];
    SpriteRenderer sr;

    public Transform AttackPosLeft;
    public Transform AttackPosRight;

    protected override void Start()
    {
        base.Start();
        MaxHealth = Health = 50f;
        MovementSpeed = 0.33f;
        Range = 10f;
        Size = 1f;
        rigid = GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();
    }
    protected override Queue<IEnumerator> DecideNextRoutine()
    {
        Queue<IEnumerator> nextRoutines = new Queue<IEnumerator>();

        if (FindObjectOfType<Player>() != null)
        {
            if (distToPlayer() <= Range)
            {
                Debug.Log("Aiming");
                for (int i = 0; i < 6; i++)
                {
                    nextRoutines.Enqueue(NewActionRoutine(ShootAnimSet()));
                    nextRoutines.Enqueue(NewActionRoutine(WaitRoutine(0.5f)));
                }
                nextRoutines.Enqueue(NewActionRoutine(Shoot(ShootPower, Bullet_Prefab)));
            }
            else
            {
                Vector2 RandDir = Random.insideUnitCircle.normalized;

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

    private IEnumerator MoveRandomly(float speedMultiplier, Vector2 dir)
    {
        if (DirReverse)
        {
            dir.x *= -1; dir.y *= -1;
        }

        Debug.Log(dir);
        if (Mathf.Abs(dir.x) > 0.6f)
        {
            if (dir.x > 0.6f)
                sr.sprite = sprites[3];
            else if (dir.x < -0.6f)
                sr.sprite = sprites[2];
        }
        else
        {
            if (dir.y > 0)
                sr.sprite = sprites[1];
            else if (dir.y < 0)
                sr.sprite = sprites[0];
        }

        rigid.MovePosition(transform.position + (Vector3)dir * speedMultiplier * Time.fixedDeltaTime * playerSpeed);

        yield return null;
    }
    private IEnumerator Shoot(float ShootPower, GameObject Bullet)
    {
        if (distToPlayer() <= Range)
        {
            Vector3 attackPos = Vector3.zero;

            if (sr.sprite == sprites[4] || sr.sprite == sprites[5])
                attackPos = transform.position;
            else if (sr.sprite == sprites[6])
                attackPos = AttackPosLeft.position;
            else if (sr.sprite == sprites[7])
                attackPos = AttackPosRight.position;

            Vector3 dir = (GetPlayerPos() - attackPos).normalized;
            GameObject bullet = Instantiate(Bullet);
            bullet.transform.position = attackPos;
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
    IEnumerator ShootAnimSet()
    {
        Vector2 playerDir = (GetPlayerPos() - transform.position).normalized;
        if (playerDir.x > 0.6)
            sr.sprite = sprites[7];
        else if (playerDir.x < -0.6)
            sr.sprite = sprites[6];
        else if (playerDir.y > 0)
            sr.sprite = sprites[5];
        else if (playerDir.y < 0)
            sr.sprite = sprites[4];

        yield return null;
    }
}
