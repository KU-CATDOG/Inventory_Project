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
                Type = ShieldType.�ö�ƽ_����;
                break;

            case 1:
                shieldDamage = Random.Range(7, 12);
                Type = ShieldType.�ձ�_����;
                break;

            case 2:
                shieldDamage = Random.Range(10, 16);
                Type = ShieldType.ź�Ҽ���_����;
                break;

            case 3:
                shieldDamage = Random.Range(14, 21);
                Type = ShieldType.������_����;
                break;

        }
        
    }
}

public enum ShieldType
{
    �ö�ƽ_����, �ձ�_����, ź�Ҽ���_����, ������_����
}