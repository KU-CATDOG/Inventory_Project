using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float health;
    public float maxHealth;
    public float attackDamage;
    public float attackSpeed;
    public float moveSpeed = 5f;
    public bool isInvincible = false;

    public Rigidbody2D rb;
    Vector2 movement;

    //포션 맵 변수
    Vector2 moveDir;
    bool isSlippery = false;

    //신발 맵 변수
    public List<GameObject> SpeedUp, SpeedDown;
    bool isOnSU = false;
    bool isOnSD = false;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health = 10;
        attackDamage = 10f;

        if (FindObjectOfType<SpeedUp>() != null)
        {
            for (int i = 0; i < FindObjectsOfType<SpeedUp>().Length; i++)
                SpeedUp.Add(FindObjectsOfType<SpeedUp>()[i].gameObject);
        }
        if (FindObjectOfType<SpeedDown>() != null)
        {
            for (int i = 0; i < FindObjectsOfType<SpeedDown>().Length; i++)
                SpeedDown.Add(FindObjectsOfType<SpeedDown>()[i].gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        moveDir = new Vector2(movement.x, movement.y);

        if (isOnSU)
            moveSpeed = 7f;
        else if (isOnSD)
            moveSpeed = 3f;
        else
            moveSpeed = 5f;
    }

    private void FixedUpdate()
    {
        if (isSlippery)
            rb.AddForce(moveDir, ForceMode2D.Force);
        else
            rb.velocity = moveDir * moveSpeed;  //이동을 담당하는 코드가 바뀜
            //rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (SpeedUp.Contains(collision.gameObject))
            isOnSU = true;
        if (SpeedDown.Contains(collision.gameObject))
            isOnSD = true;
        if (collision.CompareTag("Slippery"))
            isSlippery = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (SpeedUp.Contains(collision.gameObject))
            isOnSU = false;
        if (SpeedDown.Contains(collision.gameObject))
            isOnSD = false;
        if (collision.CompareTag("Slippery"))
            isSlippery = false;
    }
}
