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
        _animator.SetTrigger("IsDead");            // die �ִϸ��̼� ����
        GetComponent<EnemyMovement>().enabled = false;    // ���� ��Ȱ��ȭ
        GetComponent<CapsuleCollider2D>().enabled = false; // ���� ��Ȱ��ȭ
        GetComponent<BoxCollider2D>().enabled = false; // ���� ��Ȱ��ȭ
        GetComponent<EnemyAttack>().enabled = false; // ���� ��Ȱ��ȭ
        Destroy(GetComponent<Rigidbody2D>());       // �߷� ��Ȱ��ȭ
        Destroy(gameObject, 1.5f);                     // 3���� ����
        //Destroy(hpBar.gameObject, 3);               // 3���� ü�¹� ����;
    }

    void EnemyOnDamaged() // OnDamaged�� �־������
    {
        _animator.SetTrigger("IsHit");
    } 

}
