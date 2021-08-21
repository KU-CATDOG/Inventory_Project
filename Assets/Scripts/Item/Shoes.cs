using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoes : MonoBehaviour
{
    public float shieldDamage;
    public float defense;
    public float moveSpeed;
    public float damage;
    public float tenacity;

    public ShoeType Type;
    private int b;
    void Start()
    {
        b = Random.Range(0, 4);
        switch (b)
        {
            case 0:
                moveSpeed = Random.Range(1.1f, 1.2f);
                Type = ShoeType.����_���;
                break;

            case 1:
                moveSpeed = Random.Range(1.2f, 1.3f);
                Type = ShoeType.�����̽�����;
                break;

            case 2:
                moveSpeed = Random.Range(1.3f, 1.4f);
                Type = ShoeType.ī������;
                break;

            case 3:
                moveSpeed = 1.5f;
                Type = ShoeType.�츣�޽���_�Ź�;
                break;

        }

    }
}

public enum ShoeType
{
    ����_���, �����̽�����, ī������, �츣�޽���_�Ź�
}