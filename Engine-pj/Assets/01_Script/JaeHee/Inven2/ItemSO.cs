using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemSO")]
public class ItemSO : ScriptableObject
{
    [SerializeField] string itemName;
    public string ItemName => itemName;

    [SerializeField] Sprite itemImage;
    public Sprite ItemImage => itemImage;

    [SerializeField] int stackCount;
    public int StackCount => stackCount;
}

