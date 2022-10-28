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

    Animator _animator;
    Rigidbody2D _rigid;

    private void Awake()
    {
        _animator = visualSprite.GetComponent<Animator>();
        _rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Jump();
        Move();
    }

    private void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");

        transform.position += (new Vector3(h, 0, 0)) * Time.deltaTime * speed;
    }

    private void Jump()
    {
        Debug.Log(1);
        if (!Physics2D.Raycast(rayPos1.position, Vector2.down, transform.localScale.y / 2, Define.GroundLayer)
            || !Physics2D.Raycast(rayPos2.position, Vector2.down, transform.localScale.y / 2, Define.GroundLayer))
            return;

        Debug.Log(12312);
        if (Input.GetKeyDown(KeyCode.Space))
        {

            _rigid.AddForce(Vector3.up * jumpPower, ForceMode2D.Impulse);
        }
    }
}
