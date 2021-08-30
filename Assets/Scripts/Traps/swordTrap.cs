using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordTrap : MonoBehaviour
{
    // Start is called before the first frame update
    IEnumerator swordSpike;
    public AllTraps trapMgr;
    public Sprite idleSprite, attackSprite;
    void Start()
    {
        swordSpike = SwordSpike(1f, 1f);
        StartCoroutine(swordSpike);

    }
    void Update()
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
    private IEnumerator SwordSpike(float attackDelay, float idleDelay)
    {
        while (FindObjectOfType<Player>() != null)
        {
            yield return new WaitForSeconds(attackDelay);
            SwordUp();
            if ((trapMgr.player.transform.position - gameObject.transform.position).magnitude <= 1.3f)
            {
                trapMgr.player.GetComponent<Player>().GetDamaged(5f);
                //Debug.Log("on trap");
            }

            yield return new WaitForSeconds(idleDelay);
            SwordDown();
        }

    }
    private void SwordUp()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = attackSprite;
    }

    private void SwordDown()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = idleSprite;
    }
}
