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

    //private InventoryControl invCon;
    private testInvCon invCon;
    private int posIndex;

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
        //if (objTag == "Armor")
        //{
        //    for (int i = 0; i < 3; i++)
        //    {
        //        if (initPos.x == invCon.armorPosList[i].x)
        //        {
        //            for (int j = 0; j < 8; j++)
        //            {
        //                if (initPos.y == invCon.armorPosList[i * 8 + j].y)
        //                {
        //                    posIndex = i * 8 + j;
        //                }
        //            }
        //        }
        //    }
        //}
        //else if (objTag == "Shield")
        //{
        //    for (int i = 0; i < 4; i++)
        //    {
        //        if (initPos.x == invCon.shieldPosList[i].x)
        //        {
        //            for (int j = 0; j < 8; j++)
        //            {
        //                if (initPos.y == invCon.shieldPosList[i * 8 + j].y)
        //                {
        //                    posIndex = i * 8 + j;
        //                }
        //            }
        //        }
        //    }
        //}
        //else if (objTag == "Shoe")
        //{
        //    for (int i = 0; i < 3; i++)
        //    {
        //        if (initPos.x == invCon.shoePosList[i].x)
        //        {
        //            for (int j = 0; j < 9; j++)
        //            {
        //                if (initPos.y == invCon.shoePosList[i * 9 + j].y)
        //                {
        //                    posIndex = i * 9 + j;
        //                }
        //            }
        //        }
        //    }
        //}
        //else if (objTag == "Sword")
        //{
        //    for (int i = 0; i < 4; i++)
        //    {
        //        if (initPos.x == invCon.swordPosList[i].x)
        //        {
        //            for (int j = 0; j < 7; j++)
        //            {
        //                if (initPos.y == invCon.swordPosList[i * 7 + j].y)
        //                {
        //                    posIndex = i * 7 + j;
        //                }
        //            }
        //        }
        //    }
        //}
        //else
        //{
        //    for (int i = 0; i < 4; i++)
        //    {
        //        if (initPos.x == invCon.ringPosList[i].x)
        //        {
        //            for (int j = 0; j < 9; j++)
        //            {
        //                if (initPos.y == invCon.ringPosList[i * 9 + j].y)
        //                {
        //                    posIndex = i * 9 + j;
        //                }
        //            }
        //        }
        //    }
        //}
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
        }
        else
        {
            if (objTag == "Armor")
            {
                ChkArmor(invCon);
            }
            else if (objTag == "Shield")
            {
                ChkShield(invCon);
            }
            else if (objTag == "Shoe")
            {
                ChkShoe(invCon);
            }
            else if (objTag == "Sword")
            {
                ChkSword(invCon);
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
                    rectTransform.anchoredPosition = invCon.armorPosList[i];
                    return;
                }
            }
            rectTransform.anchoredPosition = invCon.armorPosList[7];
            return;
        }
        else if (Input.mousePosition.x < invCon.armorPointerList[8].x)
        {
            for (int i = 0; i < 7; i++)
            {
                if (Input.mousePosition.y < invCon.armorPointerList[i].y)
                {
                    rectTransform.anchoredPosition = invCon.armorPosList[i + 8];
                    return;
                }
            }
            rectTransform.anchoredPosition = invCon.armorPosList[15];
            return;
        }
        else
        {
            for (int i = 0; i < 7; i++)
            {
                if (Input.mousePosition.y < invCon.armorPointerList[i].y)
                {
                    rectTransform.anchoredPosition = invCon.armorPosList[i + 16];
                    return;
                }
            }
            rectTransform.anchoredPosition = invCon.armorPosList[23];
            return;
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
                    rectTransform.anchoredPosition = invCon.shieldPosList[i];
                    return;
                }
            }
            rectTransform.anchoredPosition = invCon.shieldPosList[7];
            return;
        }
        else if (Input.mousePosition.x < invCon.shieldPointerList[8].x)
        {
            for (int i = 0; i < 7; i++)
            {
                if (Input.mousePosition.y < invCon.shieldPointerList[i].y)
                {
                    rectTransform.anchoredPosition = invCon.shieldPosList[i + 8];
                    return;
                }
            }
            rectTransform.anchoredPosition = invCon.shieldPosList[15];
            return;
        }
        else if (Input.mousePosition.x < invCon.shieldPointerList[16].x)
        {
            for (int i = 0; i < 7; i++)
            {
                if (Input.mousePosition.y < invCon.shieldPointerList[i].y)
                {
                    rectTransform.anchoredPosition = invCon.shieldPosList[i + 16];
                    return;
                }
            }
            rectTransform.anchoredPosition = invCon.shieldPosList[23];
            return;
        }
        else
        {
            for (int i = 0; i < 7; i++)
            {
                if (Input.mousePosition.y < invCon.shieldPointerList[i].y)
                {
                    rectTransform.anchoredPosition = invCon.shieldPosList[i + 24];
                    return;
                }
            }
            rectTransform.anchoredPosition = invCon.shieldPosList[31];
            return;
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
                    rectTransform.anchoredPosition = invCon.shoePosList[i];
                    return;
                }
            }
            rectTransform.anchoredPosition = invCon.shoePosList[8];
        }
        else if (Input.mousePosition.x < invCon.shoePointerList[9].x)
        {
            for (int i = 0; i < 8; i++)
            {
                if (Input.mousePosition.y < invCon.shoePointerList[i].y)
                {
                    rectTransform.anchoredPosition = invCon.shoePosList[i + 9];
                    return;
                }
            }
            rectTransform.anchoredPosition = invCon.shoePosList[17];
        }
        else
        {
            for (int i = 0; i < 8; i++)
            {
                if (Input.mousePosition.y < invCon.shoePointerList[i].y)
                {
                    rectTransform.anchoredPosition = invCon.shoePosList[i + 18];
                    return;
                }
            }
            rectTransform.anchoredPosition = invCon.shoePosList[26];
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
                    rectTransform.anchoredPosition = invCon.swordPosList[i];
                    return;
                }
            }
            rectTransform.anchoredPosition = invCon.swordPosList[6];
        }
        else if (Input.mousePosition.x < invCon.swordPointerList[7].x)
        {
            for (int i = 0; i < 6; i++)
            {
                if (Input.mousePosition.y < invCon.swordPointerList[i].y)
                {
                    rectTransform.anchoredPosition = invCon.swordPosList[i + 7];
                    return;
                }
            }
            rectTransform.anchoredPosition = invCon.swordPosList[13];
        }
        else if (Input.mousePosition.x < invCon.swordPointerList[14].x)
        {
            for (int i = 0; i < 6; i++)
            {
                if (Input.mousePosition.y < invCon.swordPointerList[i].y)
                {
                    rectTransform.anchoredPosition = invCon.swordPosList[i + 14];
                    return;
                }
            }
            rectTransform.anchoredPosition = invCon.swordPosList[20];
        }
        else
        {
            for (int i = 0; i < 6; i++)
            {
                if (Input.mousePosition.y < invCon.swordPointerList[i].y)
                {
                    rectTransform.anchoredPosition = invCon.swordPosList[i + 21];
                    return;
                }
            }
            rectTransform.anchoredPosition = invCon.swordPosList[27];
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
                    rectTransform.anchoredPosition = invCon.ringPosList[i];
                    return;
                }
            }
            rectTransform.anchoredPosition = invCon.ringPosList[8];
        }
        else if (Input.mousePosition.x < invCon.ringPointerList[9].x)
        {
            for (int i = 0; i < 8; i++)
            {
                if (Input.mousePosition.y < invCon.ringPointerList[i].y)
                {
                    rectTransform.anchoredPosition = invCon.ringPosList[i + 9];
                    return;
                }
            }
            rectTransform.anchoredPosition = invCon.ringPosList[17];
        }
        else if (Input.mousePosition.x < invCon.ringPointerList[18].x)
        {
            for (int i = 0; i < 8; i++)
            {
                if (Input.mousePosition.y < invCon.ringPointerList[i].y)
                {
                    rectTransform.anchoredPosition = invCon.ringPosList[i + 18];
                    return;
                }
            }
            rectTransform.anchoredPosition = invCon.ringPosList[26];
        }
        else
        {
            for (int i = 0; i < 8; i++)
            {
                if (Input.mousePosition.y < invCon.ringPointerList[i].y)
                {
                    rectTransform.anchoredPosition = invCon.ringPosList[i + 27];
                    return;
                }
            }
            rectTransform.anchoredPosition = invCon.ringPosList[35];
        }
    }

    private void CheckPos(int i)
    {
        if (objTag == "Armor")
        {

        }
        else if (objTag == "Shield")
        {

        }
        else if (objTag == "Shoe")
        {

        }
        else if (objTag == "Sword")
        {

        }
        else //ring
        {

        }
    }



    private void Update()
    {

    }
}
