using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player/State")]
public class Pickaxe : ScriptableObject
{
    private int level;
    public int Level
    {
        get { return level; }
        set { level = value; }
    }

    private float damage = 1;
    private float attackDelay = 1;
}
