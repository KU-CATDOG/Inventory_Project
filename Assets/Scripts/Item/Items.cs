using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Items : MonoBehaviour
{
    public ItemType item;

    public float shieldDamage;
    public float defense;
    public float moveSpeed;
    public float damage;
    public float tenacity;
}

public enum ItemType
{
    None, Shield, Armor, Boots, Sword, Accessories
}
