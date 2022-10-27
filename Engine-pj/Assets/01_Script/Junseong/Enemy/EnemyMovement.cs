using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : EnemyBase
{
    public float speed;
    public float afterNoChasingTime = 0f;

    Vector2 dir;
    Vector2 origin;
    public Transform target;

    public LayerMask layerMask;
    //LayerMask collisionAfterChangeDirLayer;
    Rigidbody2D _rigid;

    public int nextMove = 0;
    public float randThinkTime = 5f;

    //enemyState
    public bool _isThinking;
    public bool _isChasing;
    public bool _isCanDetectAttacking;

    Coroutine runningCoroutine = null;
    RaycastHit2D detectPlayer;

    EnemyAttack _enemyAttack;

    protected override void Awake()
    {
        base.Awake();
        this.speed = _enemy.BeforeDetectSpeed();
        _rigid = GetComponent<Rigidbody2D>();
        _transform = GetComponent<Transform>();
        _enemyAttack = GetComponent<EnemyAttack>();
        //nextMove = Random.Range(-1,2);

        while (nextMove == 0)
        {
            nextMove = Random.Range(1, 2);
        }

        _isThinking = true;
        _isChasing = false;
        _isCanDetectAttacking = false;
    }

    private void Update()
    {
        Debug.Log(nextMove);
        _rigid.velocity = new Vector2(nextMove * speed, _rigid.velocity.y);
        
        //뒤집기
        if(nextMove == -1)
        {
            transform.rotation = Quaternion.Euler(0, -180, 0);
        }
        if(nextMove == 1)
        {
            transform.rotation = Quaternion.identity;
        }

        dir = nextMove >= 0 ? Vector2.right : Vector2.left;
        origin = (Vector2)transform.position + (nextMove >= 0 ? Vector2.right : Vector2.left);
        if (_isThinking)
        {
            if (nextMove != 0 && !_enemyAttack._isAttack)
            {
                _animator.SetBool("IsRun", true);
            }
            else if (nextMove == 0 && !_isChasing)
            {
                speed = 0;
                _animator.SetBool("IsRun", false);
            }

            if (_isChasing && !_enemyAttack._isAttack)
            {
                speed = _enemy.AfterDetectSpeed();
                //_isCanDetectAttacking = true;
                afterNoChasingTime = 0;
            }
            if (!_isChasing)
            {
                if (nextMove != 0)
                {
                    speed = _enemy.BeforeDetectSpeed();
                }
                //_isCanDetectAttacking = false;
                PlatformCheck();
                afterNoChasingTime += Time.deltaTime;
                if (afterNoChasingTime > randThinkTime)
                {
                    afterNoChasingTime = 0;
                    EnemyThink();
                }
            }
            //else if (_isChasing && _enemyAttack._isAttack)
            //{
            //    speed = 0;
            //}
           
            if (_enemyAttack._isAttack)
            {
                //_animator.SetBool("IsRun", false);
            }
            DetectPlayer();
        }

        //print(Random.Range(-1, 2));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            nextMove = -nextMove;
            afterNoChasingTime = Random.Range(0f, 1f);//벽충돌후 적 생각쿨타임
        }
    }

    public void FaceTarget()
    {
        if(target.position.x - transform.position.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, -180, 0);
        }
        else if( target.position.y - transform.position.y > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    public void EnemyThink()
    {
        Debug.Log("ENemyTHinkOpen");
        nextMove = Random.Range(-1, 2);
        print(nextMove);
        if (nextMove != 0)
        {
            randThinkTime = Random.Range(4f, 5f);
        }
        else
        {
            randThinkTime = Random.Range(1f, 2f);
            afterNoChasingTime = 0;
            if (afterNoChasingTime < randThinkTime)
            {
                afterNoChasingTime += Time.deltaTime;
            }
            else if (afterNoChasingTime > randThinkTime)
            {
                EnemyThink();
            }
        }

        //if(runningCoroutine != null)
        //{
        //    StopCoroutine(runningCoroutine);
        //}

        //runningCoroutine = StartCoroutine(EnemyNextThinkTime(randThinkTime));
    }

    //IEnumerator EnemyNextThinkTime(float randThinkTime)
    //{
    //    Debug.Log($"들어왔따 : { randThinkTime }");
    //    yield return new WaitForSeconds(randThinkTime);
    //    _isThinking = true;
    //    _AfterChaseThink=true;
    //}

    void DetectPlayer()
    {
        //detectPlayer[0] = Physics2D.Raycast(origin, dir + (Vector2.up + dir * 7) / 8, _enemy.DetectRange(), layerMask);// 6은 플레이어 레이어
        //detectPlayer[1] = Physics2D.Raycast(origin, dir, _enemy.DetectRange(), layerMask);
        //detectPlayer[2] = Physics2D.Raycast(origin, dir + (Vector2.down + dir * 7) / 8, _enemy.DetectRange(), layerMask);
        //DrawRays();

        detectPlayer = Physics2D.Raycast(origin, dir, _enemy.DetectRange(), layerMask);

        if (detectPlayer.collider == null)
        {
            _isChasing = false;
        }
        else if (detectPlayer.collider.gameObject.tag == "Player")
        {
            _isChasing = true;
        }
        Debug.DrawRay(origin, dir * _enemy.DetectRange());
    }

    //void DrawRays()
    //{
    //    Debug.DrawRay(origin, dir * _enemy.DetectRange());
    //    Debug.DrawRay(origin, dir + (Vector2.up + dir * 7) / 8 * _enemy.DetectRange());
    //    Debug.DrawRay(origin, dir + (Vector2.down + dir * 7) / 8 * _enemy.DetectRange());
    //}

    void PlatformCheck()
    {
        Vector2 rayDir = Vector2.down;
        RaycastHit2D platformCheckHit = Physics2D.Raycast(origin, rayDir, 3);
        Debug.DrawRay(origin, rayDir, Color.red, 0.1f);

        Debug.Log(platformCheckHit.collider);
        if (platformCheckHit.collider == null)
        {
            Debug.Log("isNull");
            nextMove = -nextMove;
            //afterNoChasingTime = 2;
            //_isThinking = false;

            //StartCoroutine(EnemyNextThinkTime(3));

        }
    }
}
