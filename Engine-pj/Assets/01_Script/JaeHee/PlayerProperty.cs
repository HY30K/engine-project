using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerProperty : MonoBehaviour
{
    public static PlayerProperty instance = null;

    private float jumpPower = 10; //점프파워
    private float speed = 5;
    private float damage = 1; //데미지
    private float miningSpeed = 1; //얜 왜있지
    private float evasion = 1; //방어력
    private float miningDelay = 1;

    public float JumpPower
    {
        get
        {
            if (jumpPower <= 0)
            {
                return 1;
            }
            else
            {
                return jumpPower;
            }
        }
        set { jumpPower = value; }
    }

    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    public float Damage
    {
        get { return damage; }
        set { damage = value; }
    }

    public float MiningDmg
    {
        get { return miningSpeed; }
        set { miningSpeed = value; }
    }

    public float MiningDelay
    {
        get { return miningDelay; }
        set { miningDelay = value; }
    }

    public float Evasion
    {
        get { return evasion; }
        set { evasion = value; }
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
}
