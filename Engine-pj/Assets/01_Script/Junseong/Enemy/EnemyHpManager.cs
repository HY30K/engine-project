using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHpManager : EnemyBase
{
    int hp;
    int damage;

    //[SerializeField]
    //Animator _animator;

    protected override void Awake()
    {
        base.Awake();
        this.hp = _enemy.HP();
        this.damage = _enemy.Damage();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerWeapon")
        {
            //hp -= player.damage; 
            EnemyOnDamaged();
        }        
        if(collision.gameObject.tag == "PlayerBody")
        {
            //hp -= player.bodyDamage;
            EnemyOnDamaged();
        }
        if(hp <= 0)
        {
            EnemyDead();
        }
    }

    private void EnemyDead()
    {
        _animator.SetTrigger("IsDead");            // die 애니메이션 실행
        GetComponent<EnemyMovement>().enabled = false;    // 추적 비활성화
        GetComponent<CapsuleCollider2D>().enabled = false; // 몸통 비활성화
        GetComponent<BoxCollider2D>().enabled = false; // 무기 비활성화
        GetComponent<EnemyAttack>().enabled = false; // 공격 비활성화
        Destroy(GetComponent<Rigidbody2D>());       // 중력 비활성화
        Destroy(gameObject, 1.5f);                     // 3초후 제거
        //Destroy(hpBar.gameObject, 3);               // 3초후 체력바 제거;
    }

    void EnemyOnDamaged() // OnDamaged에 넣어줘야함
    {
        _animator.SetTrigger("IsHit");
    } 

}
