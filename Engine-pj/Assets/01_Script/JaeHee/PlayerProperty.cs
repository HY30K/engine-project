using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProperty : MonoBehaviour
{
    public static PlayerProperty instance = null;

    private float jumpPower = 1; //점프파워
    private float damage = 1; //데미지
    private float health = 1; //체력
    private float miningSpeed = 1; //얜 왜있지
    private float evasion = 1; //방어력

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

    public float Damage
    {
        get { return damage; }
        set { damage = value; }
    }

    public float Health
    {
        get { return health; }
        set { health = value; }
    }

    public float MininngSpeed
    {
        get { return miningSpeed; }
        set { miningSpeed = value; }
    }

    public float Evasion
    {
        get { return evasion; }
        set { evasion = value; }
    }

    private void Awake()
    {
        instance = this;
    }
}
