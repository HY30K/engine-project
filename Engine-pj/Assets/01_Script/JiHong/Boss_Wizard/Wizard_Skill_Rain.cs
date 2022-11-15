using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard_Skill_Rain : MonoBehaviour
{
    [SerializeField]
    Transform wizard_Transform;
    GameObject player;
    public int rotation_y;
    Transform child_transform;
    Transform Startobj_transform;
    [SerializeField]
    GameObject StartObjeset;
    [SerializeField]
    GameObject[] rainObject;
    float speed=4;
    public bool Upanimation= true;
    int rotate(int rotation) => rotation==0 ? -1 : 1;   
    private void Awake()
    {
        wizard_Transform = this.GetComponentInParent<Transform>();
        player = GameObject.FindGameObjectWithTag("Player");
        child_transform = GetComponentInChildren<Transform>();
    }
    private void Start()
    {
        this.transform.position = wizard_Transform.position;
        SetDirection();
        StartCoroutine(Skill());
        SetRandomPosition(); 
        foreach (GameObject obj in rainObject)
        {
            obj.SetActive(false);
        }
    }
    private void Update() 
    {
        wizard_Transform = this.GetComponentInParent<Transform>();
        GoUpAnimate();
    }
    void GoUpAnimate()
    {
        if(Upanimation) StartCoroutine(AnimationAsGameobject());
        else StopCoroutine(AnimationAsGameobject());
    }
    IEnumerator AnimationAsGameobject()
    {
        yield return new WaitForSeconds(0.4f);
        StartObjeset.transform.position += Vector3.up*Time.deltaTime*speed;
        yield return new WaitForSeconds(3);
        StartObjeset.SetActive(false);
        foreach (GameObject obj in rainObject)
        {
            obj.SetActive(true);
        }
        Upanimation = false;
    }
    void SetDirection()
    {
        if (wizard_Transform.position.x < player.transform.position.x)
        {
            rotation_y = 180;
            child_transform.rotation = Quaternion.Euler(0, rotation_y, 0);
        }
        else
        {
            rotation_y = 0;
            child_transform.rotation = Quaternion.Euler(0, rotation_y,0);
        }
    }
    void SetRandomPosition()
    {
        int i = 0;
        foreach (GameObject obj in rainObject)
        {
            obj.SetActive(true);
            obj.transform.position = new Vector2((2*i*rotate(rotation_y))-2, 12); //Random.Range(i-3,i+3)
            obj.transform.SetParent(this.gameObject.transform);
            ++i;
        }
    }
    IEnumerator Skill()
    {
        yield return new WaitForSeconds(1);
    }
    
}
