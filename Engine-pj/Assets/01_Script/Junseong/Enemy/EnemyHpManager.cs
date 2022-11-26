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

    #region 사운드 플레이(유니티이벤트)
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
        if (collision.CompareTag("PlayerWeapon"))
        {
            Debug.Log("+______________+");
            Debug.Log("플레이어 데미지 : " + state.Damage);
            EnemyOnDamaged();
            hp -= state.Damage;
        }        
        if(collision.gameObject.tag == "PlayerBody")
        {
            //hp -= player.bodyDamage;
           
            EnemyOnDamaged();
        }
        if(hp <= 0)
        {
            //state.Damage += 0.2f;
            EnemyDead();
        }
    }

    private void EnemyDead()
    {
        OnDie?.Invoke();                            // die 사운드 실행
        _animator.SetTrigger("IsDead");            // die 애니메이션 실행
        GetComponent<EnemyMovement>().enabled = false;    // 추적 비활성화
        GetComponent<CapsuleCollider2D>().enabled = false; // 몸통 비활성화
        transform.GetChild(0).gameObject.SetActive(false); // 무기 비활성화
        GetComponent<EnemyAttack>().enabled = false; // 공격 비활성화
        Destroy(gameObject, 1.5f);                     // 3초후 제거
        //Destroy(hpBar.gameObject, 3);               // 3초후 체력바 제거;
    }

    void EnemyOnDamaged() // OnDamaged에 넣어줘야함
    {
        OnGetHit?.Invoke(); // 맞는 사운드 실
    } 

}
