using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Type
{
    Mineral,
    Interectable,
    None
}

[CreateAssetMenu(fileName = "ItemSO")]
public class ItemSO : ScriptableObject
{
    [SerializeField] string itemName;
    public string ItemName => itemName;

    [SerializeField] Sprite itemImage;
    public Sprite ItemImage => itemImage;

    [SerializeField] int stackCount;
    public int StackCount => stackCount;

    [SerializeField] int price;
    public int Price => price;

    [SerializeField] Type itemType;
    public Type ItemType => itemType;
}