using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyAttack : EnemyBase
{
    [SerializeField] Transform target;
    public bool _isAttack = true;
    float _attackDelay = 0f;

    public UnityEvent AttackFeedBack;

    protected override void Awake()
    {
        base.Awake();
        //_animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _attackDelay -= Time.deltaTime;
        float distance = Vector3.Distance(transform.position, target.position);
        if (_attackDelay == 0 && distance <= _enemy.AttackRange())
        {
            FaceTarget();
        }
    }

    void FaceTarget()
    {
        if (target.position.x - transform.position.x < 0) // Å¸°ÙÀÌ ¿ÞÂÊ
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else // Å¸°ÙÀÌ ¿À¸¥ÂÊ
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
