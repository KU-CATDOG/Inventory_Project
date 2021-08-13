using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory : MonoBehaviour
{
    public Texture2D image;
    public Rect position;

    public List<InventoryItem> items = new List<InventoryItem>();
    int slotWidth = 4;
    int slotHeight = 9;
    public Slot[,] slots;

    public int slotLeftTopX;
    public int slotLeftTopY;
    public int width = 128;
    public int height = 49;
    public int gapX = 7;
    public int gapY = 6;

    private InventoryItem temp;
    private Vector2 selected;
    private Vector2 secondSelected;
    private bool test;

    // Start is called before the first frame update
    void Start()
    {
        SetSlots();
        test = false;
    }

    void TestMethod()
    {
        AddItem(0, 0, InventoryItems.GetArmor(0));
        test = true;
    }

    void SetSlots()
    {
        slots = new Slot[slotWidth, slotHeight];

        for (int i = 0; i < slotWidth; i++)
        {
            for (int j = 0; j < slotHeight; j++)
            {
                slots[i, j] = new Slot(new Rect(slotLeftTopX + (width + gapX) * i, slotLeftTopY + (height + gapY) * j, width, height));

            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (!test)
        {
            TestMethod();
        }
    }

    private void OnGUI()
    {
        DrawInventory();
        DrawSlots();
        DrawItems();
        DetectMouseAction();
        DrawTempItem();
    }

    void DrawInventory()
    {
        position.x = (Screen.width - position.width) / 2;
        position.y = (Screen.height - position.height) / 2;
        GUI.DrawTexture(position, image);
    }

    void DrawSlots()
    {
        for (int i = 0; i < slotWidth; i++)
        {
            for (int j = 0; j < slotHeight; j++)
            {
                slots[i, j].Draw(position.x, position.y);
            }
        }

    }

    void DrawItems()
    {
        for (int count = 0; count < items.Count; count++)
        {
            GUI.DrawTexture(new Rect(slotLeftTopX + position.x + items[count].slotX * width + gapX * (items[count].slotX - 1), slotLeftTopY + position.y + items[count].slotY * height + gapY * (items[count].slotY - 1), 
                items[count].width * width + gapX * (items[count].width - 1), items[count].height * height+ gapY * (items[count].height - 1)), items[count].image);
        }
    }
    
    bool AddItem(int x, int y, InventoryItem item)
    {
        for (int i = 0; i < item.width; i++)
        {
            for (int j = 0; j < item.height; j++)
            {
                if (slots[x, y].occupied)
                {
                    Debug.Log("Break" + x + "," + y);
                    return false;
                }
                if ((x + i) < slotWidth && (y + j) < slotHeight && slots[(x + i), (y + j)].occupied)
                {
                    return false;
                }
            }
        }
        if (x + item.width > slotWidth)
        {
            Debug.Log("X out of bounds");
            return false;
        }
        if (y + item.height > slotHeight)
        {
            Debug.Log("Y out of bounds");
            return false;
        }
        Debug.Log("Item Added");
        item.slotX = x;
        item.slotY = y;
        items.Add(item);
        for (int i = x; i < item.width + x; i++)
        {
            for (int j = y; j < item.height + y; j++)
            {

                slots[i, j].occupied = true;

            }
        }
        return true;
    }

    void DetectMouseAction()
    {
        for (int i = 0; i < slotWidth; i++)
        {
            for (int j = 0; j < slotHeight; j++)
            {
                Rect slot = new Rect(position.x + slots[i,j].position.x, position.y + slots[i, j].position.y, width, height);
                if (slot.Contains(new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y)))
                {
                    if (Event.current.isMouse && Input.GetMouseButtonDown(0))
                    {
                        selected.x = i;
                        selected.y = j;
                        for (int index = 0; index < items.Count; index++)
                        {
                            for (int countX = items[index].slotX; countX < items[index].slotX + items[index].width; countX++)
                            {
                                for (int countY = items[index].slotY; countY < items[index].slotY + items[index].height; countY++)
                                {
                                    if (countX == i && countY == j)
                                    {
                                        temp = items[index];
                                        RemoveItem(temp);
                                        return;
                                    }
                                }
                            }
                        }
                    }
                    if (Event.current.isMouse && Input.GetMouseButtonUp(0))
                    {
                        secondSelected.x = i;
                        secondSelected.y = j;
                        if (secondSelected.x != selected.x || secondSelected.y != selected.y)
                        {
                            if (temp != null)
                            {
                                if (!AddItem((int)secondSelected.x, (int)secondSelected.y, temp))
                                {
                                    AddItem(temp.slotX, temp.slotY, temp);
                                }
                                temp = null;
                            }

                        }
                        else
                        {
                            if (temp != null)
                            {
                                AddItem(temp.slotX, temp.slotY, temp);
                                temp = null;
                            }
                            
                        }
                    }
                    Debug.Log(selected + "             " + secondSelected);
                    Debug.Log(i + "," + j);
                    return;
                }
                
            }
        }
    }

    void RemoveItem(InventoryItem item)
    {
        for (int i = item.slotX; i < item.slotX + item.width; i++)
        {
            for (int j = item.slotY; j < item.slotY + item.height; j++)
            {
                slots[i, j].occupied = false;
            }
        }
        items.Remove(item);
    }

    void DrawTempItem()
    {
        if (temp != null)
        {
            GUI.DrawTexture(new Rect(Input.mousePosition.x, Screen.height - Input.mousePosition.y, temp.width * width, temp.height * height), temp.image);
        }
    }
}
