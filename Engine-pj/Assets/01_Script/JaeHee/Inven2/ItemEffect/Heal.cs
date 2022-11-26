using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : ItemEffect
{
    [SerializeField] float healAmount;

    public override void Effect()
    {
        Debug.Log(GameManager.instance.Health);
        GameManager.instance.Health += healAmount;
        Debug.Log(GameManager.instance.Health);
    }
}
