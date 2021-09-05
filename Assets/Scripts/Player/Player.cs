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

    public int direction;

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

    public Items[] Inventory;
    public GameObject inv;
    private int tempInt;

    public testInvCon invCon;

    public GameObject InventoryManager;
    private int inventoryOpened;

    float moveSoundTime = 0;

    private Animator anim;

    private Vector3 oldPos, newPos;
    public PlayerDirection playerDirection;

    public GameObject hitEffect;

    public int curItemCount;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        attackDamage = 10f;
        moveSpeed = 5f;
        maxHealth = health = 100;
        additionalDMG = attackDamage;
        additionalMS = moveSpeed;

        //for (int i = 0; i < Inventory.Count; i++)
        //{
        //    shieldDmg += Inventory[i].shieldDamage;
        //    defense += Inventory[i].defense;
        //    additionalMS += Inventory[i].moveSpeed;
        //    additionalDMG += Inventory[i].damage;
        //    tenacity += Inventory[i].tenacity;
        //}

        inv = GameObject.Find("ItemTemplates");
        Inventory = inv.GetComponentsInChildren<Items>();
        curItemCount = Inventory.Length;



        oldPos = gameObject.transform.position;
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
        if (cursorAngle > -45 && cursorAngle <= 45) // right
        {
            direction = 1;
        }
        else if (cursorAngle > 45 && cursorAngle <= 135) // up
        {
            direction = 2;
        }
        else if (cursorAngle > -135 && cursorAngle <= -45) // down
        {
            direction = 4;
        }
        else
        {
            direction = 3; // left
        }
        Debug.Log(rb.velocity);
        //Debug.Log(direction);
        //Debug.Log(cursorAngle);
        //attackPoint.localScale = new Vector3(1, isCursorRight ? 1 : -1, 1);
        attackPoint.rotation = Quaternion.Euler(0, 0, cursorAngle);

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement = movement.normalized;

        #region animation
        if (direction == 1)
        {
            anim.SetInteger("Direction", 1);
            GetComponent<SpriteRenderer>().flipX = true;
            Debug.Log("Set");
        }
        if (direction == 2)
        {
            anim.SetInteger("Direction", 2);

        }
        if (direction == 3)
        {
            anim.SetInteger("Direction", 3);
            GetComponent<SpriteRenderer>().flipX = false;
        }
        if (direction == 4)
        {
            anim.SetInteger("Direction", 4);

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

        Inventory = inv.GetComponentsInChildren<Items>();
        int invCount = Inventory.Length;

        if (tempInt == 0)
        {
            for (int i = 0; i < Inventory.Length; i++)
            {
                shieldDmg += Inventory[i].shieldDamage;
                defense += Inventory[i].defense;
                additionalMS += Inventory[i].moveSpeed;
                additionalDMG += Inventory[i].damage;
                tenacity += Inventory[i].tenacity;
            }
            tempInt++;
            curItemCount = Inventory.Length;
        }
        else
        {
            if (invCount != curItemCount)
            {
                addItem();
                curItemCount = invCount;
            }
        }
    }


    public void addItem()
    {
        Inventory = inv.GetComponentsInChildren<Items>();
        float tshieldDmg = Inventory[Inventory.Length - 1].shieldDamage;
        float tdefense = Inventory[Inventory.Length - 1].defense;
        float tadditionalMS = Inventory[Inventory.Length - 1].moveSpeed + 5f;
        float tadditionalDMG = Inventory[Inventory.Length - 1].damage + 10f;
        float ttenacity = Inventory[Inventory.Length - 1].tenacity;

        if (tshieldDmg > shieldDmg) shieldDmg = tshieldDmg;
        if (tdefense > defense) defense = tdefense;
        if (tadditionalMS > additionalMS) additionalMS = tadditionalMS;
        if (tadditionalDMG > additionalDMG) additionalDMG = tadditionalDMG;
        if (ttenacity > tenacity) tenacity = ttenacity;

    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * additionalMS * Time.fixedDeltaTime);
        if (movement.x != 0 || movement.y != 0)
        {
            anim.SetTrigger("Walking");
        }
        playerDirection = MoveDirDetection();
        Debug.Log(playerDirection);
    }

    private void Attack()
    {
        anim.SetTrigger("Attack");
        if (Time.timeScale == 1)
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
                //««∞› ¿Ã∆Â∆Æ
                GameObject clone = Instantiate(hitEffect, transform);
                Destroy(clone, 1f);
                health -= damage;
                float Damage = damage - defense;
                if (Damage < 0) health -= 0;
                else health -= Damage;
                StartCoroutine(DamagedRoutine());
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

    }

    private IEnumerator DamagedRoutine()
    {
        isInvincible = true;

        SpriteRenderer[] spriteRenderers = GetComponentsInChildren<SpriteRenderer>();

        float startTime = Time.time;
        while (Time.time - startTime < 1)
        {
            foreach (SpriteRenderer child in spriteRenderers)
            {
                child.color = new Color(1, 1, 1, 0);
            }
            yield return new WaitForSeconds(0.1f);

            foreach (SpriteRenderer child in spriteRenderers)
            {
                child.color = new Color(1, 1, 1, 1);
            }
            yield return new WaitForSeconds(0.1f);
        }

        foreach (SpriteRenderer child in spriteRenderers)
        {
            child.color = new Color(1, 1, 1, 1);
        }
        isInvincible = false;
    }

    private PlayerDirection MoveDirDetection()
    {
        newPos = gameObject.transform.position;
        float xDiff = newPos.x - oldPos.x;
        float yDiff = newPos.y - oldPos.y;
        oldPos = newPos;
        if (Mathf.Abs(xDiff) > Mathf.Abs(yDiff))                    //if x difference is greater than that of y
        {
            if (xDiff > 0)
            {
                return PlayerDirection.right;
            }
            else
            {
                return PlayerDirection.left;
            }
        }
        else if (Mathf.Abs(xDiff) < Mathf.Abs(yDiff))
        {
            if (yDiff > 0)
            {
                return PlayerDirection.up;
            }
            else
            {
                return PlayerDirection.down;
            }
        }
        else if (xDiff != 0)
        {
            if (xDiff > 0)
            {
                if (yDiff > 0)
                {
                    return PlayerDirection.rightUp;
                }
                else
                {
                    return PlayerDirection.rightDown;
                }
            }
            else
            {
                if (yDiff > 0)
                {
                    return PlayerDirection.leftUp;
                }
                else
                {
                    return PlayerDirection.leftDown;
                }
            }
        }
        else
        {
            return PlayerDirection.still;
        }

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

    public enum PlayerDirection { left, right, up, down, still, leftUp, leftDown, rightUp, rightDown };
}
