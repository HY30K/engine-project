using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : EnemyBase
{
    [SerializeField] Transform target;
    EnemyMovement _enemyMoveMent;

    public bool _isAttack = false;
    public bool _isCanAttacking = true;

    public int enemyNextAttack = 0;

    Coroutine _attackingCoroutine = null;
    protected override void Awake()
    {
        base.Awake();
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
            _enemyMoveMent.speed = 0;
            _animator.SetBool("IsCanAttack", true);
            if (_isAttack && _isCanAttacking)// && !_isAttacking
            {
                if (_attackingCoroutine != null)
                {
                    StopCoroutine(_attackingCoroutine);
                }
                _attackingCoroutine = StartCoroutine("AttackingPlayer");
                _isCanAttacking = false;
            }
        }
        else
        {
            _isAttack = false;
            _animator.SetBool("IsCanAttack", false);
        }
    }

    IEnumerator AttackingPlayer()
    {
        //yield return new WaitForSeconds(_enemy.AttackDelay());
        //공격 애니메이션 실행;
        enemyNextAttack = Random.Range(1, 7);// 적 공격수가 달라지면 그에따라 변동가능
        _animator.SetInteger("IsAttack", enemyNextAttack);// 노멀공격, 스페셜 공격퍼센트 안나눠줌 : 이 부분은 수정해야될듯
        Debug.Log("공격1");
         //공격하던건 마저 실행한후 감지할지 쫓아갈지 판단해주는
        yield return new WaitForSeconds(_enemy.AttackSpeed());
        _isCanAttacking = true;
        Debug.Log("end attack");
    }
}
