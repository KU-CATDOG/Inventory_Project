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
                item1Text.text = "����(�и� ������ ����)";
                break;
            case 2:
                item1Text.text = "��(���ݷ� ����)";
                break;
            case 3:
                item1Text.text = "�Ź�(�̵��ӵ� ����)";
                break;
            case 4:
                item1Text.text = "����(���� ����)";
                break;
            case 5:
                item1Text.text = "����(������ ����)";
                break;
        }
    }
    
}
