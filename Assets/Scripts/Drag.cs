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
    public List<int> armorRan = new List<int>();
    public List<int> shieldRan = new List<int>();
    public List<int> shoeRan = new List<int>();
    public List<int> swordRan = new List<int>();
    public List<int> ringRan = new List<int>();
    private int armorRIV, shieldRIV, shoeRIV, swordRIV, ringRIV;
    //private InventoryControl invCon;
    private testInvCon invCon;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        invCon = GameObject.Find("InventoryManager").GetComponent<testInvCon>();
        //invCon = GameObject.Find("InventoryControl").GetComponent<InventoryControl>();
        for (int i = 0; i < 4; i++)
        {
            armorRan.Add(-1);
            shieldRan.Add(-1);
            swordRan.Add(-1);
            shoeRan.Add(-1);
            ringRan.Add(-1);
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        initPos = rectTransform.anchoredPosition;
        objTag = gameObject.transform.tag;
        if (objTag.Contains("Armor"))
        {
            for (int i = 0; i < 4; i++)
            {
                if (objTag.Contains(i.ToString()))
                {
                    armorRan[i] = invCon.armorRan[i];
                    armorRIV = i;
                    SetArmorRan(false);
                    return;
                }
            }
            Debug.Log("Selected object is not a numbered item");
        }
        else if (objTag.Contains("Sword"))
        {
            for (int i = 0; i < 4; i++)
            {
                if (objTag.Contains(i.ToString()))
                {
                    swordRan[i] = invCon.swordRan[i];
                    swordRIV = i;
                    SetSwordRan(false);
                    return;
                }
            }
            Debug.Log("Selected object is not a numbered item");
        }
        else if (objTag.Contains("Shield"))
        {
            for (int i = 0; i < 4; i++)
            {
                if (objTag.Contains(i.ToString()))
                {
                    shieldRan[i] = invCon.shieldRan[i];
                    shieldRIV = i;
                    SetShieldRan(false);
                    return;
                }
            }
            Debug.Log("Selected object is not a numbered item");
        }
        else if (objTag.Contains("Shoe"))
        {
            for (int i = 0; i < 4; i++)
            {
                if (objTag.Contains(i.ToString()))
                {
                    shoeRan[i] = invCon.shoeRan[i];
                    shoeRIV = i;
                    SetShoeRan(false);
                    return;
                }
            }
            Debug.Log("Selected object is not a numbered item");
        }
        else if (objTag.Contains("Ring"))
        {
            for (int i = 0; i < 4; i++)
            {
                if (objTag.Contains(i.ToString()))
                {
                    ringRan[i] = invCon.ringRan[i];
                    ringRIV = i;
                    SetRingRan(false);
                    return;
                }
            }
            Debug.Log("Selected object is not a numbered item");
        }
        else
        {
            Debug.Log("Selected object is not a draggable item");
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
            if (objTag.Contains("Armor"))
            {
                for (int i = 0; i < 4; i++)
                {
                    if (objTag.Contains(i.ToString()))
                    {
                        SetArmorRan(true);
                    }
                }
            }
            else if (objTag.Contains("Sword"))
            {
                for (int i = 0; i < 4; i++)
                {
                    if (objTag.Contains(i.ToString()))
                    {
                        SetSwordRan(true);
                    }
                }
            }
            else if (objTag.Contains("Shield"))
            {
                for (int i = 0; i < 4; i++)
                {
                    if (objTag.Contains(i.ToString()))
                    {
                        SetShieldRan(true);
                    }
                }
            }
            else if (objTag.Contains("Shoe"))
            {
                for (int i = 0; i < 4; i++)
                {
                    if (objTag.Contains(i.ToString()))
                    {
                        SetShoeRan(true);
                    }
                }
            }
            else if (objTag.Contains("Ring"))
            {
                for (int i = 0; i < 4; i++)
                {
                    if (objTag.Contains(i.ToString()))
                    {
                        SetRingRan(true);
                    }
                }
            }
        }
        else
        {
            if (objTag.Contains("Armor"))
            {
                ChkArmor(invCon);
            }
            else if (objTag.Contains("Sword"))
            {
                ChkSword(invCon);
            }
            else if (objTag.Contains("Shield"))
            {
                ChkShield(invCon);
            }
            else if (objTag.Contains("Shoe"))
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
                        invCon.occupiedRect_armor[i] = armorRIV;
                        invCon.occupiedRect_armor[i + 1] = armorRIV;
                        invCon.occupiedRect_armor[i + 9] = armorRIV;
                        invCon.occupiedRect_armor[i + 10] = armorRIV;
                        invCon.armorRan[armorRIV] = i;
                        return;
                    }
                    else
                    {
                        rectTransform.anchoredPosition = initPos;
                        SetArmorRan(true);
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
                invCon.occupiedRect_armor[7] = armorRIV;
                invCon.occupiedRect_armor[7 + 1] = armorRIV;
                invCon.occupiedRect_armor[7 + 9] = armorRIV;
                invCon.occupiedRect_armor[7 + 10] = armorRIV;
                invCon.armorRan[armorRIV] = 7;
                return;
            }
            else
            {
                rectTransform.anchoredPosition = initPos;
                SetArmorRan(true);
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
                        invCon.occupiedRect_armor[i + 8 + 1] = armorRIV;
                        invCon.occupiedRect_armor[i + 8 + 2] = armorRIV;
                        invCon.occupiedRect_armor[i + 8 + 10] = armorRIV;
                        invCon.occupiedRect_armor[i + 8 + 11] = armorRIV;
                        invCon.armorRan[armorRIV] = i + 8;
                        return;
                    }
                    else
                    {
                        rectTransform.anchoredPosition = initPos;
                        SetArmorRan(true);
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
                invCon.occupiedRect_armor[7 + 8 + 1] = armorRIV;
                invCon.occupiedRect_armor[7 + 8 + 2] = armorRIV;
                invCon.occupiedRect_armor[7 + 8 + 10] = armorRIV;
                invCon.occupiedRect_armor[7 + 8 + 11] = armorRIV;
                invCon.armorRan[armorRIV] = 7 + 8;
                return;
            }
            else
            {
                rectTransform.anchoredPosition = initPos;
                SetArmorRan(true);
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
                        invCon.occupiedRect_armor[i + 16 + 2] = armorRIV;
                        invCon.occupiedRect_armor[i + 16 + 3] = armorRIV;
                        invCon.occupiedRect_armor[i + 16 + 11] = armorRIV;
                        invCon.occupiedRect_armor[i + 16 + 12] = armorRIV;
                        invCon.armorRan[armorRIV] = i + 16;
                        return;
                    }
                    else
                    {
                        rectTransform.anchoredPosition = initPos;
                        SetArmorRan(true);
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
                invCon.occupiedRect_armor[7 + 16 + 2] = armorRIV;
                invCon.occupiedRect_armor[7 + 16 + 3] = armorRIV;
                invCon.occupiedRect_armor[7 + 16 + 11] = armorRIV;
                invCon.occupiedRect_armor[7 + 16 + 12] = armorRIV;
                invCon.armorRan[armorRIV] = 7 + 16;
                return;
            }
            else
            {
                rectTransform.anchoredPosition = initPos;
                SetArmorRan(true);
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
                        invCon.occupiedRect_sword[i] = swordRIV;
                        invCon.occupiedRect_sword[i + 1] = swordRIV;
                        invCon.occupiedRect_sword[i + 2] = swordRIV;
                        invCon.swordRan[swordRIV] = i;
                        return;
                    }
                    else
                    {
                        rectTransform.anchoredPosition = initPos;
                        SetSwordRan(true);
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
                invCon.occupiedRect_sword[6] = swordRIV;
                invCon.occupiedRect_sword[6 + 1] = swordRIV;
                invCon.occupiedRect_sword[6 + 2] = swordRIV;
                invCon.swordRan[swordRIV] = 6;
                return;
            }
            else
            {
                rectTransform.anchoredPosition = initPos;
                SetSwordRan(true);
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
                        invCon.occupiedRect_sword[i + 7 + 2] = swordRIV;
                        invCon.occupiedRect_sword[i + 7 + 3] = swordRIV;
                        invCon.occupiedRect_sword[i + 7 + 4] = swordRIV;
                        invCon.swordRan[swordRIV] = i + 7;
                        return;
                    }
                    else
                    {
                        rectTransform.anchoredPosition = initPos;
                        SetSwordRan(true);
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
                invCon.occupiedRect_sword[6 + 7 + 2] = swordRIV;
                invCon.occupiedRect_sword[6 + 7 + 3] = swordRIV;
                invCon.occupiedRect_sword[6 + 7 + 4] = swordRIV;
                invCon.swordRan[swordRIV] = 6 + 7;
                return;
            }
            else
            {
                rectTransform.anchoredPosition = initPos;
                SetSwordRan(true);
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
                        invCon.occupiedRect_sword[i + 14 + 4] = swordRIV;
                        invCon.occupiedRect_sword[i + 14 + 5] = swordRIV;
                        invCon.occupiedRect_sword[i + 14 + 6] = swordRIV;
                        invCon.swordRan[swordRIV] = i + 14;
                        return;
                    }
                    else
                    {
                        rectTransform.anchoredPosition = initPos;
                        SetSwordRan(true);
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
                invCon.occupiedRect_sword[6 + 14 + 4] = swordRIV;
                invCon.occupiedRect_sword[6 + 14 + 5] = swordRIV;
                invCon.occupiedRect_sword[6 + 14 + 6] = swordRIV;
                invCon.swordRan[swordRIV] = 6 + 14;
                return;
            }
            else
            {
                rectTransform.anchoredPosition = initPos;
                SetSwordRan(true);
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
                        invCon.occupiedRect_sword[i + 21 + 6] = swordRIV;
                        invCon.occupiedRect_sword[i + 21 + 7] = swordRIV;
                        invCon.occupiedRect_sword[i + 21 + 8] = swordRIV;
                        invCon.swordRan[swordRIV] = i + 21;
                        return;
                    }
                    else
                    {
                        rectTransform.anchoredPosition = initPos;
                        SetSwordRan(true);
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
                invCon.occupiedRect_sword[6 + 21 + 6] = swordRIV;
                invCon.occupiedRect_sword[6 + 21 + 7] = swordRIV;
                invCon.occupiedRect_sword[6 + 21 + 8] = swordRIV;
                invCon.swordRan[swordRIV] = 6 + 21;
                return;
            }
            else
            {
                rectTransform.anchoredPosition = initPos;
                SetSwordRan(true);
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
                        invCon.occupiedRect_shield[i] = shieldRIV;
                        invCon.occupiedRect_shield[i + 1] = shieldRIV;
                        invCon.shieldRan[shieldRIV] = i;
                        return;
                    }
                    else
                    {
                        rectTransform.anchoredPosition = initPos;
                        SetShieldRan(true);
                        return;
                    }
                }
            }
            if (!invCon.occupiedRect[7] && !invCon.occupiedRect[7 + 1])
            {
                rectTransform.anchoredPosition = invCon.shieldPosList[7];
                invCon.occupiedRect[7] = true;
                invCon.occupiedRect[7 + 1] = true;
                invCon.occupiedRect_shield[7] = shieldRIV;
                invCon.occupiedRect_shield[7 + 1] = shieldRIV;
                invCon.shieldRan[shieldRIV] = 7;
                return;
            }
            else
            {
                rectTransform.anchoredPosition = initPos;
                SetShieldRan(true);
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
                        invCon.occupiedRect_shield[i + 8 + 1] = shieldRIV;
                        invCon.occupiedRect_shield[i + 8 + 2] = shieldRIV;
                        invCon.shieldRan[shieldRIV] = i + 8;
                        return;
                    }
                    else
                    {
                        rectTransform.anchoredPosition = initPos;
                        SetShieldRan(true);
                        return;
                    }
                }
            }
            if (!invCon.occupiedRect[7 + 8 + 1] && !invCon.occupiedRect[7 + 8 + 2])
            {
                rectTransform.anchoredPosition = invCon.shieldPosList[7 + 8];
                invCon.occupiedRect[7 + 8 + 1] = true;
                invCon.occupiedRect[7 + 8 + 2] = true;
                invCon.occupiedRect_shield[7 + 8 + 1] = shieldRIV;
                invCon.occupiedRect_shield[7 + 8 + 2] = shieldRIV;
                invCon.shieldRan[shieldRIV] = 7 + 8;
                return;
            }
            else
            {
                rectTransform.anchoredPosition = initPos;
                SetShieldRan(true);
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
                        invCon.occupiedRect_shield[i + 16 + 2] = shieldRIV;
                        invCon.occupiedRect_shield[i + 16 + 3] = shieldRIV;
                        invCon.shieldRan[shieldRIV] = i + 16;
                        return;
                    }
                    else
                    {
                        rectTransform.anchoredPosition = initPos;
                        SetShieldRan(true);
                        return;
                    }
                }
            }
            if (!invCon.occupiedRect[7 + 16 + 2] && !invCon.occupiedRect[7 + 16 + 3])
            {
                rectTransform.anchoredPosition = invCon.shieldPosList[7 + 16];
                invCon.occupiedRect[7 + 16 + 2] = true;
                invCon.occupiedRect[7 + 16 + 3] = true;
                invCon.occupiedRect_shield[7 + 16 + 2] = shieldRIV;
                invCon.occupiedRect_shield[7 + 16 + 3] = shieldRIV;
                invCon.shieldRan[shieldRIV] = 7 + 16;
                return;
            }
            else
            {
                rectTransform.anchoredPosition = initPos;
                SetShieldRan(true);
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
                        invCon.occupiedRect_shield[i + 24 + 3] = shieldRIV;
                        invCon.occupiedRect_shield[i + 24 + 4] = shieldRIV;
                        invCon.shieldRan[shieldRIV] = i + 24;
                        return;
                    }
                    else
                    {
                        rectTransform.anchoredPosition = initPos;
                        SetShieldRan(true);
                        return;
                    }
                }
            }
            if (!invCon.occupiedRect[7 + 24 + 3] && !invCon.occupiedRect[7 + 24 + 4])
            {
                rectTransform.anchoredPosition = invCon.shieldPosList[7 + 24];
                invCon.occupiedRect[7 + 24 + 3] = true;
                invCon.occupiedRect[7 + 24 + 4] = true;
                invCon.occupiedRect_shield[7 + 24 + 3] = shieldRIV;
                invCon.occupiedRect_shield[7 + 24 + 4] = shieldRIV;
                invCon.shieldRan[shieldRIV] = 7 + 24;
                return;
            }
            else
            {
                rectTransform.anchoredPosition = initPos;
                SetShieldRan(true);
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
                        invCon.occupiedRect_shoe[i] = shoeRIV;
                        invCon.occupiedRect_shoe[i + 9] = shoeRIV;
                        invCon.shoeRan[shoeRIV] = i;
                        return;
                    }
                    else
                    {
                        rectTransform.anchoredPosition = initPos;
                        SetShoeRan(true);
                        return;
                    }
                }
            }
            if (!invCon.occupiedRect[8] && !invCon.occupiedRect[8 + 9])
            {
                rectTransform.anchoredPosition = invCon.shoePosList[8];
                invCon.occupiedRect[8] = true;
                invCon.occupiedRect[8 + 9] = true;
                invCon.occupiedRect_shoe[8] = shoeRIV;
                invCon.occupiedRect_shoe[8 + 9] = shoeRIV;
                invCon.shoeRan[shoeRIV] = 8;
                return;
            }
            else
            {
                rectTransform.anchoredPosition = initPos;
                SetShoeRan(true);
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
                        invCon.occupiedRect_shoe[i + 9] = shoeRIV;
                        invCon.occupiedRect_shoe[i + 9 + 9] = shoeRIV;
                        invCon.shoeRan[shoeRIV] = i + 9;
                        return;
                    }
                    else
                    {
                        rectTransform.anchoredPosition = initPos;
                        SetShoeRan(true);
                        return;
                    }
                }
            }
            if (!invCon.occupiedRect[8 + 9] && !invCon.occupiedRect[8 + 9 + 9])
            {
                rectTransform.anchoredPosition = invCon.shoePosList[8 + 9];
                invCon.occupiedRect[8 + 9] = true;
                invCon.occupiedRect[8 + 9 + 9] = true;
                invCon.occupiedRect_shoe[8 + 9] = shoeRIV;
                invCon.occupiedRect_shoe[8 + 9 + 9] = shoeRIV;
                invCon.shoeRan[shoeRIV] = 8 + 9;
                return;
            }
            else
            {
                rectTransform.anchoredPosition = initPos;
                SetShoeRan(true);
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
                        invCon.occupiedRect_shoe[i + 18] = shoeRIV;
                        invCon.occupiedRect_shoe[i + 18 + 9] = shoeRIV;
                        invCon.shoeRan[shoeRIV] = i + 18;
                        return;
                    }
                    else
                    {
                        rectTransform.anchoredPosition = initPos;
                        SetShoeRan(true);
                        return;
                    }
                }
            }
            if (!invCon.occupiedRect[8 + 18] && !invCon.occupiedRect[8 + 18 + 9])
            {
                rectTransform.anchoredPosition = invCon.shoePosList[8 + 18];
                invCon.occupiedRect[8 + 18] = true;
                invCon.occupiedRect[8 + 18 + 9] = true;
                invCon.occupiedRect_shoe[8 + 18] = shoeRIV;
                invCon.occupiedRect_shoe[8 + 18 + 9] = shoeRIV;
                invCon.shoeRan[shoeRIV] = 8 + 18;
                return;
            }
            else
            {
                rectTransform.anchoredPosition = initPos;
                SetShoeRan(true);
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
                        invCon.occupiedRect_ring[i] = ringRIV;
                        invCon.ringRan[ringRIV] = i;
                        return;
                    }
                    else
                    {
                        rectTransform.anchoredPosition = initPos;
                        SetRingRan(true);
                        return;
                    }
                }
            }
            if (!invCon.occupiedRect[8])
            {
                rectTransform.anchoredPosition = invCon.ringPosList[8];
                invCon.occupiedRect[8] = true;
                invCon.occupiedRect_ring[8] = ringRIV;
                invCon.ringRan[ringRIV] = 8;
                return;
            }
            else
            {
                rectTransform.anchoredPosition = initPos;
                SetRingRan(true);
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
                        invCon.occupiedRect_ring[i + 9] = ringRIV;
                        invCon.ringRan[ringRIV] = i + 9;
                        return;
                    }
                    else
                    {
                        rectTransform.anchoredPosition = initPos;
                        SetRingRan(true);
                        return;
                    }
                }
            }
            if (!invCon.occupiedRect[8 + 9])
            {
                rectTransform.anchoredPosition = invCon.ringPosList[8 + 9];
                invCon.occupiedRect[8 + 9] = true;
                invCon.occupiedRect_ring[8 + 9] = ringRIV;
                invCon.ringRan[ringRIV] = 8 + 9;
                return;
            }
            else
            {
                rectTransform.anchoredPosition = initPos;
                SetRingRan(true);
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
                        invCon.occupiedRect_ring[i + 18] = ringRIV;
                        invCon.ringRan[ringRIV] = i + 18;
                        return;
                    }
                    else
                    {
                        rectTransform.anchoredPosition = initPos;
                        SetRingRan(true);
                        return;
                    }
                }
            }
            if (!invCon.occupiedRect[8 + 18])
            {
                rectTransform.anchoredPosition = invCon.ringPosList[8 + 18];
                invCon.occupiedRect[8 + 18] = true;
                invCon.occupiedRect_ring[8 + 18] = ringRIV;
                invCon.ringRan[ringRIV] = 8 + 18;
                return;
            }
            else
            {
                rectTransform.anchoredPosition = initPos;
                SetRingRan(true);
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
                        invCon.occupiedRect_ring[i + 27] = ringRIV;
                        invCon.ringRan[ringRIV] = i + 27;
                        return;
                    }
                    else
                    {
                        rectTransform.anchoredPosition = initPos;
                        SetRingRan(true);
                        return;
                    }
                }
            }
            if (!invCon.occupiedRect[8 + 27])
            {
                rectTransform.anchoredPosition = invCon.ringPosList[8 + 27];
                invCon.occupiedRect[8 + 27] = true;
                invCon.occupiedRect_ring[8 + 27] = ringRIV;
                invCon.ringRan[ringRIV] = 8 + 27;
                return;
            }
            else
            {
                rectTransform.anchoredPosition = initPos;
                SetRingRan(true);
                return;
            }
        }
    }

    #region--set occupiedRect[] values based on Ran--
    private void SetArmorRan(bool input)
    {
        if (input)
        {
            if (armorRan[armorRIV] < 8)
            {
                invCon.occupiedRect[armorRan[armorRIV]] = true;
                invCon.occupiedRect[armorRan[armorRIV] + 1] = true;
                invCon.occupiedRect[armorRan[armorRIV] + 9] = true;
                invCon.occupiedRect[armorRan[armorRIV] + 10] = true;
                invCon.occupiedRect_armor[armorRan[armorRIV]] = armorRIV;
                invCon.occupiedRect_armor[armorRan[armorRIV] + 1] = armorRIV;
                invCon.occupiedRect_armor[armorRan[armorRIV] + 9] = armorRIV;
                invCon.occupiedRect_armor[armorRan[armorRIV] + 10] = armorRIV;
            }
            else if (armorRan[armorRIV] < 16)
            {
                invCon.occupiedRect[armorRan[armorRIV] + 1] = true;
                invCon.occupiedRect[armorRan[armorRIV] + 2] = true;
                invCon.occupiedRect[armorRan[armorRIV] + 10] = true;
                invCon.occupiedRect[armorRan[armorRIV] + 11] = true;
                invCon.occupiedRect_armor[armorRan[armorRIV] + 1] = armorRIV;
                invCon.occupiedRect_armor[armorRan[armorRIV] + 2] = armorRIV;
                invCon.occupiedRect_armor[armorRan[armorRIV] + 10] = armorRIV;
                invCon.occupiedRect_armor[armorRan[armorRIV] + 11] = armorRIV;
            }
            else
            {
                invCon.occupiedRect[armorRan[armorRIV] + 2] = true;
                invCon.occupiedRect[armorRan[armorRIV] + 3] = true;
                invCon.occupiedRect[armorRan[armorRIV] + 11] = true;
                invCon.occupiedRect[armorRan[armorRIV] + 12] = true;
                invCon.occupiedRect_armor[armorRan[armorRIV] + 2] = armorRIV;
                invCon.occupiedRect_armor[armorRan[armorRIV] + 3] = armorRIV;
                invCon.occupiedRect_armor[armorRan[armorRIV] + 11] = armorRIV;
                invCon.occupiedRect_armor[armorRan[armorRIV] + 12] = armorRIV;
            }
        }
        else
        {
            if (armorRan[armorRIV] < 8)
            {
                invCon.occupiedRect[armorRan[armorRIV]] = false;
                invCon.occupiedRect[armorRan[armorRIV] + 1] = false;
                invCon.occupiedRect[armorRan[armorRIV] + 9] = false;
                invCon.occupiedRect[armorRan[armorRIV] + 10] = false;
                invCon.occupiedRect_armor[armorRan[armorRIV]] = -1;
                invCon.occupiedRect_armor[armorRan[armorRIV] + 1] = -1;
                invCon.occupiedRect_armor[armorRan[armorRIV] + 9] = -1;
                invCon.occupiedRect_armor[armorRan[armorRIV] + 10] = -1;
            }
            else if (armorRan[armorRIV] < 16)
            {
                invCon.occupiedRect[armorRan[armorRIV] + 1] = false;
                invCon.occupiedRect[armorRan[armorRIV] + 2] = false;
                invCon.occupiedRect[armorRan[armorRIV] + 10] = false;
                invCon.occupiedRect[armorRan[armorRIV] + 11] = false;
                invCon.occupiedRect_armor[armorRan[armorRIV] + 1] = -1;
                invCon.occupiedRect_armor[armorRan[armorRIV] + 2] = -1;
                invCon.occupiedRect_armor[armorRan[armorRIV] + 10] = -1;
                invCon.occupiedRect_armor[armorRan[armorRIV] + 11] = -1;
            }
            else
            {
                invCon.occupiedRect[armorRan[armorRIV] + 2] = false;
                invCon.occupiedRect[armorRan[armorRIV] + 3] = false;
                invCon.occupiedRect[armorRan[armorRIV] + 11] = false;
                invCon.occupiedRect[armorRan[armorRIV] + 12] = false;
                invCon.occupiedRect_armor[armorRan[armorRIV] + 2] = -1;
                invCon.occupiedRect_armor[armorRan[armorRIV] + 3] = -1;
                invCon.occupiedRect_armor[armorRan[armorRIV] + 11] = -1;
                invCon.occupiedRect_armor[armorRan[armorRIV] + 12] = -1;
            }
        }

    }
    private void SetSwordRan(bool input)
    {
        if (input)
        {
            if (swordRan[swordRIV] < 7)
            {
                invCon.occupiedRect[swordRan[swordRIV]] = true;
                invCon.occupiedRect[swordRan[swordRIV] + 1] = true;
                invCon.occupiedRect[swordRan[swordRIV] + 2] = true;
                invCon.occupiedRect_sword[swordRan[swordRIV]] = swordRIV;
                invCon.occupiedRect_sword[swordRan[swordRIV] + 1] = swordRIV;
                invCon.occupiedRect_sword[swordRan[swordRIV] + 2] = swordRIV;
            }
            else if (swordRan[swordRIV] < 14)
            {
                invCon.occupiedRect[swordRan[swordRIV] + 2] = true;
                invCon.occupiedRect[swordRan[swordRIV] + 3] = true;
                invCon.occupiedRect[swordRan[swordRIV] + 4] = true;
                invCon.occupiedRect_sword[swordRan[swordRIV] + 2] = swordRIV;
                invCon.occupiedRect_sword[swordRan[swordRIV] + 3] = swordRIV;
                invCon.occupiedRect_sword[swordRan[swordRIV] + 4] = swordRIV;
            }
            else if (swordRan[swordRIV] < 21)
            {
                invCon.occupiedRect[swordRan[swordRIV] + 4] = true;
                invCon.occupiedRect[swordRan[swordRIV] + 5] = true;
                invCon.occupiedRect[swordRan[swordRIV] + 6] = true;
                invCon.occupiedRect_sword[swordRan[swordRIV] + 4] = swordRIV;
                invCon.occupiedRect_sword[swordRan[swordRIV] + 5] = swordRIV;
                invCon.occupiedRect_sword[swordRan[swordRIV] + 6] = swordRIV;
            }
            else
            {
                invCon.occupiedRect[swordRan[swordRIV] + 6] = true;
                invCon.occupiedRect[swordRan[swordRIV] + 7] = true;
                invCon.occupiedRect[swordRan[swordRIV] + 8] = true;
                invCon.occupiedRect_sword[swordRan[swordRIV] + 6] = swordRIV;
                invCon.occupiedRect_sword[swordRan[swordRIV] + 7] = swordRIV;
                invCon.occupiedRect_sword[swordRan[swordRIV] + 8] = swordRIV;
            }
        }
        else
        {
            if (swordRan[swordRIV] < 7)
            {
                invCon.occupiedRect[swordRan[swordRIV]] = false;
                invCon.occupiedRect[swordRan[swordRIV] + 1] = false;
                invCon.occupiedRect[swordRan[swordRIV] + 2] = false;
                invCon.occupiedRect_sword[swordRan[swordRIV]] = -1;
                invCon.occupiedRect_sword[swordRan[swordRIV] + 1] = -1;
                invCon.occupiedRect_sword[swordRan[swordRIV] + 2] = -1;
            }
            else if (swordRan[swordRIV] < 14)
            {
                invCon.occupiedRect[swordRan[swordRIV] + 2] = false;
                invCon.occupiedRect[swordRan[swordRIV] + 3] = false;
                invCon.occupiedRect[swordRan[swordRIV] + 4] = false;
                invCon.occupiedRect_sword[swordRan[swordRIV] + 2] = -1;
                invCon.occupiedRect_sword[swordRan[swordRIV] + 3] = -1;
                invCon.occupiedRect_sword[swordRan[swordRIV] + 4] = -1;
            }
            else if (swordRan[swordRIV] < 21)
            {
                invCon.occupiedRect[swordRan[swordRIV] + 4] = false;
                invCon.occupiedRect[swordRan[swordRIV] + 5] = false;
                invCon.occupiedRect[swordRan[swordRIV] + 6] = false;
                invCon.occupiedRect_sword[swordRan[swordRIV] + 4] = -1;
                invCon.occupiedRect_sword[swordRan[swordRIV] + 5] = -1;
                invCon.occupiedRect_sword[swordRan[swordRIV] + 6] = -1;
            }
            else
            {
                invCon.occupiedRect[swordRan[swordRIV] + 6] = false;
                invCon.occupiedRect[swordRan[swordRIV] + 7] = false;
                invCon.occupiedRect[swordRan[swordRIV] + 8] = false;
                invCon.occupiedRect_sword[swordRan[swordRIV] + 6] = -1;
                invCon.occupiedRect_sword[swordRan[swordRIV] + 7] = -1;
                invCon.occupiedRect_sword[swordRan[swordRIV] + 8] = -1;
            }
        }

    }
    private void SetShieldRan(bool input)
    {
        if (input)
        {
            if (shieldRan[shieldRIV] < 8)
            {
                invCon.occupiedRect[shieldRan[shieldRIV]] = true;
                invCon.occupiedRect[shieldRan[shieldRIV] + 1] = true;
                invCon.occupiedRect_shield[shieldRan[shieldRIV]] = shieldRIV;
                invCon.occupiedRect_shield[shieldRan[shieldRIV] + 1] = shieldRIV;
            }
            else if (shieldRan[shieldRIV] < 16)
            {
                invCon.occupiedRect[shieldRan[shieldRIV] + 1] = true;
                invCon.occupiedRect[shieldRan[shieldRIV] + 2] = true;
                invCon.occupiedRect_shield[shieldRan[shieldRIV] + 1] = shieldRIV;
                invCon.occupiedRect_shield[shieldRan[shieldRIV] + 2] = shieldRIV;
            }
            else if (shieldRan[shieldRIV] < 24)
            {
                invCon.occupiedRect[shieldRan[shieldRIV] + 2] = true;
                invCon.occupiedRect[shieldRan[shieldRIV] + 3] = true;
                invCon.occupiedRect_shield[shieldRan[shieldRIV] + 2] = shieldRIV;
                invCon.occupiedRect_shield[shieldRan[shieldRIV] + 3] = shieldRIV;
            }
            else
            {
                invCon.occupiedRect[shieldRan[shieldRIV] + 3] = true;
                invCon.occupiedRect[shieldRan[shieldRIV] + 4] = true;
                invCon.occupiedRect_shield[shieldRan[shieldRIV] + 3] = shieldRIV;
                invCon.occupiedRect_shield[shieldRan[shieldRIV] + 4] = shieldRIV;
            }
        }
        else
        {
            if (shieldRan[shieldRIV] < 8)
            {
                invCon.occupiedRect[shieldRan[shieldRIV]] = false;
                invCon.occupiedRect[shieldRan[shieldRIV] + 1] = false;
                invCon.occupiedRect_shield[shieldRan[shieldRIV]] = -1;
                invCon.occupiedRect_shield[shieldRan[shieldRIV] + 1] = -1;
            }
            else if (shieldRan[shieldRIV] < 16)
            {
                invCon.occupiedRect[shieldRan[shieldRIV] + 1] = false;
                invCon.occupiedRect[shieldRan[shieldRIV] + 2] = false;
                invCon.occupiedRect_shield[shieldRan[shieldRIV] + 1] = -1;
                invCon.occupiedRect_shield[shieldRan[shieldRIV] + 2] = -1;
            }
            else if (shieldRan[shieldRIV] < 24)
            {
                invCon.occupiedRect[shieldRan[shieldRIV] + 2] = false;
                invCon.occupiedRect[shieldRan[shieldRIV] + 3] = false;
                invCon.occupiedRect_shield[shieldRan[shieldRIV] + 2] = -1;
                invCon.occupiedRect_shield[shieldRan[shieldRIV] + 3] = -1;

            }
            else
            {
                invCon.occupiedRect[shieldRan[shieldRIV] + 3] = false;
                invCon.occupiedRect[shieldRan[shieldRIV] + 4] = false;
                invCon.occupiedRect_shield[shieldRan[shieldRIV] + 3] = -1;
                invCon.occupiedRect_shield[shieldRan[shieldRIV] + 4] = -1;
            }
        }
    }
    private void SetShoeRan(bool input)
    {
        if (input)
        {
            invCon.occupiedRect[shoeRan[shoeRIV]] = true;
            invCon.occupiedRect[shoeRan[shoeRIV] + 9] = true;
            invCon.occupiedRect_shoe[shoeRan[shoeRIV]] = shoeRIV;
            invCon.occupiedRect_shoe[shoeRan[shoeRIV] + 9] = shoeRIV;
        }
        else
        {
            invCon.occupiedRect[shoeRan[shoeRIV]] = false;
            invCon.occupiedRect[shoeRan[shoeRIV] + 9] = false;
            invCon.occupiedRect_shoe[shoeRan[shoeRIV]] = -1;
            invCon.occupiedRect_shoe[shoeRan[shoeRIV] + 9] = -1;
        }
    }
    private void SetRingRan(bool input)
    {
        if (input)
        {
            invCon.occupiedRect[ringRan[ringRIV]] = true;
            invCon.occupiedRect_ring[ringRan[ringRIV]] = ringRIV;
        }
        else
        {
            invCon.occupiedRect[ringRan[ringRIV]] = false;
            invCon.occupiedRect_ring[ringRan[ringRIV]] = -1;
        }
    }
    #endregion

}
