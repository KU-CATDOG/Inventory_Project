using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBlock : MonoBehaviour
{
    public AllTraps trapMgr;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Mathf.Abs(trapMgr.player.transform.position.x - gameObject.transform.position.x) < 0.5 && Mathf.Abs(trapMgr.player.transform.position.y - gameObject.transform.position.y) < 0.5)
        {
            trapMgr.Slippery();
            //Debug.Log("on ice");
        }
    }
}
