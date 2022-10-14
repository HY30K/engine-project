using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : EnemyBase
{
    [SerializeField] Transform target;
    EnemyMovement _enemyMoveMent;

    public bool _isAttack = false;
    public bool _isAttacking = false;

    Coroutine _attackingCoroutine = null;
    void Awake()
    {
        _enemyMoveMent = GetComponent<EnemyMovement>();
    }

    private void Update()
    {
        if (_enemyMoveMent._isCanDetectAttacking)
        {
            AttackPlayer();
        }
    }

    public void AttackPlayer()
    {
        if (Vector2.Distance(transform.position, target.position) <= _enemy.AttackRange())
        {
            Debug.Log(Vector2.Distance(transform.position, target.position));
            _isAttack = true;
            if (_isAttack)// && !_isAttacking
            {
                _enemyMoveMent.speed = 0;
                if (_attackingCoroutine != null)
                {
                    StopCoroutine(_attackingCoroutine);
                }
                _attackingCoroutine = StartCoroutine("AttackingPlayer");
            }
        }
        else
        {
            _isAttack = false;
        }
    }

    IEnumerator AttackingPlayer()
    {
        //yield return new WaitForSeconds(_enemy.AttackDelay());
        //공격 애니메이션 실행;
        Debug.Log("공격1");
        _isAttacking = true; //공격하던건 마저 실행한후 감지할지 쫓아갈지 판단해주는
        yield return new WaitForSeconds(_enemy.AttackSpeed());
        _isAttacking = false;
        Debug.Log("end attack");
    }
}
