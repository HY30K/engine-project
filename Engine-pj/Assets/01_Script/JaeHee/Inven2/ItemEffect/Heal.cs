using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : ItemEffect
{
    [SerializeField] float healAmount;
    public override void Effect()
    {
        Debug.Log(PlayerProperty.instance.Health);
        PlayerProperty.instance.Health += healAmount;
        Debug.Log(PlayerProperty.instance.Health);
    }
}
