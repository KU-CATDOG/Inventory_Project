using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllTraps : MonoBehaviour
{
    public GameObject player;
    public GameObject pushingBlock, swordBlock;
    
    // Start is called before the first frame update
    void Start()
    {
        //player = FindObjectOfType<Player>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
            Slippery();
    }

    //칼
    /*public void SwordUp()
    {
        swordBlock.GetComponent<SpriteRenderer>().sprite = attackSprite;
    }

    public void SwordDown()
    {
        swordBlock.GetComponent<SpriteRenderer>().sprite = idleSprite;
    }

    public IEnumerator Sword(float attackDelay, float idleDelay)
    {
        while (FindObjectOfType<Player>() != null)
        {
            yield return new WaitForSeconds(attackDelay);
            SwordUp();
            if ((player.transform.position - swordBlock.transform.position).magnitude <= 1.3f)
            {
                player.GetComponent<Player>().GetDamaged(5f);
                //Debug.Log("on trap");
            }

            yield return new WaitForSeconds(idleDelay);
            SwordDown();
        }
            
    }*/

    //신발
    public void PlayerSpeedUp()    //속도 증가
    {
        player.GetComponent<Player>().additionalMS = 7f;
    }

    public void PlayerSpeedDown()  //속도 감소
    {
        player.GetComponent<Player>().additionalMS = 3f;
    }

    public void PlayerSpeedNormal()  //속도 증가 및 감소 효과 해제
    {
        player.GetComponent<Player>().additionalMS = 5f;
    }

    //방패
    public void PushBlock() //움직이는 벽 밀기(이속 감소)
    {
        player.GetComponent<Player>().additionalMS = 3f;
    }

    //체력 포션
    public void Slippery() //미끄러지는 효과
    {
        player.GetComponent<Rigidbody2D>().AddForce(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")), ForceMode2D.Force);
    }
}
