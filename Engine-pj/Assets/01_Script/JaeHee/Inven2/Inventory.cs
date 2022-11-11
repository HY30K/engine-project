using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SEH00N
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] List<ItemSlot> slots = new List<ItemSlot>();

        private void Awake() 
        {
            transform.GetComponentsInChildren<ItemSlot>(slots);
        }

        public void AddItem(Item item)
        {
            foreach (ItemSlot slot in slots)
            {
                if (slot.CurrentItem.ItemData.ItemName == item.ItemData.ItemName)
                    if (slot.CurrentStackCount < item.ItemData.StackCount)
                    {
                        slot.AddItem();
                        break;
                    }
                if (slot.CurrentItem.ItemData.ItemName == "NoneItem")
                {
                    slot.SetItem(item);
                    break;
                }
            }
        }
    }
}
