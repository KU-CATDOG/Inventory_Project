using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItems : MonoBehaviour
{
    public List<Armor> armorInspector;
    private static List<Armor> armor;

    private void Start()
    {
        armor = armorInspector;
    }
    public static Armor GetArmor(int id)
    {
        Armor armor = new Armor();
        armor.image = InventoryItems.armor[id].image;
        armor.width = InventoryItems.armor[id].width;
        armor.height = InventoryItems.armor[id].height;
        return armor;
    }
}
