using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseMaxHP : ItemEffect
{
    [SerializeField] float amount;
    public override void Effect()
    {
        GameManager.instance.MaxHealth = amount;
    }
}
