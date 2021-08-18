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
                Type = SwordType.파이프;
                break;

            case 1:
                damage = Random.Range(10, 17);
                Type = SwordType.도끼;
                break;

            case 2:
                damage = Random.Range(20, 41);
                Type = SwordType.빠루;
                break;

            case 3:
                damage = 50;
                Type = SwordType.라이트세이버;
                break;

        }

    }
    
}

public enum SwordType
{
    없음, 파이프, 도끼, 빠루, 라이트세이버
}