using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyAttack : EnemyBase
{
    [SerializeField] Transform target;
    public bool _isAttack = false;
    public bool _isAttacking = false;
    public bool canAttack = true;
    public bool _isAfterAttack = false;
    public bool endAttacking = true;
    public float _attackDelay = 0f;

    public int afterAttackMove = 0;

    public UnityEvent AttackFeedBack;

    EnemyMovement enemyMovement;

    protected override void Awake()
    {
        base.Awake();
        enemyMovement = GetComponent<EnemyMovement>();
    }

    private void Update()
    {
        Debug.Log($"�������ΰ��� : {_isAttacking}");
        if (endAttacking)
        {
            _attackDelay -= Time.deltaTime;
        }
        if (_attackDelay < 0f) _attackDelay = 0;

        //if (_animator.GetCurrentAnimatorStateInfo(0).IsName("canAttack"))
        //{
        //    _isAttacking = true;
        //}
       // else _isAttacking = false;
        float distance = Vector3.Distance(transform.position, target.position);

        if (distance <= _enemy.AttackRange())
        {
            enemyMovement.nextMove = 0;
            enemyMovement._isThinking = false;
            enemyMovement.nextMove = 0;
            afterAttackMove = (target.position.x - transform.position.x < 0) ? -1 : 1;
            _isAttack = true;
            if(_attackDelay == 0)
            {
                EnemyAttacking();
                canAttack = true;
                _isAttacking = true;
                endAttacking = false;
                _isAfterAttack = true;
            }
            else
            {
                canAttack = false;
                _isAfterAttack=false;
                enemyMovement.FaceTarget();
                Debug.Log("���ư��پƤ��ƾƾƾƾƾƤ��ƾ�");
            }

        }
        else if(distance > _enemy.AttackRange())
        {
            enemyMovement._isThinking = true;
            _isAttack = false;
            if (_isAfterAttack)
            {
                enemyMovement.nextMove = afterAttackMove;
                _isAfterAttack=false;
            }
        }
    }

    private void EnemyAttacking()
    {
        AttackFeedBack?.Invoke();// ���ݽ� ȿ�������� �־��ֱ�
        int randAttack = UnityEngine.Random.Range(1, 5);
        _animator.SetInteger("Attack", randAttack);
        _animator.SetTrigger("canAttack");
        Debug.Log("randAttack : " + randAttack);
        _attackDelay = _enemy.AttackDelay();
        Debug.Log("endAttack");
    }

    public void EndAttacking()
    {
        Debug.Log("������ �������ϴ�");
        endAttacking = true;
        _isAttacking = false;
    }
}
