using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accessories : MonoBehaviour
{
    public float shieldDamage;
    public float defense;
    public float moveSpeed;
    public float damage;
    public float tenacity;

    public AccessoryType Type;
    private int b;
    void Start()
    {
        b = Random.Range(0, 4);
        switch (b)
        {
            case 0:
                tenacity = Random.Range(1, 3);
                Type = AccessoryType.산소통;
                break;

            case 1:
                tenacity = Random.Range(3, 5);
                Type = AccessoryType.복사열_차단기;
                break;

            case 2:
                tenacity = Random.Range(5, 7);
                Type = AccessoryType.파인애플워치;
                break;

            case 3:
                tenacity = 7;
                Type = AccessoryType.절대반지;
                break;

        }

    }
}

public enum AccessoryType
{
    산소통, 복사열_차단기, 파인애플워치, 절대반지
}
        
   