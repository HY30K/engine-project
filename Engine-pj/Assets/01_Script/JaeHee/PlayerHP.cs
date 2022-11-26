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
            hp -= collision.transform.parent.GetComponent<EnemyAttack>().damage;
            if (hp <= 0)
            {
                PlayerDead();
            }
            else
            {
                OnHit?.Invoke();
            }
        }
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
