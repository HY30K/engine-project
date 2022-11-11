using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryTest : MonoBehaviour
{
    [SerializeField] Item test;

    public void IvenTest()
    {
        bool a = Inventory.instance.AddItem(test);
    }
}
