using System.Collections;
using System.Collections.Generic;
using UnityEngine;
enum SkillName //Wave 는 파도같은거, Rain 은 비내리는거같은거, Shoot는 rotation값에따라 한번 발사(여러개)
{
    Wave=5,Rain=8,Shoot=6
}
public class Wizard_Movement : MonoBehaviour
{
    GameObject player;
    Animator animator;
    private bool warpDistance=false;
    private float warpCooltime = 0;
    private float skillCooltime = 0;
    private int skillnum;
    protected bool changeRot=false;
    protected float wizardHP = 40;
    [SerializeField]
    GameObject[] Skills;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
    }
    private void Start()
    {
        skillnum = Random.Range(1, 4);
    }
    void Update()
    {
        ChangeRotation();
        CoolTime();
        Skill();
    }   
    private void CoolTime() //쿨타임 세팅
    {
        WarpDis();
        if (warpCooltime < 0 && (warpDistance))
        {
            Warp();
            warpCooltime = 12;
        }
        else if (warpCooltime > 0) { warpCooltime -= Time.deltaTime; }
        else warpCooltime -= Time.deltaTime;
    }
    private void ChangeRotation()  //바라보는 방향 바꾸기
    {
        if (player.transform.position.x > this.transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            changeRot = true;
        }
        else if(player.transform.position.x < this.transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0f,180f,0f);
            changeRot=false;
        }
        else
        {
            new WaitForSeconds(0.1f);
        }
    }
    private void WarpDis()//거리 체크 (워프조건) - x좌표 주변 3 , 8 / -8 이상/이하
    {
        if ((!(this.transform.position.x -3 > player.transform.position.x )&& this.transform.position.x >= 8) || 
            (!(this.transform.position.x +3 < player.transform.position.x )&&this.transform.position.x<=-8 ))
        {
            warpDistance = true;
        }
        else
        {
            warpDistance = false;
        }
    }
    private void Warp() //워프
    {
        if (this.transform.position.x <= -6)
        {
            transform.position = new Vector2(Random.Range(8f,10f), this.transform.position.y);
        }
        else if(this.transform.position.x >= 6)
        {
            transform.position = new Vector2(Random.Range(-8f,-10f), this.transform.position.y);
        }
        warpDistance = false;
    }
    int SkillCooltimeSet(int skill) //스킬 쿨타임 세팅 + C#수행인 람다식 해결
    {
        return skill switch
        {
            1=>(int)SkillName.Wave,
            2=>(int)SkillName.Rain,
            3=>(int)SkillName.Shoot,
            _=> 0
        };
    }
    void Skill() //스킬쿨 체크 및스킬 사용
    {
        skillCooltime+=Time.deltaTime;
        if(SkillCooltimeSet(skillnum) < skillCooltime&&warpCooltime<10&&warpCooltime>2)
        {
            skillCooltime = 0;
            SkillUse(skillnum);
            skillnum = Random.Range(1, 4);
        }
    }
    void SkillUse(int skill) // 위에 병합할 예정
    {
        GameObject thisskill = Instantiate(Skills[skill],this.transform);
        thisskill.transform.SetParent(this.transform);
    }
    //private void OnCollisionEnter2D(Collision2D collision) //플레이어 공격 감지
    //{
    //    if (collision.gameObject.CompareTag("PlayerAttack"))
    //    {
    //        if(Random.Range(1, 11) < 3)
    //        {
    //            wizardHP -= 4;
    //        }
    //        else
    //        wizardHP -= 2;
    //    }
    //}
}
