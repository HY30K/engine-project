using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Purchase : MonoBehaviour
{
    public List<Item> itemList = new();
    /// <summary>
    /// 아이템 구매
    /// </summary>
    /// <param name="index">상점에 달려있는 리스트[index]번째의 아이템 구매</param>
    public void PurchaseItem(int index)
    {
        ItemDatebase.instance.SpawnItem(transform.position, itemList[index]);
    }
}
