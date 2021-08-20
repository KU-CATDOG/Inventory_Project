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
                Type = ArmorType.¿¬±¸º¹;
                break;

            case 1:
                defense = Random.Range(5, 9);
                Type = ArmorType.¿ìÁÖº¹;
                break;

            case 2:
                defense = Random.Range(10, 16);
                Type = ArmorType.Ä«º»_½´Æ®;
                break;

            case 3:
                defense = Random.Range(16, 21);
                Type = ArmorType.¹æÅºÀ¯¸®_°©¿Ê;
                break;

        }

    }
}

public enum ArmorType
{
    ¿¬±¸º¹, ¿ìÁÖº¹, Ä«º»_½´Æ®, ¹æÅºÀ¯¸®_°©¿Ê
}
