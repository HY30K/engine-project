using System.Collections;
using System.Collections.Generic;
using UnityEngine;
enum SkillName //Wave �� �ĵ�������, Rain �� �񳻸��°Ű�����, Shoot�� rotation�������� �ѹ� �߻�(������)
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
    private void CoolTime() //��Ÿ�� ����
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
    private void ChangeRotation()  //�ٶ󺸴� ���� �ٲٱ�
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
    private void WarpDis()//�Ÿ� üũ (��������) - x��ǥ �ֺ� 3 , 8 / -8 �̻�/����
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
    private void Warp() //����
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
    int SkillCooltimeSet(int skill) //��ų ��Ÿ�� ���� + C#������ ���ٽ� �ذ�
    {
        return skill switch
        {
            1=>(int)SkillName.Wave,
            2=>(int)SkillName.Rain,
            3=>(int)SkillName.Shoot,
            _=> 0
        };
    }
    void Skill() //��ų�� üũ �׽�ų ���
    {
        skillCooltime+=Time.deltaTime;
        if(SkillCooltimeSet(skillnum) < skillCooltime&&warpCooltime<10&&warpCooltime>2)
        {
            skillCooltime = 0;
            SkillUse(skillnum);
            skillnum = Random.Range(1, 4);
        }
    }
    void SkillUse(int skill) // ���� ������ ����
    {
        GameObject thisskill = Instantiate(Skills[skill],this.transform);
        thisskill.transform.SetParent(this.transform);
    }
    //private void OnCollisionEnter2D(Collision2D collision) //�÷��̾� ���� ����
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
