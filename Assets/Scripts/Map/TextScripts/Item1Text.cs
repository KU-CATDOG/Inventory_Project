using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item1Text : MonoBehaviour
{

    public Text item1Text;
    public ItemDropSelect itemDropSelect;

    private void Start()
    {
        switch (itemDropSelect.Item1)
        {
            case 1:
                item1Text.text = "방패(패링 데미지 증가)";
                break;
            case 2:
                item1Text.text = "검(공격력 증가)";
                break;
            case 3:
                item1Text.text = "신발(이동속도 증가)";
                break;
            case 4:
                item1Text.text = "갑옷(방어력 증가)";
                break;
            case 5:
                item1Text.text = "반지(강인함 증가)";
                break;
        }
    }
    
}
