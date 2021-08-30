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

    //Į
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

    //�Ź�
    public void PlayerSpeedUp()    //�ӵ� ����
    {
        player.GetComponent<Player>().additionalMS = 7f;
    }

    public void PlayerSpeedDown()  //�ӵ� ����
    {
        player.GetComponent<Player>().additionalMS = 3f;
    }

    public void PlayerSpeedNormal()  //�ӵ� ���� �� ���� ȿ�� ����
    {
        player.GetComponent<Player>().additionalMS = 5f;
    }

    //����
    public void PushBlock() //�����̴� �� �б�(�̼� ����)
    {
        player.GetComponent<Player>().additionalMS = 3f;
    }

    //ü�� ����
    public void Slippery() //�̲������� ȿ��
    {
        player.GetComponent<Rigidbody2D>().AddForce(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")), ForceMode2D.Force);
    }
}
