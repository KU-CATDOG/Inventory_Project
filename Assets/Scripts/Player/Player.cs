using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float health;
    public float maxHealth;
    public float attackDamage;
    public float attackSpeed;
    public float moveSpeed;
    public bool isInvincible = false;

    #region Stats
    private float shieldDmg = 0f;
    private float defense = 0f;
    public float additionalMS = 0f;
    public float additionalDMG = 0f;
    private float tenacity = 0f;
    #endregion

    public Transform attackPoint;
    public Transform hit;
    public Vector3 tempAttackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public Vector3 CursorPos;

    public float attackRate = 2f;
    float nextAttackTime = 0f;

    public Rigidbody2D rb;
    Vector2 movement;

    public List<Items> Inventory;

    public testInvCon invCon;


    // Start is called before the first frame update
    void Start()
    {
        attackDamage = 10f;
        moveSpeed = 5f;
        maxHealth = health = 100;
        additionalDMG = attackDamage;
        additionalMS = moveSpeed;

        for (int i = 0; i < Inventory.Count; i++)
        {
            shieldDmg += Inventory[i].shieldDamage;
            defense += Inventory[i].defense;
            additionalMS += Inventory[i].moveSpeed;
            additionalDMG += Inventory[i].damage;
            tenacity += Inventory[i].tenacity;
        }

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector3 cursorDir = mousePosition - attackPoint.position;
        cursorDir = new Vector3(cursorDir.x, cursorDir.y, transform.position.z);

        float cursorAngle = Mathf.Atan2(cursorDir.y, cursorDir.x) * Mathf.Rad2Deg;
        bool isCursorRight = cursorAngle < 90 && cursorAngle > -90;
        attackPoint.localScale = new Vector3(1, isCursorRight ? 1 : -1, 1);
        attackPoint.rotation = Quaternion.Euler(0, 0, cursorAngle);

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if(Time.time >= nextAttackTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }

    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * additionalMS * Time.fixedDeltaTime);
    }

    private void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(hit.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<MonsterClass>().GetDamaged(additionalDMG);
            Debug.Log("Enemy damage taken " + additionalDMG);
        }
    }

    public void GetDamaged(float damage)
    {
        if (!isInvincible)
        {
            Debug.Log("Damage taken  " + damage);
            health -= damage;
            if(health <= 0)
            {
                Debug.Log("Player died");
                gameObject.SetActive(false);
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (hit == null) return;
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(hit.position, attackRange);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }

    private void PlayerShift()
    {
        int compareXPos, compareYPos;
        int xPos, yPos;
        if (transform.position.x < -8)
        {
            xPos = -1;
        }
        else if (transform.position.x < 8)
        {
            xPos = 0;
        }
        else if (transform.position.x < 24)
        {
            xPos = 1;
        }
        else if (transform.position.x < 40)
        {
            xPos = 2;
        }
        else if (transform.position.x < 56)
        {
            xPos = 3;
        }
        else
        {
            Debug.Log("Out of X Bounds");
        }
        if (transform.position.y < 4)
        {
            yPos = -1;
        }
        else if (transform.position.y < 8)
        {
            yPos = 0;
        }
        else if (transform.position.y < 24)
        {
            yPos = 1;
        }
        else if (transform.position.y < 40)
        {
            yPos = 2;
        }
        else if (transform.position.y < 56)
        {
            yPos = 3;
        }
        else
        {
            Debug.Log("Out of Y Bounds");
        }
    }


}
