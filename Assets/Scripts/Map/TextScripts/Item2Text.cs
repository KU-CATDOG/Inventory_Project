using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item2Text : MonoBehaviour
{

    public Text item2Text;
    public ItemDropSelect itemDropSelect;

    private void Start()
    {
        switch (itemDropSelect.Item2)
        {
            case 1:
                item2Text.text = "����(�и� ������ ����)";
                break;
            case 2:
                item2Text.text = "��(���ݷ� ����)";
                break;
            case 3:
                item2Text.text = "�Ź�(�̵��ӵ� ����)";
                break;
            case 4:
                item2Text.text = "����(���� ����)";
                break;
            case 5:
                item2Text.text = "����(������ ����)";
                break;
        }

    }
}
    