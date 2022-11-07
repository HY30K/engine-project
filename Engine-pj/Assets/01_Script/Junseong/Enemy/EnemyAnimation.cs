using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : EnemyBase
{
    //[SerializeField]
    //Animator _animator;

    EnemyAttack enemyAttack;
    EnemyMovement enemyMovement;

    protected override void Awake()
    {
        base.Awake();
        enemyAttack = gameObject.transform.parent.GetComponentInChildren<EnemyAttack>();
        enemyMovement = gameObject.transform.parent.GetComponentInChildren<EnemyMovement>();
    }

    public void IsStartAttack()
    {

    }

    public void IsEndAttack()
    {
        enemyAttack.endAttacking = true;
        enemyAttack._isAttacking = false;
    }
    public void IsEnemyDead()
    {

    }

    public void PlayDeadAnimation()
    {
        
    }
    public void Idle()
    {
        _animator.SetBool("moving", false);
    }
    public void Run()
    {
        _animator.SetBool("moving", true);
    }

    public void TakeHit()
    {
        _animator.SetTrigger("TakeHit");
    }
}
