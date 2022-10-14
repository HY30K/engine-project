using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProficiency : MonoBehaviour
{
    //점프킹
    private float jumpPower = 1;
    //쳐 킹
    private float damage = 1;
    //쳐먹킹
    private float health = 1;
    //광질킹
    private float miningSpeed = 1;
    //쳐맞킹
    private float evasion = 1;


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
}
