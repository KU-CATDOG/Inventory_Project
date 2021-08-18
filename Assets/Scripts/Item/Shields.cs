using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shields : MonoBehaviour
{
    public float shieldDamage;
    public float defense;
    public float moveSpeed;
    public float damage;
    public float tenacity;

    public ShieldType Type;
    private int b;
    void Start()
    {
        b = Random.Range(0, 4);
        switch (b)
        {
            case 0:
                shieldDamage = Random.Range(5, 9);
                Type = ShieldType.플라스틱_방패;
                break;

            case 1:
                shieldDamage = Random.Range(7, 12);
                Type = ShieldType.합금_방패;
                break;

            case 2:
                shieldDamage = Random.Range(10, 16);
                Type = ShieldType.탄소섬유_방패;
                break;

            case 3:
                shieldDamage = Random.Range(14, 21);
                Type = ShieldType.에너지_방패;
                break;

        }
        
    }
}

public enum ShieldType
{
    플라스틱_방패, 합금_방패, 탄소섬유_방패, 에너지_방패
}
