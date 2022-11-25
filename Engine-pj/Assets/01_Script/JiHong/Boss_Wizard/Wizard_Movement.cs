using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
enum SkillName //Wave �� �ĵ�������, Rain �� �񳻸��°Ű�����, Shoot�� rotation�������� �ѹ� �߻�(������)
{
    Wave=6,Rain=11,Shoot=9
}
public class Wizard_Movement : MonoBehaviour
{
    GameObject player;
    Animator animator;
    private bool warpDistance=false;
    [SerializeField]
    private float warpCooltime = 0;
    [SerializeField]
    private float skillCooltime = 0;
    [SerializeField]
    private int skillnum;
    protected bool changeRot=false;
    protected float wizardHP = 40;
    [SerializeField]
    GameObject[] Skills;
    bool BFanimate = true;
    float upypos = -7.5f;
    float downypos = -18.5f;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
    }
    private void Start()
    {
        skillnum = Random.Range(1, 4);
        skillCooltime = 0;
    }
    void Update()
    {
        ChangeRotation();
        CoolTime();
        SkillController();
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
        if ((!(this.transform.position.x -3 > player.transform.position.x )&& this.transform.position.x >= 60) || 
            (!(this.transform.position.x +3 < player.transform.position.x )&&this.transform.position.x<=40 ))
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
        if (this.transform.position.x <= 40)
        {
            transform.position = new Vector2(Random.Range(60f,62f), Random.Range(0,2)<1?upypos:downypos);
        }
        else if(this.transform.position.x >= 60)
        {
            transform.position = new Vector2(Random.Range(38f,40f), Random.Range(0, 2) < 1 ? upypos : downypos);
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
    void SkillController() //��ų�� üũ �׽�ų ���
    {
        skillCooltime -= Time.deltaTime;
        if (0 >= skillCooltime)
        {
            if (skillnum == 1)
            {
                StartCoroutine(animations("Attack1", true));
                if (BFanimate)
                {
                    Invoke("Skill", 1);
                    BFanimate = false;
                }
            }
        }
    }
    void Skill()
    {
            GameObject thisskill = Instantiate(Skills[skillnum - 1]);
            thisskill.transform.SetParent(this.transform);
            skillnum = Random.Range(1, 4);
            skillCooltime = SkillCooltimeSet(skillnum);
        BFanimate = true;
    }
    IEnumerator animations(string animation,bool setbool)
    {
        animator.SetBool(animation, setbool);
        yield return new WaitForSeconds(0);
        animator.SetBool(animation, !setbool);
    }
    void SkillUse(int skill) // ���� ������ ����
    {
        GameObject thisskill = Instantiate(Skills[skill], this.transform);
        thisskill.transform.SetParent(this.transform);
    }
    //private void OnCollisionEnter2D(Collision2D collision) //�÷��̾� ���� ����
    //{
    //    if (collision.gameObject.CompareTag("PlayerAttack"))
    //    {
    //        animator.SetBool("Take hit", true);
    //        if (Random.Range(1, 11) < 3)
    //        {
    //            wizardHP -= 4;
    //        }
    //        else
    //            wizardHP -= 2;
    //    }
    //    if (wizardHP <= 0)
    //    {
    //        animator.SetBool("Death", true);
    //        Destroy(gameObject);
    //    }
    //}
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerAttack"))
        {
            animator.SetBool("Take hit", true);     
        }
    }
}
