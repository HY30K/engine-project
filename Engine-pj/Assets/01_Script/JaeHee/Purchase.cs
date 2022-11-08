using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Purchase : MonoBehaviour
{
    public List<Item> itemList = new();
    /// <summary>
    /// ������ ����
    /// </summary>
    /// <param name="index">������ �޷��ִ� ����Ʈ[index]��°�� ������ ����</param>
    public void PurchaseItem(int index)
    {
        ItemDatebase.instance.SpawnItem(transform.position, itemList[index]);
    }
}
