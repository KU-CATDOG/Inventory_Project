#pragma warning disable IDE0090 // 'new(...)' »ç¿ë
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class Drag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private Vector3 initPos;
    private string objTag;
    public int armorRan, shieldRan, shoeRan, swordRan, ringRan;
    //private InventoryControl invCon;
    private testInvCon invCon;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        invCon = GameObject.Find("InventoryManager").GetComponent<testInvCon>();
        //invCon= GameObject.Find("InventoryControl").GetComponent<InventoryControl>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        initPos = rectTransform.anchoredPosition;
        objTag = gameObject.transform.tag;
        if (objTag == "Armor")
        {
            armorRan = invCon.armorRan;
            setArmorRan(false);
        }
        else if (objTag == "Sword")
        {
            swordRan = invCon.swordRan;
            setSwordRan(false);
        }
        else if (objTag == "Shield")
        {
            shieldRan = invCon.shieldRan;
            setShieldRan(false);
        }
        else if (objTag == "Shoe")
        {
            shoeRan = invCon.shoeRan;
            setShoeRan(false);
        }
        else if (objTag == "Ring")
        {
            ringRan = invCon.ringRan;
            setRingRan(false);
        }
        else
        {
            Debug.Log("Selected object is not draggable");
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f);
        rectTransform.position = mousePos;
        //Debug.Log(rectTransform.position);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (Input.mousePosition.x < 545 || Input.mousePosition.x > 1375 || Input.mousePosition.y < 162.5 || Input.mousePosition.y > 917.5)
        {
            rectTransform.anchoredPosition = initPos;
            if (objTag == "Armor")
            {
                setArmorRan(true);
            }
            else if (objTag == "Sword")
            {
                setSwordRan(true);
            }
            else if (objTag == "Shield")
            {
                setShieldRan(true);
            }
            else if (objTag == "Shoe")
            {
                setShoeRan(true);
            }
            else
            {
                setRingRan(true);
            }
        }
        else
        {
            if (objTag == "Armor")
            {
                ChkArmor(invCon);
            }
            else if (objTag == "Sword")
            {
                ChkSword(invCon);
            }
            else if (objTag == "Shield")
            {
                ChkShield(invCon);
            }
            else if (objTag == "Shoe")
            {
                ChkShoe(invCon);
            }
            else
            {
                ChkRing(invCon);
            }
        }
    }

    private void ChkArmor(testInvCon invCon)
    {
        if (Input.mousePosition.x < invCon.armorPointerList[0].x)
        {
            for (int i = 0; i < 7; i++)
            {
                if (Input.mousePosition.y < invCon.armorPointerList[i].y)
                {
                    if (!invCon.occupiedRect[i] && !invCon.occupiedRect[i + 1] && !invCon.occupiedRect[i + 9] && !invCon.occupiedRect[i + 10])
                    {
                        rectTransform.anchoredPosition = invCon.armorPosList[i];
                        invCon.occupiedRect[i] = true;
                        invCon.occupiedRect[i + 1] = true;
                        invCon.occupiedRect[i + 9] = true;
                        invCon.occupiedRect[i + 10] = true;
                        invCon.armorRan = i;
                        return;
                    }
                    else
                    {
                        rectTransform.anchoredPosition = initPos;
                        setArmorRan(true);
                        return;
                    }
                }
            }
            if (!invCon.occupiedRect[7] && !invCon.occupiedRect[7 + 1] && !invCon.occupiedRect[7 + 9] && !invCon.occupiedRect[7 + 10])
            {
                rectTransform.anchoredPosition = invCon.armorPosList[7];
                invCon.occupiedRect[7] = true;
                invCon.occupiedRect[7 + 1] = true;
                invCon.occupiedRect[7 + 9] = true;
                invCon.occupiedRect[7 + 10] = true;
                invCon.armorRan = 7;
                return;
            }
            else
            {
                rectTransform.anchoredPosition = initPos;
                setArmorRan(true);
                return;
            }
        }
        else if (Input.mousePosition.x < invCon.armorPointerList[8].x)
        {
            for (int i = 0; i < 7; i++)
            {
                if (Input.mousePosition.y < invCon.armorPointerList[i].y)
                {
                    if (!invCon.occupiedRect[i + 8 + 1] && !invCon.occupiedRect[i + 8 + 2] && !invCon.occupiedRect[i + 8 + 10] && !invCon.occupiedRect[i + 8 + 11])
                    {
                        rectTransform.anchoredPosition = invCon.armorPosList[i + 8];
                        invCon.occupiedRect[i + 8 + 1] = true;
                        invCon.occupiedRect[i + 8 + 2] = true;
                        invCon.occupiedRect[i + 8 + 10] = true;
                        invCon.occupiedRect[i + 8 + 11] = true;
                        invCon.armorRan = i + 8;
                        return;
                    }
                    else
                    {
                        rectTransform.anchoredPosition = initPos;
                        setArmorRan(true);
                        return;
                    }
                }
            }
            if (!invCon.occupiedRect[7 + 8 + 1] && !invCon.occupiedRect[7 + 8 + 2] && !invCon.occupiedRect[7 + 8 + 10] && !invCon.occupiedRect[7 + 8 + 11])
            {
                rectTransform.anchoredPosition = invCon.armorPosList[7 + 8];
                invCon.occupiedRect[7 + 8 + 1] = true;
                invCon.occupiedRect[7 + 8 + 2] = true;
                invCon.occupiedRect[7 + 8 + 10] = true;
                invCon.occupiedRect[7 + 8 + 11] = true;
                invCon.armorRan = 7 + 8;
                return;
            }
            else
            {
                rectTransform.anchoredPosition = initPos;
                setArmorRan(true);
                return;
            }
        }
        else
        {
            for (int i = 0; i < 7; i++)
            {
                if (Input.mousePosition.y < invCon.armorPointerList[i].y)
                {
                    if (!invCon.occupiedRect[i + 16 + 2] && !invCon.occupiedRect[i + 16 + 3] && !invCon.occupiedRect[i + 16 + 11] && !invCon.occupiedRect[i + 16 + 12])
                    {
                        rectTransform.anchoredPosition = invCon.armorPosList[i + 16];
                        invCon.occupiedRect[i + 16 + 2] = true;
                        invCon.occupiedRect[i + 16 + 3] = true;
                        invCon.occupiedRect[i + 16 + 11] = true;
                        invCon.occupiedRect[i + 16 + 12] = true;
                        invCon.armorRan = i + 16;
                        return;
                    }
                    else
                    {
                        rectTransform.anchoredPosition = initPos;
                        setArmorRan(true);
                        return;
                    }
                }
            }
            if (!invCon.occupiedRect[7 + 16 + 2] && !invCon.occupiedRect[7 + 16 + 3] && !invCon.occupiedRect[7 + 16 + 11] && !invCon.occupiedRect[7 + 16 + 12])
            {
                rectTransform.anchoredPosition = invCon.armorPosList[7 + 16];
                invCon.occupiedRect[7 + 16 + 2] = true;
                invCon.occupiedRect[7 + 16 + 3] = true;
                invCon.occupiedRect[7 + 16 + 11] = true;
                invCon.occupiedRect[7 + 16 + 12] = true;
                invCon.armorRan = 7 + 16;
                return;
            }
            else
            {
                rectTransform.anchoredPosition = initPos;
                setArmorRan(true);
                return;
            }
        }
    }
    private void ChkSword(testInvCon invCon)
    {
        if (Input.mousePosition.x < invCon.swordPointerList[0].x)
        {
            for (int i = 0; i < 6; i++)
            {
                if (Input.mousePosition.y < invCon.swordPointerList[i].y)
                {
                    if (!invCon.occupiedRect[i] && !invCon.occupiedRect[i + 1] && !invCon.occupiedRect[i + 2])
                    {
                        rectTransform.anchoredPosition = invCon.swordPosList[i];
                        invCon.occupiedRect[i] = true;
                        invCon.occupiedRect[i + 1] = true;
                        invCon.occupiedRect[i + 2] = true;
                        invCon.swordRan = i;
                        return;
                    }
                    else
                    {
                        rectTransform.anchoredPosition = initPos;
                        setSwordRan(true);
                        return;
                    }
                }
            }
            if (!invCon.occupiedRect[6] && !invCon.occupiedRect[6 + 1] && !invCon.occupiedRect[6 + 2])
            {
                rectTransform.anchoredPosition = invCon.swordPosList[6];
                invCon.occupiedRect[6] = true;
                invCon.occupiedRect[6 + 1] = true;
                invCon.occupiedRect[6 + 2] = true;
                invCon.swordRan = 6;
                return;
            }
            else
            {
                rectTransform.anchoredPosition = initPos;
                setSwordRan(true);
                return;
            }
        }
        else if (Input.mousePosition.x < invCon.swordPointerList[7].x)
        {
            for (int i = 0; i < 6; i++)
            {
                if (Input.mousePosition.y < invCon.swordPointerList[i].y)
                {
                    if (!invCon.occupiedRect[i + 7 + 2] && !invCon.occupiedRect[i + 7 + 3] && !invCon.occupiedRect[i + 7 + 4])
                    {
                        rectTransform.anchoredPosition = invCon.swordPosList[i + 7];
                        invCon.occupiedRect[i + 7 + 2] = true;
                        invCon.occupiedRect[i + 7 + 3] = true;
                        invCon.occupiedRect[i + 7 + 4] = true;
                        invCon.swordRan = i + 7;
                        return;
                    }
                    else
                    {
                        rectTransform.anchoredPosition = initPos;
                        setSwordRan(true);
                        return;
                    }
                }
            }
            if (!invCon.occupiedRect[6 + 7 + 2] && !invCon.occupiedRect[6 + 7 + 3] && !invCon.occupiedRect[6 + 7 + 4])
            {
                rectTransform.anchoredPosition = invCon.swordPosList[6 + 7];
                invCon.occupiedRect[6 + 7 + 2] = true;
                invCon.occupiedRect[6 + 7 + 3] = true;
                invCon.occupiedRect[6 + 7 + 4] = true;
                invCon.swordRan = 6 + 7;
                return;
            }
            else
            {
                rectTransform.anchoredPosition = initPos;
                setSwordRan(true);
                return;
            }
        }
        else if (Input.mousePosition.x < invCon.swordPointerList[14].x)
        {
            for (int i = 0; i < 6; i++)
            {
                if (Input.mousePosition.y < invCon.swordPointerList[i].y)
                {
                    if (!invCon.occupiedRect[i + 14 + 4] && !invCon.occupiedRect[i + 14 + 5] && !invCon.occupiedRect[i + 14 + 6])
                    {
                        rectTransform.anchoredPosition = invCon.swordPosList[i + 14];
                        invCon.occupiedRect[i + 14 + 4] = true;
                        invCon.occupiedRect[i + 14 + 5] = true;
                        invCon.occupiedRect[i + 14 + 6] = true;
                        invCon.swordRan = i + 14;
                        return;
                    }
                    else
                    {
                        rectTransform.anchoredPosition = initPos;
                        setSwordRan(true);
                        return;
                    }
                }
            }
            if (!invCon.occupiedRect[6 + 14 + 4] && !invCon.occupiedRect[6 + 14 + 5] && !invCon.occupiedRect[6 + 14 + 6])
            {
                rectTransform.anchoredPosition = invCon.swordPosList[6 + 14];
                invCon.occupiedRect[6 + 14 + 4] = true;
                invCon.occupiedRect[6 + 14 + 5] = true;
                invCon.occupiedRect[6 + 14 + 6] = true;
                invCon.swordRan = 6 + 14;
                return;
            }
            else
            {
                rectTransform.anchoredPosition = initPos;
                setSwordRan(true);
                return;
            }
        }
        else
        {
            for (int i = 0; i < 6; i++)
            {
                if (Input.mousePosition.y < invCon.swordPointerList[i].y)
                {
                    if (!invCon.occupiedRect[i + 21 + 6] && !invCon.occupiedRect[i + 21 + 7] && !invCon.occupiedRect[i + 21 + 8])
                    {
                        rectTransform.anchoredPosition = invCon.swordPosList[i + 21];
                        invCon.occupiedRect[i + 21 + 6] = true;
                        invCon.occupiedRect[i + 21 + 7] = true;
                        invCon.occupiedRect[i + 21 + 8] = true;
                        invCon.swordRan = i + 21;
                        return;
                    }
                    else
                    {
                        rectTransform.anchoredPosition = initPos;
                        setSwordRan(true);
                        return;
                    }
                }
            }
            if (!invCon.occupiedRect[6 + 21 + 6] && !invCon.occupiedRect[6 + 21 + 7] && !invCon.occupiedRect[6 + 21 + 8])
            {
                rectTransform.anchoredPosition = invCon.swordPosList[6 + 21];
                invCon.occupiedRect[6 + 21 + 6] = true;
                invCon.occupiedRect[6 + 21 + 7] = true;
                invCon.occupiedRect[6 + 21 + 8] = true;
                invCon.swordRan = 6 + 21;
                return;
            }
            else
            {
                rectTransform.anchoredPosition = initPos;
                setSwordRan(true);
                return;
            }
        }
    }
    private void ChkShield(testInvCon invCon)
    {
        if (Input.mousePosition.x < invCon.shieldPointerList[0].x)
        {
            for (int i = 0; i < 7; i++)
            {
                if (Input.mousePosition.y < invCon.shieldPointerList[i].y)
                {
                    if (!invCon.occupiedRect[i] && !invCon.occupiedRect[i + 1])
                    {
                        rectTransform.anchoredPosition = invCon.shieldPosList[i];
                        invCon.occupiedRect[i] = true;
                        invCon.occupiedRect[i + 1] = true;
                        invCon.shieldRan = i;
                        return;
                    }
                    else
                    {
                        rectTransform.anchoredPosition = initPos;
                        setShieldRan(true);
                        return;
                    }
                }
            }
            if (!invCon.occupiedRect[7] && !invCon.occupiedRect[7 + 1])
            {
                rectTransform.anchoredPosition = invCon.shieldPosList[7];
                invCon.occupiedRect[7] = true;
                invCon.occupiedRect[7 + 1] = true;
                invCon.shieldRan = 7;
                return;
            }
            else
            {
                rectTransform.anchoredPosition = initPos;
                setShieldRan(true);
                return;
            }
        }
        else if (Input.mousePosition.x < invCon.shieldPointerList[8].x)
        {
            for (int i = 0; i < 7; i++)
            {
                if (Input.mousePosition.y < invCon.shieldPointerList[i].y)
                {
                    if (!invCon.occupiedRect[i + 8 + 1] && !invCon.occupiedRect[i + 8 + 2])
                    {
                        rectTransform.anchoredPosition = invCon.shieldPosList[i + 8];
                        invCon.occupiedRect[i + 8 + 1] = true;
                        invCon.occupiedRect[i + 8 + 2] = true;
                        invCon.shieldRan = i + 8;
                        return;
                    }
                    else
                    {
                        rectTransform.anchoredPosition = initPos;
                        setShieldRan(true);
                        return;
                    }
                }
            }
            if (!invCon.occupiedRect[7 + 8 + 1] && !invCon.occupiedRect[7 + 8 + 2])
            {
                rectTransform.anchoredPosition = invCon.shieldPosList[7 + 8];
                invCon.occupiedRect[7 + 8 + 1] = true;
                invCon.occupiedRect[7 + 8 + 2] = true;
                invCon.shieldRan = 7 + 8;
                return;
            }
            else
            {
                rectTransform.anchoredPosition = initPos;
                setShieldRan(true);
                return;
            }
        }
        else if (Input.mousePosition.x < invCon.shieldPointerList[16].x)
        {
            for (int i = 0; i < 7; i++)
            {
                if (Input.mousePosition.y < invCon.shieldPointerList[i].y)
                {
                    if (!invCon.occupiedRect[i + 16 + 2] && !invCon.occupiedRect[i + 16 + 3])
                    {
                        rectTransform.anchoredPosition = invCon.shieldPosList[i + 16];
                        invCon.occupiedRect[i + 16 + 2] = true;
                        invCon.occupiedRect[i + 16 + 3] = true;
                        invCon.shieldRan = i + 16;
                        return;
                    }
                    else
                    {
                        rectTransform.anchoredPosition = initPos;
                        setShieldRan(true);
                        return;
                    }
                }
            }
            if (!invCon.occupiedRect[7 + 16 + 2] && !invCon.occupiedRect[7 + 16 + 3])
            {
                rectTransform.anchoredPosition = invCon.shieldPosList[7 + 16];
                invCon.occupiedRect[7 + 16 + 2] = true;
                invCon.occupiedRect[7 + 16 + 3] = true;
                invCon.shieldRan = 7 + 16;
                return;
            }
            else
            {
                rectTransform.anchoredPosition = initPos;
                setShieldRan(true);
                return;
            }
        }
        else
        {
            for (int i = 0; i < 7; i++)
            {
                if (Input.mousePosition.y < invCon.shieldPointerList[i].y)
                {
                    if (!invCon.occupiedRect[i + 24 + 3] && !invCon.occupiedRect[i + 24 + 4])
                    {
                        rectTransform.anchoredPosition = invCon.shieldPosList[i + 24];
                        invCon.occupiedRect[i + 24 + 3] = true;
                        invCon.occupiedRect[i + 24 + 4] = true;
                        invCon.shieldRan = i + 24;
                        return;
                    }
                    else
                    {
                        rectTransform.anchoredPosition = initPos;
                        setShieldRan(true);
                        return;
                    }
                }
            }
            if (!invCon.occupiedRect[7 + 24 + 3] && !invCon.occupiedRect[7 + 24 + 4])
            {
                rectTransform.anchoredPosition = invCon.shieldPosList[7 + 24];
                invCon.occupiedRect[7 + 24 + 3] = true;
                invCon.occupiedRect[7 + 24 + 4] = true;
                invCon.shieldRan = 7 + 24;
                return;
            }
            else
            {
                rectTransform.anchoredPosition = initPos;
                setShieldRan(true);
                return;
            }
        }
    }
    private void ChkShoe(testInvCon invCon)
    {
        if (Input.mousePosition.x < invCon.shoePointerList[0].x)
        {
            for (int i = 0; i < 8; i++)
            {
                if (Input.mousePosition.y < invCon.shoePointerList[i].y)
                {
                    if (!invCon.occupiedRect[i] && !invCon.occupiedRect[i + 9])
                    {
                        rectTransform.anchoredPosition = invCon.shoePosList[i];
                        invCon.occupiedRect[i] = true;
                        invCon.occupiedRect[i + 9] = true;
                        invCon.shoeRan = i;
                        return;
                    }
                    else
                    {
                        rectTransform.anchoredPosition = initPos;
                        setShoeRan(true);
                        return;
                    }
                }
            }
            if (!invCon.occupiedRect[8] && !invCon.occupiedRect[8 + 9])
            {
                rectTransform.anchoredPosition = invCon.shoePosList[8];
                invCon.occupiedRect[8] = true;
                invCon.occupiedRect[8 + 9] = true;
                invCon.shoeRan = 8;
                return;
            }
            else
            {
                rectTransform.anchoredPosition = initPos;
                setShoeRan(true);
                return;
            }
        }
        else if (Input.mousePosition.x < invCon.shoePointerList[9].x)
        {
            for (int i = 0; i < 8; i++)
            {
                if (Input.mousePosition.y < invCon.shoePointerList[i].y)
                {
                    if (!invCon.occupiedRect[i + 9] && !invCon.occupiedRect[i + 9 + 9])
                    {
                        rectTransform.anchoredPosition = invCon.shoePosList[i + 9];
                        invCon.occupiedRect[i + 9] = true;
                        invCon.occupiedRect[i + 9 + 9] = true;
                        invCon.shoeRan = i + 9;
                        return;
                    }
                    else
                    {
                        rectTransform.anchoredPosition = initPos;
                        setShoeRan(true);
                        return;
                    }
                }
            }
            if (!invCon.occupiedRect[8 + 9] && !invCon.occupiedRect[8 + 9 + 9])
            {
                rectTransform.anchoredPosition = invCon.shoePosList[8 + 9];
                invCon.occupiedRect[8 + 9] = true;
                invCon.occupiedRect[8 + 9 + 9] = true;
                invCon.shoeRan = 8 + 9;
                return;
            }
            else
            {
                rectTransform.anchoredPosition = initPos;
                setShoeRan(true);
                return;
            }
        }
        else
        {
            for (int i = 0; i < 8; i++)
            {
                if (Input.mousePosition.y < invCon.shoePointerList[i].y)
                {
                    if (!invCon.occupiedRect[i + 18] && !invCon.occupiedRect[i + 18 + 9])
                    {
                        rectTransform.anchoredPosition = invCon.shoePosList[i + 18];
                        invCon.occupiedRect[i + 18] = true;
                        invCon.occupiedRect[i + 18 + 9] = true;
                        invCon.shoeRan = i + 18;
                        return;
                    }
                    else
                    {
                        rectTransform.anchoredPosition = initPos;
                        setShoeRan(true);
                        return;
                    }
                }
            }
            if (!invCon.occupiedRect[8 + 18] && !invCon.occupiedRect[8 + 18 + 9])
            {
                rectTransform.anchoredPosition = invCon.shoePosList[8 + 18];
                invCon.occupiedRect[8 + 18] = true;
                invCon.occupiedRect[8 + 18 + 9] = true;
                invCon.shoeRan = 8 + 18;
                return;
            }
            else
            {
                rectTransform.anchoredPosition = initPos;
                setShoeRan(true);
                return;
            }
        }
    }
    private void ChkRing(testInvCon invCon)
    {
        if (Input.mousePosition.x < invCon.ringPointerList[0].x)
        {
            for (int i = 0; i < 8; i++)
            {
                if (Input.mousePosition.y < invCon.ringPointerList[i].y)
                {
                    if (!invCon.occupiedRect[i])
                    {
                        rectTransform.anchoredPosition = invCon.ringPosList[i];
                        invCon.occupiedRect[i] = true;
                        invCon.ringRan = i;
                        return;
                    }
                    else
                    {
                        rectTransform.anchoredPosition = initPos;
                        setRingRan(true);
                        return;
                    }
                }
            }
            if (!invCon.occupiedRect[8])
            {
                rectTransform.anchoredPosition = invCon.ringPosList[8];
                invCon.occupiedRect[8] = true;
                invCon.ringRan = 8;
                return;
            }
            else
            {
                rectTransform.anchoredPosition = initPos;
                setRingRan(true);
                return;
            }
        }
        else if (Input.mousePosition.x < invCon.ringPointerList[9].x)
        {
            for (int i = 0; i < 8; i++)
            {
                if (Input.mousePosition.y < invCon.ringPointerList[i].y)
                {
                    if (!invCon.occupiedRect[i + 9])
                    {
                        rectTransform.anchoredPosition = invCon.ringPosList[i + 9];
                        invCon.occupiedRect[i + 9] = true;
                        invCon.ringRan = i + 9;
                        return;
                    }
                    else
                    {
                        rectTransform.anchoredPosition = initPos;
                        setRingRan(true);
                        return;
                    }
                }
            }
            if (!invCon.occupiedRect[8 + 9])
            {
                rectTransform.anchoredPosition = invCon.ringPosList[8 + 9];
                invCon.occupiedRect[8 + 9] = true;
                invCon.ringRan = 8 + 9;
                return;
            }
            else
            {
                rectTransform.anchoredPosition = initPos;
                setRingRan(true);
                return;
            }
        }
        else if (Input.mousePosition.x < invCon.ringPointerList[18].x)
        {
            for (int i = 0; i < 8; i++)
            {
                if (Input.mousePosition.y < invCon.ringPointerList[i].y)
                {
                    if (!invCon.occupiedRect[i + 18])
                    {
                        rectTransform.anchoredPosition = invCon.ringPosList[i + 18];
                        invCon.occupiedRect[i + 18] = true;
                        invCon.ringRan = i + 18;
                        return;
                    }
                    else
                    {
                        rectTransform.anchoredPosition = initPos;
                        setRingRan(true);
                        return;
                    }
                }
            }
            if (!invCon.occupiedRect[8 + 18])
            {
                rectTransform.anchoredPosition = invCon.ringPosList[8 + 18];
                invCon.occupiedRect[8 + 18] = true;
                invCon.ringRan = 8 + 18;
                return;
            }
            else
            {
                rectTransform.anchoredPosition = initPos;
                setRingRan(true);
                return;
            }
        }
        else
        {
            for (int i = 0; i < 8; i++)
            {
                if (Input.mousePosition.y < invCon.ringPointerList[i].y)
                {
                    if (!invCon.occupiedRect[i + 27])
                    {
                        rectTransform.anchoredPosition = invCon.ringPosList[i + 27];
                        invCon.occupiedRect[i + 27] = true;
                        invCon.ringRan = i + 27;
                        return;
                    }
                    else
                    {
                        rectTransform.anchoredPosition = initPos;
                        setRingRan(true);
                        return;
                    }
                }
            }
            if (!invCon.occupiedRect[8 + 27])
            {
                rectTransform.anchoredPosition = invCon.ringPosList[8 + 27];
                invCon.occupiedRect[8 + 27] = true;
                invCon.ringRan = 8 + 27;
                return;
            }
            else
            {
                rectTransform.anchoredPosition = initPos;
                setRingRan(true);
                return;
            }
        }
    }

    #region--set occupiedRect[] values based on Ran--
    private void setArmorRan(bool input)
    {
        if (input)
        {
            if (armorRan < 8)
            {
                invCon.occupiedRect[armorRan] = true;
                invCon.occupiedRect[armorRan + 1] = true;
                invCon.occupiedRect[armorRan + 9] = true;
                invCon.occupiedRect[armorRan + 10] = true;
            }
            else if (armorRan < 16)
            {
                invCon.occupiedRect[armorRan + 1] = true;
                invCon.occupiedRect[armorRan + 2] = true;
                invCon.occupiedRect[armorRan + 10] = true;
                invCon.occupiedRect[armorRan + 11] = true;
            }
            else
            {
                invCon.occupiedRect[armorRan + 2] = true;
                invCon.occupiedRect[armorRan + 3] = true;
                invCon.occupiedRect[armorRan + 11] = true;
                invCon.occupiedRect[armorRan + 12] = true;
            }
        }
        else
        {
            if (armorRan < 8)
            {
                invCon.occupiedRect[armorRan] = false;
                invCon.occupiedRect[armorRan + 1] = false;
                invCon.occupiedRect[armorRan + 9] = false;
                invCon.occupiedRect[armorRan + 10] = false;
            }
            else if (armorRan < 16)
            {
                invCon.occupiedRect[armorRan + 1] = false;
                invCon.occupiedRect[armorRan + 2] = false;
                invCon.occupiedRect[armorRan + 10] = false;
                invCon.occupiedRect[armorRan + 11] = false;
            }
            else
            {
                invCon.occupiedRect[armorRan + 2] = false;
                invCon.occupiedRect[armorRan + 3] = false;
                invCon.occupiedRect[armorRan + 11] = false;
                invCon.occupiedRect[armorRan + 12] = false;
            }
        }

    }
    private void setSwordRan(bool input)
    {
        if (input)
        {
            if (swordRan < 7)
            {
                invCon.occupiedRect[swordRan] = true;
                invCon.occupiedRect[swordRan + 1] = true;
                invCon.occupiedRect[swordRan + 2] = true;
            }
            else if (swordRan < 14)
            {
                invCon.occupiedRect[swordRan + 2] = true;
                invCon.occupiedRect[swordRan + 3] = true;
                invCon.occupiedRect[swordRan + 4] = true;
            }
            else if (swordRan < 21)
            {
                invCon.occupiedRect[swordRan + 4] = true;
                invCon.occupiedRect[swordRan + 5] = true;
                invCon.occupiedRect[swordRan + 6] = true;
            }
            else
            {
                invCon.occupiedRect[swordRan + 6] = true;
                invCon.occupiedRect[swordRan + 7] = true;
                invCon.occupiedRect[swordRan + 8] = true;
            }
        }
        else
        {
            if (swordRan < 7)
            {
                invCon.occupiedRect[swordRan] = false;
                invCon.occupiedRect[swordRan + 1] = false;
                invCon.occupiedRect[swordRan + 2] = false;
            }
            else if (swordRan < 14)
            {
                invCon.occupiedRect[swordRan + 2] = false;
                invCon.occupiedRect[swordRan + 3] = false;
                invCon.occupiedRect[swordRan + 4] = false;
            }
            else if (swordRan < 21)
            {
                invCon.occupiedRect[swordRan + 4] = false;
                invCon.occupiedRect[swordRan + 5] = false;
                invCon.occupiedRect[swordRan + 6] = false;
            }
            else
            {
                invCon.occupiedRect[swordRan + 6] = false;
                invCon.occupiedRect[swordRan + 7] = false;
                invCon.occupiedRect[swordRan + 8] = false;
            }
        }

    }
    private void setShieldRan(bool input)
    {
        if (input)
        {
            if (shieldRan < 8)
            {
                invCon.occupiedRect[shieldRan] = true;
                invCon.occupiedRect[shieldRan + 1] = true;
            }
            else if (shieldRan < 16)
            {
                invCon.occupiedRect[shieldRan + 1] = true;
                invCon.occupiedRect[shieldRan + 2] = true;
            }
            else if (shieldRan < 24)
            {
                invCon.occupiedRect[shieldRan + 2] = true;
                invCon.occupiedRect[shieldRan + 3] = true;
            }
            else
            {
                invCon.occupiedRect[shieldRan + 3] = true;
                invCon.occupiedRect[shieldRan + 4] = true;
            }
        }
        else
        {
            if (shieldRan < 8)
            {
                invCon.occupiedRect[shieldRan] = false;
                invCon.occupiedRect[shieldRan + 1] = false;
            }
            else if (shieldRan < 16)
            {
                invCon.occupiedRect[shieldRan + 1] = false;
                invCon.occupiedRect[shieldRan + 2] = false;
            }
            else if (shieldRan < 24)
            {
                invCon.occupiedRect[shieldRan + 2] = false;
                invCon.occupiedRect[shieldRan + 3] = false;
            }
            else
            {
                invCon.occupiedRect[shieldRan + 3] = false;
                invCon.occupiedRect[shieldRan + 4] = false;
            }
        }
    }
    private void setShoeRan(bool input)
    {
        if (input)
        {
            invCon.occupiedRect[shoeRan] = true;
            invCon.occupiedRect[shoeRan + 9] = true;
        }
        else
        {
            invCon.occupiedRect[shoeRan] = false;
            invCon.occupiedRect[shoeRan + 9] = false;
        }
    }
    private void setRingRan(bool input)
    {
        if (input)
        {
            invCon.occupiedRect[ringRan] = true;
        }
        else
        {
            invCon.occupiedRect[ringRan] = false;
        }
    }
    #endregion


    private void Update()
    {

    }
}
