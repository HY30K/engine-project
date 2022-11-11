using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] ItemSO itemData;
    public ItemSO ItemData => itemData;

    public void UseItem(string name)
    {
        switch (name)
        {
            case "TestItem":
                //Do Someting
                Debug.Log("회복을 해요");
                break;
            default:
                Debug.LogWarning("ItemEffect doesn't exist");
                break;
        }
    }
}

