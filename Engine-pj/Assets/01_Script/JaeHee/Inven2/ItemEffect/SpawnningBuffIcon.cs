using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnningBuffIcon : ItemEffect
{
    [Tooltip("sec")]
    [SerializeField] float time;

    public override void Effect()
    {
        BuffManager.instance.SpawnBuffIcon(transform.name, time);
    }
}
