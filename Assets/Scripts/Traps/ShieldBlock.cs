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


            if (Mathf.Abs(trapMgr.player.transform.position.x - gameObject.transform.position.x) < 0.5 && Mathf.Abs(trapMgr.player.transform.position.y - gameObject.transform.position.y) < 0.5 && onceInvincible == false)
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