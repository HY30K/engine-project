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

    private void Awake()
    {
        this.speed = _enemy.BeforeDetectSpeed();
        _rigid = GetComponent<Rigidbody2D>();
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

        dir = nextMove >= 0 ? Vector2.right : Vector2.left;
        origin = (Vector2)transform.position + (nextMove >= 0 ? Vector2.right : Vector2.left);

        DetectPlayer();

        if (_isChasing && !_enemyAttack._isAttack)
        {
            speed = _enemy.AfterDetectSpeed();
            _isCanDetectAttacking = true;
            afterNoChasingTime = 0;
        }
        //else if (_isChasing && _enemyAttack._isAttack)
        //{
        //    speed = 0;
        //}
        else if (!_isChasing)
        {
            speed = _enemy.BeforeDetectSpeed();
            _isCanDetectAttacking = false;
            PlatformCheck();
            afterNoChasingTime += Time.deltaTime;
            if (afterNoChasingTime > randThinkTime)
            {
                afterNoChasingTime = 0;
                EnemyThink();
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            nextMove = -nextMove;
        }
    }

    public void EnemyThink()
    {
        Debug.Log("ENemyTHinkOpen");
        nextMove = Random.Range(-1, 2);
        if (nextMove != 0)
        {
            randThinkTime = Random.Range(4f, 5f);
        }
        else
        {
            randThinkTime = Random.Range(1f, 2f);
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
            _isThinking = false;

            //StartCoroutine(EnemyNextThinkTime(3));

        }
    }
}
