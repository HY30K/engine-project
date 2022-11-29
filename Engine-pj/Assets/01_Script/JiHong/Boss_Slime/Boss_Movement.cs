using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Movement : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    Animator animator;
    Rigidbody2D rb;
    [SerializeField]
    GameObject attack_range;
    float bossHP=80;
    float ct;
    float skillcool = 6;
    float speed = 6f;
    int Skillnum = 0;
    [SerializeField]
    GameObject jumpParticle;
    bool sum_Particle = false;
    public LayerMask layermask;
    void Destroy()=> Destroy(gameObject);
    void Particleoff() => jumpParticle.SetActive(false);
    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        attack_range.SetActive(false);
        jumpParticle.SetActive(false);
        StartCoroutine(Move(player.transform.position.x));
        StartCoroutine(ChangeRotation());
    }
    private void Update()
    {
        if (sum_Particle)
        {
            animator.SetBool("Walk", true);
        }
        else
        {
            animator.SetBool("Walk", false);
        }
        ct += Time.deltaTime;
        if(Skillnum == 1)
        {
            Attack();
        }
        else if(Skillnum == 2)
        {
            Jump();
        }
        else
        {
            Skill_Set();
        }
    }
    void Skill_Set()
    {
        Skillnum = Random.Range(1, 3);
        if (Skillnum == 1)
        {
            if (bossHP < 40)
            {
                skillcool = 4;
            }
            else
            {
                skillcool = 7;
            }
        }
        else if (Skillnum == 2)
        {
            if (bossHP < 40)
            {
                skillcool = 6;
            }
            else
            {
                skillcool = 11;
            }
        }
        else { Skill_Set(); }
    }
    IEnumerator animations(string animation, bool setbool)
    {
        animator.SetBool(animation, setbool);
        yield return new WaitForSeconds(0.3f);
        animator.SetBool(animation, !setbool);
        yield return new WaitForSeconds(0.65f);
        if (animation == "Cleave")
        {
            attack_range.SetActive(true);
            yield return new WaitForSeconds(0.15f);
            attack_range.SetActive(false);
        }
    }
    IEnumerator Move(float transformx)
    {
        yield return new WaitForSeconds(0.1f);
        Vector3 dir;
        if (transformx < transform.position.x)
        {
            dir = Vector3.left*speed;
            animator.SetBool("Walk", true);
        }
        else if(transformx > transform.position.x)
        {
            dir = Vector3.right*speed;
            animator.SetBool("Walk", true);
        }
        else { dir = Vector3.zero; animator.SetBool("Walk", false); }
        transform.position += dir * Time.deltaTime;
        StartCoroutine(Move(player.transform.position.x));
    }
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.CompareTag("Player") && ct > 0.8f)
        {
            if (ct > 1)
            {  
                ct = 0;
                StartCoroutine(animations("Takehit", true));
                if (Random.Range(1, 11) < 3)
                {
                    bossHP -= 3;
                }
                else
                    bossHP -= 2;
            }
            if (bossHP <= 0)
            {
                animator.SetBool("Die", true);
                Invoke("Destroy", 2.2f);
            }
        }
        if(collision.gameObject.tag == "Ground" && sum_Particle)
        {
            Debug.Log("enter");
            sum_Particle = false;
            jumpParticle.SetActive(true);
            Invoke("Particleoff", 3);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        //if (collision.gameObject.tag == "Ground" && sum_Particle)
        //{
        //    Debug.Log("stay");
        //    sum_Particle = false;
        //    jumpParticle.SetActive(true);
        //    Invoke("Particleoff", 3);
        //}
    }
    IEnumerator ChangeRotation()  
    {
        if (player.transform.position.x > this.transform.position.x)
        {
            yield return new WaitForSeconds(0.1f);
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else if (player.transform.position.x < this.transform.position.x)
        {
            yield return new WaitForSeconds(0.1f);
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else
        {
           yield return new WaitForSeconds(0.1f);
        }
        StartCoroutine(ChangeRotation());
    }
    void Attack()
    {
        skillcool -= Time.deltaTime;
        if (skillcool < 0)
        {
            StartCoroutine(animations("Cleave", true));
            Skill_Set();
        }
    }
    void Jump()
    {
        skillcool -= Time.deltaTime;
        if(skillcool < 0)
        {
            rb.AddForce(Vector2.up * 13, ForceMode2D.Impulse);
            sum_Particle = true;
            Skill_Set();
        }
    }
}
