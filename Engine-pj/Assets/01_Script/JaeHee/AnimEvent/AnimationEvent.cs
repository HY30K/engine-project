using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvent : MonoBehaviour
{
    [SerializeField] private CapsuleCollider2D hitBox;
    [SerializeField] private PlayerMove playerMove;
    [SerializeField] private BoxCollider2D playerBody;

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
        playerBody.size = new Vector2(0.75f, 0.95f);
        playerBody.offset = new Vector2(-0.02f, -0.5f);
    }


    public void EndOfRolling() //구르기가 끝날때 애니매이벤트
    {
        hitBox.enabled = true;
        playerBody.size = new Vector2(0.75f, 1.9f);
        playerBody.offset = new Vector2(-0.02f, -0.5f);
        _animator.SetBool("Roll", false);
    }

    public void Attack() //공격할 때 애니매이벤트
    {

    }
    public IEnumerator StartLanding() //착지할때 애니메
    {
        yield return null;
        yield return new WaitUntil(() => !playerMove.OnAir);
        _animator.SetBool("Land", true);
        _animator.SetBool("Jump", false);
        yield return new WaitForSeconds(0.7f);
        _animator.SetBool("Land", false);
    }
}
