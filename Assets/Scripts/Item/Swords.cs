using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swords : Items
{
    
    
    public SwordType Type;
    private int b;
    void Awake()
    {
        b = Random.Range(0, 4);
        switch (b)
        {
            case 0:
                damage = Random.Range(5, 11);
                Type = SwordType.������;
                break;

            case 1:
                damage = Random.Range(10, 17);
                Type = SwordType.����;
                break;

            case 2:
                damage = Random.Range(20, 41);
                Type = SwordType.����;
                break;

            case 3:
                damage = 50;
                Type = SwordType.����Ʈ���̹�;
                break;

        }

    }
    
}

public enum SwordType
{
    ����, ������, ����, ����, ����Ʈ���̹�
}