using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMethods : MonoBehaviour
{
    private int level = 1;
    public int Level
    {
        get { return level; }
    }

    private float price = 10;

    private float increaseDamage = 0.45f;

    private float increaseAttackDelay = 0.045f;

    public void UpgradeBtnClick()
    {
        if (GameManager.instance.Money >= price)
        {

            price += 166;
            PlayerProperty.instance.Damage += increaseDamage;
            PlayerProperty.instance.MiningDelay -= increaseAttackDelay;
            level++;
        }
    }
}
