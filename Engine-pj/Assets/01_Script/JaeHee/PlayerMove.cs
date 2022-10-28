using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float jumpPower;
    [SerializeField] float speed;

    [SerializeField] Transform rayPos1;
    [SerializeField] Transform rayPos2;

    [SerializeField] private PlayerProficiency state;
    [SerializeField] private GameObject visualSprite;

    private Animator _animator;

    private bool isJumping;

    private Rigidbody2D _rigid;

    private void Awake()
    {
        _animator = visualSprite.GetComponent<Animator>();
        _rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //_animator.SetBool("Attack", true);
        //_animator.SetBool("AttackCombo", true);
        //_animator.SetBool("Roll", true);
        //_animator.SetBool("Death", true);
        //_animator.SetBool("Land", true);

        Jump();
        Move();
    }

    private void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");

        transform.position += (new Vector3(h, 0, 0)) * Time.deltaTime * speed;
        h = 0;
        _animator.SetBool("Walk", h != 0);
    }

    private void Jump()
    {
        if (!Physics2D.Raycast(rayPos1.position, Vector2.down, transform.localScale.y / 2, Define.GroundLayer)
            || !Physics2D.Raycast(rayPos2.position, Vector2.down, transform.localScale.y / 2, Define.GroundLayer))
            return;
        if (isJumping)
        {
            _animator.SetBool("Jump", true);
            isJumping = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _animator.SetBool("Jump", true);
            isJumping = true;
            _rigid.AddForce(Vector3.up * jumpPower, ForceMode2D.Impulse);
        }
    }
}
