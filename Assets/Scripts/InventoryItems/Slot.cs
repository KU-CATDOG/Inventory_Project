using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot
{

    public InventoryItem item;
    public bool occupied;
    public Rect position;



    public Slot(Rect position)
    {
        this.position = position;
    }

    public void Draw(float frameX, float frameY)
    {
        if (item != null)
        {
            GUI.DrawTexture(new Rect(frameX + position.x, frameY + position.y, position.width, position.height), item.image);
        }
        
    }
}
