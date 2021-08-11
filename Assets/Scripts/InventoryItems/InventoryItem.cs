using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class InventoryItem
{
    public Texture2D image;
    public int slotX;
    public int slotY;
    public int width;
    public int height;

    public abstract void PerformAction();
}
