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
                Type = ShoeType.에어_요단;
                gameObject.name = "에어_요단";
                break;

            case 1:
                moveSpeed = Random.Range(1.2f, 1.3f);
                Type = ShoeType.스페이스부츠;
                gameObject.name = "스페이스부츠";
                break;

            case 2:
                moveSpeed = Random.Range(1.3f, 1.4f);
                Type = ShoeType.카본부츠;
                gameObject.name = "카본부츠";
                break;

            case 3:
                moveSpeed = 1.5f;
                Type = ShoeType.헤르메스의_신발;
                gameObject.name = "헤르메스의_신발";
                break;

        }

    }
}

public enum ShoeType
{
    없음, 에어_요단, 스페이스부츠, 카본부츠, 헤르메스의_신발
}
