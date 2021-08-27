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
        if ((trapMgr.player.transform.position - gameObject.transform.position).magnitude <= 1.3f)
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
