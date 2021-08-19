using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoes : Items
{
   

    public ShoeType Type;
    private int b;
    void Awake()
    {
        b = Random.Range(0, 4);
        switch (b)
        {
            case 0:
                moveSpeed = Random.Range(1.1f, 1.2f);
                Type = ShoeType.����_���;
                gameObject.name = "����_���";
                break;

            case 1:
                moveSpeed = Random.Range(1.2f, 1.3f);
                Type = ShoeType.�����̽�����;
                gameObject.name = "�����̽�����";
                break;

            case 2:
                moveSpeed = Random.Range(1.3f, 1.4f);
                Type = ShoeType.ī������;
                gameObject.name = "ī������";
                break;

            case 3:
                moveSpeed = 1.5f;
                Type = ShoeType.�츣�޽���_�Ź�;
                gameObject.name = "�츣�޽���_�Ź�";
                break;

        }

    }
}

public enum ShoeType
{
    ����, ����_���, �����̽�����, ī������, �츣�޽���_�Ź�
}
