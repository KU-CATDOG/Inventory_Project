using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordTrap : MonoBehaviour
{
    // Start is called before the first frame update
    IEnumerator swordSpike;
    public AllTraps trapMgr;
    void Start()
    {
        trapMgr = GameObject.Find("TrapMgr").GetComponent<AllTraps>();
        swordSpike = trapMgr.Sword(1f, 1f);
        StartCoroutine(swordSpike);

    }
    void Update()
    {
        

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
    // Update is called once per frame

    /*private Queue<IEnumerator> DecideNextRoutine()
    {
        Queue<IEnumerator> nextRoutines = new Queue<IEnumerator>();
    if (FindObjectOfType<Player>() != null)
    {
        nextRoutines.Enqueue(Sword(1f, 1f));
    }

        return nextRoutines;
    }*/



}
