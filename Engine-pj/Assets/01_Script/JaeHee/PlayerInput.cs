using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    public float raycastDistance = 15f;
    RaycastHit2D EnemyHit;
    RaycastHit2D MineralHit;
    bool _isHItting = false;
    Vector3 mousePos;

    [SerializeField] Transform rayPos1;
    [SerializeField] Transform rayPos2;

    private Animator _animator;
    private Rigidbody2D _rigid;

    private bool onAir = false;

    public bool OnAir { get => onAir; }

    [SerializeField] private float rollCoolTime = 0;

    public bool canParticleSpawn = false;
    public bool particleWaiting = true;
    public bool isOnGround = false;
    public bool isOnMineral = false;
    public bool isMining = false;

    private bool groundCheck;

    MiningParticle miningParticle;

    private Vector3 curretMiningMinePos;
    #region ���� �÷���(����Ƽ�̺�Ʈ)
    [field: SerializeField] public UnityEvent OnMine { get; set; }
    [field: SerializeField] public UnityEvent OnGroundWalk { get; set; }
    [field: SerializeField] public UnityEvent OnMineralWalk { get; set; }
    #endregion

    SpriteRenderer spriteRenderer;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        StartCoroutine(Roll());
    }

    private void Update()
    {
        onAir = !Physics2D.Raycast(rayPos1.position, Vector2.down, transform.localScale.y / 2, Define.Plane | Define.Mineral | Define.DungeonGround)
            || !Physics2D.Raycast(rayPos2.position, Vector2.down, transform.localScale.y / 2, Define.Plane | Define.Mineral | Define.DungeonGround);
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
            _animator.SetBool("Roll", true);

            yield return new WaitForSeconds(rollCoolTime);
        }
    }

    private void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");

        transform.position += (new Vector3(h, 0, 0)) * Time.deltaTime * PlayerProperty.Instance.Speed;

        if (h == 0)
        {
            _animator.SetBool("Walk", false);
            _isMoving = false;
        }
        else
        {
            _animator.SetBool("Walk", true);
            _isMoving = true;
        }

        if (h > 0)
        {
            transform.localScale = new Vector2(-1, 1);
        }

        else if (h < 0)
        {
            transform.localScale = new Vector2(1, 1);
        }

        RaycastHit2D ground = Physics2D.Raycast(transform.position, Vector2.down, (transform.localScale.y / 2) + 0.5f, Define.Plane | Define.Mineral);
        RaycastHit2D DungeonGround = Physics2D.Raycast(rayPos1.position, Vector2.down, (transform.localScale.y / 2) + 0.5f, Define.Mineral | Define.DungeonGround);

        if (!ground && !onAir)
        {
            isOnGround = false;
            isOnMineral = true;
            OnMineralWalk?.Invoke();
        }
        else if (DungeonGround && !onAir)
        {
            isOnGround = true;
            isOnMineral = false;
        }

        if (isOnGround && !_isMoving)
        {
            OnMineralWalk?.Invoke();
        }
        else if (isOnMineral && !_isMoving)
        {

            OnGroundWalk?.Invoke();
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
            _rigid.AddForce(Vector3.up * PlayerProperty.Instance.JumpPower, ForceMode2D.Impulse);
        }
    }

    int cnt = 0;
    private bool _isMoving;
    #region ä���κ�
    public void DoMining()
    {
        if (Input.GetMouseButton(0))
        {
            mousePos = Input.mousePosition;
            mousePos = Define.MainCam.ScreenToWorldPoint(mousePos);
            mousePos.z = 0;

            //FaceDirection(mousePos);

            MineralHit = Physics2D.Raycast(transform.position, (mousePos - transform.position), raycastDistance, Define.Mineral);
            EnemyHit = Physics2D.Raycast(transform.position, (mousePos - transform.position), raycastDistance, Define.Enemy);

            if (MineralHit)
            {
                _animator.SetBool("Mine", true);
                _animator.SetBool("Attack", false);
            }
            else
            {
                _animator.SetTrigger("Attack");
            }

            if (EnemyHit)
            {
                _animator.SetTrigger("Attack");
                _animator.SetBool("Mine", false);
            }

            Vector3 dir = (mousePos - transform.position);
            dir = dir.normalized;

            Debug.DrawRay(transform.position, dir * raycastDistance, Color.red, 0.5f);

            if (MineralHit)
            {
                if (groundCheck)
                {
                    miningParticle = PoolManager.Instance.Pop($"Mining{MineralHit.transform.GetComponent<MineralScript>().itemName}") as MiningParticle;
                    Debug.Log($"Mining{MineralHit.transform.GetComponent<MineralScript>().itemName}");
                    //if (MineralHit.transform.GetComponent<MineralScript>().MineralType == MineralType.Ground)
                    //{
                    //    miningParticle = PoolManager.Instance.Pop("MiningGround") as MiningParticle;
                    //}
                    //else
                    //{
                    //    miningParticle = PoolManager.Instance.Pop("MiningOre") as MiningParticle;
                    //}
                    groundCheck = false;
                }

                if (curretMiningMinePos != MineralHit.transform.position)
                {
                    groundCheck = true;
                    if (miningParticle != null) miningParticle.DestroyMiningParticle();
                }
                else
                {
                    Debug.Log("������ �Ĵ£O");
                }

                if (miningParticle != null)
                {
                    miningParticle.SetPositionAndRotation(MineralHit.transform.position, Quaternion.identity);
                }

                if (!_isHItting)
                {
                    _animator.SetBool("Mine", true);
                    _isHItting = true;
                    StartCoroutine("HitMineral");
                }
                else
                {
                    curretMiningMinePos = MineralHit.transform.position;
                }
            }
            else
            {
                if (miningParticle != null) miningParticle.DestroyMiningParticle();
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            _animator.SetBool("Mine", false);
            canParticleSpawn = false;
            particleWaiting = true;
            _isHItting = false;

            StopCoroutine("HitMineral");
            if (miningParticle != null)
                miningParticle.DestroyMiningParticle();
        }
    }

    IEnumerator HitMineral()
    {
        Debug.Log($"mineral cnt : { cnt++}");
        //miningParticle.enabled = false;
        yield return new WaitForSeconds(0.5f);
        //canParticleSpawn = true;
        while (MineralHit)
        {
            OnMine?.Invoke();
            //miningParticle.enabled = true;
            MineralHit.collider.gameObject.GetComponent<MineralScript>().hp -= PlayerProperty.Instance.Damage;// 1�κ��� �÷��̾� ����� �������� �ٲ������;
            //Debug.Log($"���� ���� : {MineralHit.collider.gameObject.GetComponent<MineralScript>().MineralType}");
            //Debug.Log($"���� �̸� : {MineralHit.collider.gameObject.GetComponent<MineralScript>().MineralType}, hp : {MineralHit.collider.gameObject.GetComponent<MineralScript>().hp}");
            Debug.Log("�Ǳ�¤���");
            yield return new WaitForSeconds(PlayerProperty.Instance.MiningDelay);
        }
    }
    #endregion

    public void FaceDirection(Vector2 pointerInput)
    {
        Vector3 direction = (Vector3)pointerInput - transform.position;
        Vector3 result = Vector3.Cross(Vector2.up, direction);

        spriteRenderer.flipX = result.z > 0;
    }
}
