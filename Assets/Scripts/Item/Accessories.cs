using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accessories : Items
{
    

    public AccessoryType Type;
    private int b;
    void Awake()
    {
        b = Random.Range(0, 4);
        switch (b)
        {
            case 0:
                tenacity = Random.Range(1, 3);
                Type = AccessoryType.�����;
                break;

            case 1:
                tenacity = Random.Range(3, 5);
                Type = AccessoryType.���翭_���ܱ�;
                break;

            case 2:
                tenacity = Random.Range(5, 7);
                Type = AccessoryType.���ξ��ÿ�ġ;
                break;

            case 3:
                tenacity = 7;
                Type = AccessoryType.�������;
                break;

        }

    }
}

public enum AccessoryType
{
    ����, �����, ���翭_���ܱ�, ���ξ��ÿ�ġ, �������
}
        
   