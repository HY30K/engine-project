using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : PoolAbleMono
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

    public override void Init()
    {
        
    }
}

