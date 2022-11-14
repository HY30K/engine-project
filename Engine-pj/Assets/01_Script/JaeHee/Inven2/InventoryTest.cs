using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryTest : MonoBehaviour
{
    [SerializeField] Item test;

    public void IvenTest()
    {
        Inventory.instance.AddItem(test);
    }
}
