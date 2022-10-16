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
        //���� �ִϸ��̼� ����;
        enemyNextAttack = Random.Range(1, 7);// �� ���ݼ��� �޶����� �׿����� ��������
        _animator.SetInteger("IsAttack", enemyNextAttack);// ��ְ���, ����� �����ۼ�Ʈ �ȳ����� : �� �κ��� �����ؾߵɵ�
        Debug.Log("����1");
         //�����ϴ��� ���� �������� �������� �Ѿư��� �Ǵ����ִ�
        yield return new WaitForSeconds(_enemy.AttackSpeed());
        _isCanAttacking = true;
        Debug.Log("end attack");
    }
}
