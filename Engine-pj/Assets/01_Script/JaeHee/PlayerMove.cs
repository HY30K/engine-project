using System;
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

    private Animator _animator;
    private Rigidbody2D _rigid;
    private BoxCollider2D _boxCol;
    private CapsuleCollider2D _hitCol;

    bool OnAir = false;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _rigid = GetComponent<Rigidbody2D>();
        _boxCol = GetComponent<BoxCollider2D>();
        _hitCol = GetComponent<CapsuleCollider2D>();
    }

    private void Start()
    {
        StartCoroutine(Roll());
    }

    private void Update()
    {
        OnAir = !Physics2D.Raycast(rayPos1.position, Vector2.down, transform.localScale.y / 2, Define.GroundLayer)
            || !Physics2D.Raycast(rayPos2.position, Vector2.down, transform.localScale.y / 2, Define.GroundLayer);

        Jump();
        Move();
    }

    IEnumerator Roll()
    {
        while (true)
        {
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.LeftShift) && !OnAir);

            _animator.SetBool("Roll", true);
            _hitCol.enabled = false;
            //_rigid.AddForce();
            yield return null;
        }
    }

    private void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");

        transform.position += (new Vector3(h, 0, 0)) * Time.deltaTime * speed;

        if (h == 0)
            _animator.SetBool("Walk", false);
        else
            _animator.SetBool("Walk", true);

        if (h > 0)
        {
            transform.localScale = new Vector2(-1, 1);
        }
        else if (h < 0)
        {
            transform.localScale = new Vector2(1, 1);
        }
    }

    private void Jump()
    {
        if (OnAir)
            return;

        _animator.SetBool("Land", true);
        _animator.SetBool("Jump", false);
        StartCoroutine(Land());

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _animator.SetBool("Jump", true);
            _rigid.AddForce(Vector3.up * jumpPower, ForceMode2D.Impulse);
        }
    }

    IEnumerator Land()
    {
        yield return new WaitForSeconds(0.1f);
        _animator.SetBool("Land", false);
    }
}
