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

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health = 10;
        attackDamage = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
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
}
