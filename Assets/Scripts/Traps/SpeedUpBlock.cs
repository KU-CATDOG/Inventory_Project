using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpBlock : MonoBehaviour
{
    public float speedUpTime = 0f;
    float duration = 5f;
    public AllTraps trapMgr;
    public SpeedDownBlock speedDownBlock;
    // Start is called before the first frame update
    void Start()
    {
        trapMgr = GameObject.Find("TrapMgr").GetComponent<AllTraps>();
        GameObject temp = GameObject.Find("SlowFloor");
        if (temp != null) speedDownBlock = temp.GetComponent<SpeedDownBlock>();
    }

    // Update is called once per frame
    void Update()
    {
        //if((trapMgr.player.transform.position - gameObject.transform.position).magnitude <= 1.3f)
        //{
        //    speedUpTime = duration;
        //    speedDownBlock.speedDownTime = 0f;
        //}
        
        if (speedUpTime > 0)
        {
            trapMgr.PlayerSpeedUp();
            speedUpTime -= Time.deltaTime;
            //Debug.Log("boosted");
        }
        
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() != null)
        {
            speedUpTime = duration;
            if(speedDownBlock != null) speedDownBlock.speedDownTime = 0f;
        }
    }
}
