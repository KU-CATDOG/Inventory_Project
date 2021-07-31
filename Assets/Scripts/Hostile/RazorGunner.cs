using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RazorGunner : MonsterClass
{
    float playerSpeed = 5f;
    public float BulletPower = 5f;
    public GameObject Bullet;

    public bool contact_right = false;
    public bool contact_left = false;
    public bool contact_up = false;
    public bool contact_down = false;

    bool run = false;
    enum Run_dir
    {
        right,
        left,
        up,
        down,
    }
    Run_dir run_dir;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        MaxHealth = Health = 25f;
        AttackDamage = 12f;
        MovementSpeed = 0.5f;
        Size = 1f;
    }
    public override void GetDamaged(float damage)
    {
        base.GetDamaged(damage);
    }

    protected override Queue<IEnumerator> DecideNextRoutine()
    {
        Queue<IEnumerator> nextRoutines = new Queue<IEnumerator>();

        if (FindObjectOfType<Player>() != null)
        {
            for (float t = 0; t <= 0.8f; t += Time.deltaTime)
            {
                nextRoutines.Enqueue(NewActionRoutine(moveOppositeOfPlayer(MovementSpeed)));
            }

            nextRoutines.Enqueue(NewActionRoutine(WaitRoutine(0.5f)));
            nextRoutines.Enqueue(NewActionRoutine(ShootGun(Bullet, BulletPower)));
            nextRoutines.Enqueue(NewActionRoutine(WaitRoutine(1f)));
        }
        else nextRoutines.Enqueue(NewActionRoutine(WaitRoutine(1f)));

        return nextRoutines;
    }

    private IEnumerator moveOppositeOfPlayer(float speedMultiplier)
    {
        if (!contact_right && !contact_up && !contact_left && !contact_down)
        {
            Vector3 pos = transform.position;
            Vector3 direction = (pos - GetPlayerPos()).normalized;

            transform.position = Vector2.MoveTowards(transform.position, direction * 1000f, playerSpeed * speedMultiplier * Time.deltaTime);
        }
        else
        {
            //�𼭸��� �����ִ� ���
            if (contact_right && contact_up)
            {
                if (GetPlayerPos().y >= transform.position.y)
                {
                    transform.position = Vector2.MoveTowards(transform.position, Vector2.down * 1000f, playerSpeed * speedMultiplier * Time.deltaTime);
                }
                else if (GetPlayerPos().x >= transform.position.x)
                {
                    transform.position = Vector2.MoveTowards(transform.position, Vector2.left * 1000f, playerSpeed * speedMultiplier * Time.deltaTime);
                }
            }
            else if (contact_right && contact_down)
            {
                if (GetPlayerPos().y <= transform.position.y)
                {
                    transform.position = Vector2.MoveTowards(transform.position, Vector2.up * 1000f, playerSpeed * speedMultiplier * Time.deltaTime);
                }
                else if (GetPlayerPos().x >= transform.position.x)
                {
                    transform.position = Vector2.MoveTowards(transform.position, Vector2.left * 1000f, playerSpeed * speedMultiplier * Time.deltaTime);
                }
            }
            else if (contact_left && contact_up)
            {
                if (GetPlayerPos().y >= transform.position.y)
                {
                    transform.position = Vector2.MoveTowards(transform.position, Vector2.down * 1000f, playerSpeed * speedMultiplier * Time.deltaTime);
                }
                else if (GetPlayerPos().x <= transform.position.x)
                {
                    transform.position = Vector2.MoveTowards(transform.position, Vector2.right * 1000f, playerSpeed * speedMultiplier * Time.deltaTime);
                }
            }
            else if (contact_left && contact_down)
            {
                if (GetPlayerPos().y <= transform.position.y)
                {
                    transform.position = Vector2.MoveTowards(transform.position, Vector2.up * 1000f, playerSpeed * speedMultiplier * Time.deltaTime);
                }
                else if (GetPlayerPos().x <= transform.position.x)
                {
                    transform.position = Vector2.MoveTowards(transform.position, Vector2.right * 1000f, playerSpeed * speedMultiplier * Time.deltaTime);
                }
            }
            //���� �鸸 ���� ����ִ� ���
            else if (contact_right || contact_left)
            {
                if ((GetPlayerPos().x > transform.position.x) && contact_right)
                {
                    Vector3 pos = transform.position;
                    Vector3 direction = (pos - GetPlayerPos()).normalized;

                    transform.position = Vector2.MoveTowards(transform.position, direction * 1000f, playerSpeed * speedMultiplier * Time.deltaTime);
                }
                else if ((GetPlayerPos().x < transform.position.x) && contact_left)
                {
                    Vector3 pos = transform.position;
                    Vector3 direction = (pos - GetPlayerPos()).normalized;

                    transform.position = Vector2.MoveTowards(transform.position, direction * 1000f, playerSpeed * speedMultiplier * Time.deltaTime);
                }
                else if (GetPlayerPos().y >= transform.position.y)
                {
                    transform.position = Vector2.MoveTowards(transform.position, Vector2.down * 1000f, playerSpeed * speedMultiplier * Time.deltaTime);
                }
                else if (GetPlayerPos().y < transform.position.y)
                {
                    transform.position = Vector2.MoveTowards(transform.position, Vector2.up * 1000f, playerSpeed * speedMultiplier * Time.deltaTime);
                }
            }
            else if (contact_up || contact_down)
            {
                if ((GetPlayerPos().y > transform.position.y) && contact_up)
                {
                    Vector3 pos = transform.position;
                    Vector3 direction = (pos - GetPlayerPos()).normalized;

                    transform.position = Vector2.MoveTowards(transform.position, direction * 1000f, playerSpeed * speedMultiplier * Time.deltaTime);
                }
                else if ((GetPlayerPos().y < transform.position.y) && contact_down)
                {
                    Vector3 pos = transform.position;
                    Vector3 direction = (pos - GetPlayerPos()).normalized;

                    transform.position = Vector2.MoveTowards(transform.position, direction * 1000f, playerSpeed * speedMultiplier * Time.deltaTime);
                }
                else if (GetPlayerPos().x >= transform.position.x)
                {
                    transform.position = Vector2.MoveTowards(transform.position, Vector2.left * 1000f, playerSpeed * speedMultiplier * Time.deltaTime);
                }
                else if (GetPlayerPos().x < transform.position.x)
                {
                    transform.position = Vector2.MoveTowards(transform.position, Vector2.right * 1000f, playerSpeed * speedMultiplier * Time.deltaTime);
                }
            }
        }

        yield return null;
    }

    private IEnumerator ShootGun(GameObject bullet, float power)
    {
        Vector3 direction = (GetPlayerPos() - transform.position).normalized;
        GameObject b = Instantiate(bullet);
        b.transform.position = transform.position;
        b.GetComponent<Bullet>().Damage = AttackDamage;

        Vector3 new_dir = GetPlayerPos() - transform.position;
        float angle = Mathf.Atan2(new_dir.y, new_dir.x) * Mathf.Rad2Deg;
        b.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        b.GetComponent<Rigidbody2D>().AddForce(direction * power);

        yield return null;
    }
}