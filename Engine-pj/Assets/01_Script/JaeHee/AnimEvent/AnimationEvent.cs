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
    public void Death()//������ ����Ǵ� �ִϸ��̺�Ʈ
    {

    }

    public void RollStart() //������ �ִϸ��̺�Ʈ
    {
        hitBox.enabled = false;
    }
    public void EndOfRolling() //�����Ⱑ ������ �ִϸ��̺�Ʈ
    {
        hitBox.enabled = true;
        _animator.SetBool("Roll", false);
    }

    public void Attack() //������ �� �ִϸ��̺�Ʈ
    {

    }
}
