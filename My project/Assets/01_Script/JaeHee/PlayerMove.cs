using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float jumpPower;
    [SerializeField] float speed;


    [SerializeField] private PlayerProficiency state;
    
    bool isJump = true;

    Rigidbody2D _rigid;

    Collider2D hit;

    private void Awake()
    {
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

        transform.position += (new Vector3(h, 0, 0)) * Time.deltaTime * speed ;
    }

    private void Jump()
    {
        isJump = false;

        hit = Physics2D.OverlapBox(transform.position, new Vector2(1, 1), 0, LayerMask.GetMask("Ground"));

        if (hit != null)
        {
            isJump = true;
        }

        if (!isJump) return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigid.AddForce(Vector3.up * jumpPower, ForceMode2D.Impulse);
        }
    }


}
