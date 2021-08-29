using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBlock : MonoBehaviour
{
    public AllTraps trapMgr;
    
    public Sprite activatedSprite, coolDownSprite;
    private SpriteRenderer spriteRenderer;
    public bool onceInvincible;
    private float coolDown=30f;
    IEnumerator shieldDeploy;
    // Start is called before the first frame update
    void Start()
    {
        trapMgr = GameObject.Find("TrapMgr").GetComponent<AllTraps>();
        onceInvincible = trapMgr.player.GetComponent<Player>().onceBlockDamage;
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = activatedSprite;
        shieldDeploy = Shield(coolDown);
        StartCoroutine(shieldDeploy);

    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator Shield(float coolDown)
    {
        while (FindObjectOfType<Player>() != null)
        {
            Debug.Log((trapMgr.player.transform.position - gameObject.transform.position).magnitude);

            if ((trapMgr.player.transform.position - gameObject.transform.position).magnitude <= 1.3f && onceInvincible == false)
            {
                onceInvincible = true;
                trapMgr.player.GetComponent<Player>().onceBlockDamage = true;
                spriteRenderer.sprite = coolDownSprite;
                yield return new WaitForSeconds(coolDown);
                spriteRenderer.sprite = activatedSprite;
                //Debug.Log("on trap");
            }
            else
            {
                yield return null;
            }

        }
    }
}