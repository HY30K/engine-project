using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float raycastDistance = 15f;
    RaycastHit2D hit;
    bool _isHItting = false;
    Vector3 mousePos;

    [SerializeField] float jumpPower;
    [SerializeField] float speed;

    [SerializeField] Transform rayPos1;
    [SerializeField] Transform rayPos2;

    [SerializeField] private PlayerProficiency state; //스탯

    private Animator _animator;
    private Rigidbody2D _rigid;

    private bool onAir = false;

    public bool OnAir { get => onAir; }

    [SerializeField] private float rollCoolTime = 0;
    [SerializeField] private float attackDelay = 0;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _rigid = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        StartCoroutine(Roll());
    }

    private void Update()
    {
        onAir = !Physics2D.Raycast(rayPos1.position, Vector2.down, transform.localScale.y / 2, Define.Plane)
            || !Physics2D.Raycast(rayPos2.position, Vector2.down, transform.localScale.y / 2, Define.Plane);
        Jump();
        Move();
        DoMining();
    }

    IEnumerator Roll()
    {
        while (true)
        {
            yield return null;
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.LeftShift) && !onAir);
            Debug.Log("'구른다'");
            _animator.SetBool("Roll", true);

            yield return new WaitForSeconds(rollCoolTime);
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
        if (onAir)
            return;

        _animator.SetBool("Jump", false);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _animator.SetBool("Land", false);
            _animator.SetBool("Jump", true);
            _rigid.AddForce(Vector3.up * jumpPower, ForceMode2D.Impulse);
        }
    }

    public void DoMining()// 플레이어에서 불러와줘야함
    {
        if (Input.GetMouseButton(0))
        {
            mousePos = Input.mousePosition;
            mousePos = Define.MainCam.ScreenToWorldPoint(mousePos);
            mousePos.z = 0;

            hit = Physics2D.Raycast(transform.position, (mousePos - transform.position), raycastDistance, Define.Mineral | Define.Enemy);

            Debug.DrawRay(transform.position, (mousePos - transform.position), Color.red, 0.5f);
            if (hit && !_isHItting)
            {
                _isHItting = true;
                StartCoroutine("HitMineral");
                Debug.Log("HIt");
                //hit.transform.GetComponent<SpriteRenderer>().color = Color.blue;
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            _isHItting = false;
            StopCoroutine("HitMineral");
            //hit = null;
        }
    }

    IEnumerator HitMineral()
    {
        yield return new WaitForSeconds(1f);

        while (hit)
        {
            hit.collider.gameObject.GetComponent<MineralScript>().hp -= 1;// 1부분을 플레이어 곡괭이의 데미지로 바꿔줘야함;
            Debug.Log($"광석 이름 : {hit.collider.gameObject.GetComponent<MineralScript>().MineralType}, hp : { hit.collider.gameObject.GetComponent<MineralScript>().hp}");
            yield return new WaitForSeconds(0.5f);                                                              // 
        }
    }
}
