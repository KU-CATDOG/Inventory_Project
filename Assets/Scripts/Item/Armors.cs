using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armors : MonoBehaviour
{
    public float shieldDamage;
    public float defense;
    public float moveSpeed;
    public float damage;
    public float tenacity;

    public ArmorType Type;
    private int b;
    void Start()
    {
        b = Random.Range(0, 4);
        switch (b)
        {
            case 0:
                defense = Random.Range(2, 6);
                Type = ArmorType.������;
                break;

            case 1:
                defense = Random.Range(5, 9);
                Type = ArmorType.���ֺ�;
                break;

            case 2:
                defense = Random.Range(10, 16);
                Type = ArmorType.ī��_��Ʈ;
                break;

            case 3:
                defense = Random.Range(16, 21);
                Type = ArmorType.��ź����_����;
                break;

        }

    }
}

public enum ArmorType
{
    ������, ���ֺ�, ī��_��Ʈ, ��ź����_����
}
