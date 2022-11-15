using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float raycastDistance = 15f;
    RaycastHit2D EnemyHit;
    RaycastHit2D MineralHit;
    bool _isHItting = false;
    Vector3 mousePos;

    [SerializeField] float jumpPower;
    [SerializeField] float speed;

    [SerializeField] Transform rayPos1;
    [SerializeField] Transform rayPos2;

    [SerializeField] private PlayerProficiency state; //Ω∫≈»

    private Animator _animator;
    private Rigidbody2D _rigid;

    private bool onAir = false;

    public bool OnAir { get => onAir; }

    [SerializeField] private float rollCoolTime = 0;
    [SerializeField] private float attackDelay = 0;

    private bool doAttack;

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
        onAir = !Physics2D.Raycast(rayPos1.position, Vector2.down, transform.localScale.y / 2, Define.Plane | Define.Mineral)
            || !Physics2D.Raycast(rayPos2.position, Vector2.down, transform.localScale.y / 2, Define.Plane | Define.Mineral);
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
            Debug.Log("'±∏∏•¥Ÿ'");
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

    #region √§±§∫Œ∫–
    public void DoMining()
    {
        if (Input.GetMouseButton(0))
        {
            mousePos = Input.mousePosition;
            mousePos = Define.MainCam.ScreenToWorldPoint(mousePos);
            mousePos.z = 0;

            MineralHit = Physics2D.Raycast(transform.position, (mousePos - transform.position), raycastDistance, Define.Mineral);

            if (MineralHit)
            {
                _animator.SetBool("Mine", true);
            }
            else
            {
                _animator.SetTrigger("Attack");
            }

            Debug.DrawRay(transform.position, (mousePos - transform.position), Color.red, 0.5f);
            if (MineralHit && !_isHItting)
            {
                _animator.SetBool("Mine", true);
                _isHItting = true;
                StartCoroutine("HitMineral");
                Debug.Log("HIt");
                //hit.transform.GetComponent<SpriteRenderer>().color = Color.blue;
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            _animator.SetBool("Mine", false);
            _isHItting = false;
            StopCoroutine("HitMineral");
        }
    }

    IEnumerator HitMineral()
    {
        yield return new WaitForSeconds(1f);

        while (MineralHit)
        {
            MineralHit.collider.gameObject.GetComponent<MineralScript>().hp -= 1;// 1∫Œ∫–¿ª «√∑π¿ÃæÓ ∞Ó±™¿Ã¿« µ•πÃ¡ˆ∑Œ πŸ≤„¡‡æﬂ«‘;
            Debug.Log($"±§ºÆ ¿Ã∏ß : {MineralHit.collider.gameObject.GetComponent<MineralScript>().MineralType}, hp : {MineralHit.collider.gameObject.GetComponent<MineralScript>().hp}");
            yield return new WaitForSeconds(0.5f);
        }
    }
    #endregion
}
