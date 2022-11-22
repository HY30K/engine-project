using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] List<ItemSlot> slots = new List<ItemSlot>(); //���Ը���Ʈ

    [SerializeField] Item noneItem; //�� ������ ǥ��
    public Item NoneItem => noneItem;

    List<Item> itemList = new List<Item>(); //������ ������ ����Ʈ
    public List<Item> ItemList
    {
        get { return itemList; }
        set { itemList = value; }
    }

    public static Inventory instance = null;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        transform.GetComponentsInChildren<ItemSlot>(slots); //�κ��丮 ã�ƿ���
    }

    public void RedrawInven()
    {
        foreach (ItemSlot slot in slots)
        {
            slot.SetItem(noneItem, noneItem.ItemData.StackCount);
        }
        Debug.Log(itemList.Count);
        for (int i = 0; i < itemList.Count; i++)
        {
            foreach (ItemSlot slot in slots)
            {
                if (slot.CurrentItem.ItemData.ItemName == itemList[i].ItemData.ItemName) //�̹� ������ ���ÿ� �߰�
                    if (slot.CurrentStackCount < itemList[i].ItemData.StackCount)
                    {
                        slot.AddItem();
                        break;
                    }
                if (slot.CurrentItem.ItemData.ItemName == "NoneItem") //������ ����
                {
                    slot.SetItem(itemList[i], 1);
                    break;
                }
            }
        }
    }

    public void AddItem(Item item) //���Կ� ������ �߰��ϱ�
    {
        itemList.Add(item);
        foreach (ItemSlot slot in slots)
        {
            if (slot.CurrentItem.ItemData.ItemName == item.ItemData.ItemName) //�̹� ������ ���ÿ� �߰�
                if (slot.CurrentStackCount < item.ItemData.StackCount)
                {
                    slot.AddItem();
                    break;
                }
            if (slot.CurrentItem.ItemData.ItemName == "NoneItem") //������ ����
            {
                slot.SetItem(item, 1);
                break;
            }
        }
    }
}

