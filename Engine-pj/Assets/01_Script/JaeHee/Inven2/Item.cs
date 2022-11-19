using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] ItemSO itemData;
    public ItemSO ItemData => itemData;

    [SerializeField] ItemEffect[] effect;

    public void Use()
    {
        for (int i = 0; i < effect.Length; i++)
        {
            effect[i].Effect();
        }
    }
}

