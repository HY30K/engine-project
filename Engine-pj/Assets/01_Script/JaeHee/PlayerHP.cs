using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHP : MonoBehaviour
{
    public UnityEvent Dead;
    [field: SerializeField] public UnityEvent OnHit { get; set; }

    Rigidbody2D _rigid;
    SpriteRenderer _spriteRenderer;
    
    public int damagedPosition = 0;
    public int damagedAddForceXValue = 5;
    public int damagedAddForceYValue = 5;

    private void Awake()
    {
        _rigid = transform.parent.GetComponent<Rigidbody2D>();    
        _spriteRenderer = gameObject.transform.parent.GetChild(0).GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyWeapon")){
            Debug.Log(GameManager.instance);
            Debug.Log(GameManager.instance.Health);
            if (GameManager.instance.Health > 0)
            {
                if (collision.transform.root.name != "FlyingEye")
                {
                    GameManager.instance.Health -= collision.transform.parent.GetComponent<EnemyAttack>().damage;
                }
                else
                {
                    GameManager.instance.Health -= collision.transform.parent.parent.GetComponent<EnemyAttack>().damage;
                    Debug.Log(collision.gameObject.name);
                    //throw new Exception("ÀÌ¹Ì Á×À½");
                }
                damagedPosition = (transform.position.x > collision.transform.position.x) ? 1 : -1;  
                PlayerHit();
            }
            else
            {
                PlayerDead();
            }
        }
        if (collision.CompareTag("Enemy"))
        {
            if(GameManager.instance.Health > 0)
            {
                GameManager.instance.Health -= 5;
                PlayerHit();
            }
            else
            {
                PlayerDead();
            }
        }
    }

    private void PlayerHit()
    {
        OnHit.Invoke();
    }
    private void PlayerDead()
    {
        Dead?.Invoke();
    }

    public void DeadInit()
    {
        transform.parent.GetComponent<PlayerInput>().enabled = false;
        transform.parent.GetComponent<InvenActiveChange>().enabled = false;
        transform.GetComponent<CapsuleCollider2D>().enabled = false;
    }

    public void PlayerHitAddForce()
    {
        Vector2 force = new Vector2(damagedPosition * damagedAddForceXValue, damagedAddForceYValue);
        _rigid.AddForce(force, ForceMode2D.Impulse);
    }
    public void PlayerDontDamage()
    {
        StartCoroutine("PlayerChangeLayer");
    }

    //public void PlayerOnDamagedTwinkle()
    //{
    //    _spriteRenderer.color = new Color(1, 1, 1, 1f);
    //}

    IEnumerator PlayerChangeLayer()
    {
        //transform.gameObject.layer = LayerMask.NameToLayer("EnemyDontDamage");
        gameObject.layer = LayerMask.NameToLayer("PlayerDontDamage");
        _spriteRenderer.color = new Color(1, 1, 1, 0.4f);
        yield return new WaitForSeconds(1f);
        _spriteRenderer.color = new Color(1, 1, 1, 1f);
        gameObject.layer = LayerMask.NameToLayer("PlayerHitBox");

    }
}
