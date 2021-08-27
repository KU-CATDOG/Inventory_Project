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
        if((trapMgr.player.transform.position - gameObject.transform.position).magnitude <= 1.3f)
        {
            trapMgr.Slippery();
            //Debug.Log("on ice");
        }
    }
}
