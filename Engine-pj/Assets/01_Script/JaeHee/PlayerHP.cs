using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHP : MonoBehaviour
{
    public int hp = 100;
    public UnityEvent Dead;
    [field: SerializeField] public UnityEvent OnHit { get; set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyWeapon")){

            if (hp > 0)
            {
                if (collision.transform.root.name != "FlyingEye")
                {
                    hp -= collision.transform.parent.GetComponent<EnemyAttack>().damage;
                }
                else
                {
                    hp -= collision.transform.parent.parent.GetComponent<EnemyAttack>().damage;
                    Debug.Log(collision.gameObject.name);
                    //throw new Exception("ÀÌ¹Ì Á×À½");
                }
                
            }
            else
            {
                PlayerDead();
            }
            PlayerHit();
        }
        if (collision.CompareTag("Enemy"))
        {
            if(hp > 0)
            {
                hp -= 5;
                PlayerHit();
            }
            else
            {
                PlayerDead();
            }
        }
    }

    private void PlayerHit()
    {
        OnHit.Invoke();
    }
    private void PlayerDead()
    {
        Dead?.Invoke();
    }

    public void DeadInit()
    {
        transform.parent.GetComponent<PlayerInput>().enabled = false;
        transform.parent.GetComponent<InvenActiveChange>().enabled = false;
        transform.GetComponent<CapsuleCollider2D>().enabled = false;
    }
}
