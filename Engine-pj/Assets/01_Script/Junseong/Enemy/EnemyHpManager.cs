using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHpManager : EnemyBase
{
    public float hp;
    //int damage;
    PlayerProperty state;
    PlayerInput player;

    #region ���� �÷���(����Ƽ�̺�Ʈ)
    [field: SerializeField] public UnityEvent OnDie { get; set; }
    [field: SerializeField] public UnityEvent OnGetHit { get; set; }
    #endregion
    //[SerializeField]
    //Animator _animator;

    protected override void Awake()
    {
        base.Awake();
        this.hp = _enemy.HP();
        //this.damage = _enemy.Damage();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerWeapon")
        {
            hp -= state.Damage;
            EnemyOnDamaged();
        }        
        if(collision.gameObject.tag == "PlayerBody")
        {
            //hp -= player.bodyDamage;
           
            EnemyOnDamaged();
        }
        if(hp <= 0)
        {
            state.Damage += 0.2f;
            EnemyDead();
        }
    }

    private void EnemyDead()
    {
        OnDie?.Invoke();                            // die ���� ����
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
        OnGetHit?.Invoke(); // �´� ���� ����
        _animator.SetTrigger("IsHit");
    } 

}
