using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvent : MonoBehaviour
{
    [SerializeField] private CapsuleCollider2D hitBox;
    Animator _animator;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    public void Death()//죽으면 실행되는 애니매이벤트
    {

    }

    public void RollStart() //구를때 애니매이벤트
    {
        hitBox.enabled = false;
    }
    public void EndOfRolling() //구르기가 끝날때 애니매이벤트
    {
        hitBox.enabled = true;
        _animator.SetBool("Roll", false);
    }

    public void Attack() //공격할 때 애니매이벤트
    {

    }
}
