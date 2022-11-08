using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Potion,
    Mineral
}

[System.Serializable]
public class Item
{
    public ItemType Type;
    public string name;
    public Sprite image;
    public List<UseItem> useItems;

    public bool Use()
    {
        bool isUsed = false;
        foreach (UseItem uses in useItems)
        {
            isUsed = uses.ExecuteRole();
        }
        isUsed = true;
        return isUsed;
    }
}
