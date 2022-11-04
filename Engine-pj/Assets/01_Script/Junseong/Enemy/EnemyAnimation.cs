using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : EnemyBase
{
    private void Awake()
    {
        
    }

    public void IsStartAttack()
    {

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
