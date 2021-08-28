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
    public bool onceBlockDamage = false;

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

    public GameObject InventoryManager;
    private int inventoryOpened;

    float moveSoundTime = 0;

    private Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

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
        if (inventoryOpened == 0)
        {
            OpenInventoryOnce();
        }
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
        movement = movement.normalized;

        #region animation
        if (Mathf.Abs(movement.x) > 0f)
        {
            anim.SetBool("MovingX", true);
            if (movement.x > 0f) GetComponent<SpriteRenderer>().flipX = true;
            else GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            anim.SetBool("MovingX", false);
        }

        #endregion

        if (Vector2.Distance(movement, Vector2.zero) < 0.01f)
        {
            moveSoundTime = Time.time + 0.1f;
        }
        if (Time.time >= moveSoundTime)
        {
            SoundManager.instance.PlayerWalk();
            moveSoundTime = Time.time + 0.3f;
        }

        if (Time.time >= nextAttackTime)
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
        SoundManager.instance.PlayerAttack();
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(hit.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<MonsterClass>().GetDamaged(additionalDMG);
        }
    }

    public void GetDamaged(float damage)
    {
        if (!isInvincible)
        {
            if (onceBlockDamage == true)
            {
                Debug.Log(damage + "Damage blocked");
                onceBlockDamage = false;
            }
            else
            {
                Debug.Log("Damage taken  " + damage);
                SoundManager.instance.PlayerDamaged();
                health -= damage;
                if (health <= 0)
                {
                    Debug.Log("Player died");
                    gameObject.SetActive(false);
                }
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
        //if (collision.gameObject.tag == "Enemy")
        //{
        //    Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        //}
    }

    private void PlayerShift()
    {

    }

    private void OpenInventoryOnce()
    {
        inventoryOpened = 1;
        if (InventoryManager.gameObject.activeSelf == false)
        {
            InventoryManager.gameObject.SetActive(true);
        }
        InventoryManager.gameObject.SetActive(false);
    }
}
