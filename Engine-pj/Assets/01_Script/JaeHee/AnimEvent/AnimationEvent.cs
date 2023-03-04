using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimationEvent : MonoBehaviour
{
    [SerializeField] private CapsuleCollider2D hitBox;
    [SerializeField] private BoxCollider2D playerBody;
    [SerializeField] private PlayerInput playerMove;

    [SerializeField] private CircleCollider2D attackCol;
    [SerializeField] private CircleCollider2D attackComboCol;

    Animator _animator;
    SpriteRenderer _spriteRenderer;

    bool attackCom;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Death() //������ ����Ǵ� �ִϸ��̺�Ʈ
    {
        _animator.SetTrigger("Death");
    }

    public void SceneReturn()
    {
        StartCoroutine("WaitingDieScene");
    }

    IEnumerator WaitingDieScene()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("GameOver");
    }

    public void RollStart() //������ �ִϸ��̺�Ʈ
    {
        hitBox.enabled = false;
        hitBox.transform.gameObject.layer = 12;
        //playerBody.size = new Vector2(0.75f, 0.95f);
        //playerBody.offset = new Vector2(-0.02f, -0.5f);
    }

    public void EndOfRolling() //�����Ⱑ ������ �ִϸ��̺�Ʈ
    {
        hitBox.enabled = true;
        //playerBody.size = new Vector2(0.75f, 1.9f);
        //playerBody.offset = new Vector2(-0.02f, -0.05f);
        hitBox.transform.gameObject.layer = 8;
        _animator.SetBool("Roll", false);
    }

    public void AttackColOn() //�ݶ����� �ѱ�
    {
        attackCol.enabled = true;
    }

    public void AttackColOff() //�ݶ��̴� �ѱ�
    {
        attackCol.enabled = false;
    }

    public void AttackComboColOn()
    {
        attackComboCol.enabled = true;
    }

    public void AttackComboColOff()
    {
        attackComboCol.enabled = false;
        attackCom = false;
        _animator.SetBool("AttackCom", false);
    }

    public IEnumerator StartLanding() //�����Ҷ� �ִϸ�
    {
        yield return new WaitUntil(() => !playerMove.OnAir);
        _animator.SetBool("Land", true);
        _animator.SetBool("Jump", false);
        yield return new WaitForSeconds(0.7f);
        _animator.SetBool("Land", false);
    }

    public void AttackStart()
    {
        attackCom = false;
    }

    public void AttackEnd()
    {
        _animator.SetBool("Attack", false);

        if (attackCom)
        {
            _animator.SetBool("AttackCom", true);
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            attackCom = true;
        }
    }
}
