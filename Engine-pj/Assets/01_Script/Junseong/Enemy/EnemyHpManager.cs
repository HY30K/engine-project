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
    public bool isDead = false;

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
        state = GameObject.Find("Player").GetComponent<PlayerProperty>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            if(hp <= 0)
            {
                //state.Damage += 0.2f;
                isDead = true;
                EnemyDead();
            }
            else if (collision.CompareTag("PlayerWeapon"))
            {
                Debug.Log("+______________+");
                Debug.Log("�÷��̾� ������ : " + state.Damage);
                EnemyOnDamaged();
                hp -= state.Damage;
            }        
            else if(collision.gameObject.tag == "PlayerBody")
            {
                //hp -= player.bodyDamage;
           
                EnemyOnDamaged();
            }
        }
    }

    private void EnemyDead()
    {
        OnDie?.Invoke();// die ���� ����
        GameManager.instance.Money += 15;
    }

    public void EnemyDeadInit()
    {
        gameObject.layer = 11;
        if (isDead)
        {
            isDead = false;
            _animator.SetTrigger("IsDead");
            // die �ִϸ��̼� ����
        }
       
        if(_enemy.enemyType != EnemyType.FlyingEnemy)
        {
            GetComponent<EnemyMovement>().enabled = false;    // ���� ��Ȱ��ȭ
            //GetComponent<CapsuleCollider2D>().enabled = false; // ���� ��Ȱ��ȭ
            transform.GetChild(0).gameObject.SetActive(false); // ���� ��Ȱ��ȭ
            GetComponent<EnemyAttack>().enabled = false; // ���� ��Ȱ��ȭ

        }
        else
        {
            transform.parent.GetComponent<EnemyMovement>().enabled = false;    // ���� ��Ȱ��ȭ
            transform.parent.GetComponent<Rigidbody2D>().gravityScale = 2; // ���� ��Ȱ��ȭ
            transform.GetChild(0).gameObject.SetActive(false); // ���� ��Ȱ��ȭ
            transform.parent.GetComponent<EnemyAttack>().enabled = false; // ���� ��Ȱ��ȭ
        }
        Destroy(gameObject, 1.5f);                     // 3���� ����
        
        
        //Destroy(hpBar.gameObject, 3);               // 3���� ü�¹� ����
    }

    void EnemyOnDamaged() // OnDamaged�� �־������
    {
        OnGetHit?.Invoke(); // �´� ���� ��
    }

    public void EnemyDontDamage()
    {
        StartCoroutine("EnemyChangeLayer");
    }

    IEnumerator EnemyChangeLayer()
    {
        //transform.gameObject.layer = LayerMask.NameToLayer("EnemyDontDamage");
        gameObject.layer = 11;
        yield return new WaitForSeconds(0.2f);
        gameObject.layer = LayerMask.NameToLayer("Enemy");

    }



}
