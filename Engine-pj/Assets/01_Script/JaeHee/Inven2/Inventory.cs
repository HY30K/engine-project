using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] List<ItemSlot> slots = new List<ItemSlot>();

    public static Inventory instance = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        Debug.Log(transform.name);
        transform.GetComponentsInChildren<ItemSlot>(slots);
    }

    public bool AddItem(Item item)
    {
        foreach (ItemSlot slot in slots)
        {
            if (slot.CurrentItem.ItemData.ItemName == item.ItemData.ItemName)
                if (slot.CurrentStackCount < item.ItemData.StackCount)
                {
                    slot.AddItem();
                    return true;
                }
            if (slot.CurrentItem.ItemData.ItemName == "NoneItem")
            {
                slot.SetItem(item);
                return true;
            }
        }
        return false;
    }
}

