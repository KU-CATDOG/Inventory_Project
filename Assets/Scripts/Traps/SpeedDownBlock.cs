using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedDownBlock : MonoBehaviour
{
    public float speedDownTime = 0f;
    float duration = 5f;
    public AllTraps trapMgr;
    public SpeedUpBlock speedUpBlock;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(trapMgr.player.transform.position.x - gameObject.transform.position.x) < 0.5 && Mathf.Abs(trapMgr.player.transform.position.y - gameObject.transform.position.y) < 0.5)
        {
            speedDownTime = duration;
            speedUpBlock.speedUpTime = 0f;
        }

        if (speedDownTime > 0)
        {
            trapMgr.PlayerSpeedDown();
            speedDownTime -= Time.deltaTime;
            //Debug.Log("boosted");
        }
        else if(speedUpBlock.speedUpTime <= 0)
        {
            trapMgr.PlayerSpeedNormal();
            //Debug.Log("normal");
        }

    }
}
