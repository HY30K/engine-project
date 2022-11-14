using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard_RainingObject : MonoBehaviour
{
    Wizard_Skill_Rain Boss;
    Vector3 dir;
    float falling_Speed = 7;
    float destroyTime = 1;
    [SerializeField]
    int rand_value=0;
    int Rotateing(int input)
    {
        return input switch
        {
            0=>-1,
            1=>0,
            2=>1,
            _=>0    
        };
    }
    private void Awake()
    {
        Boss = GetComponentInParent<Wizard_Skill_Rain>();
    }
    void Start()
    {
        
        rand_value = Random.Range(0,3);
        SetStartTransform();
        if (rand_value == 1)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y - 180, -135);
        }
    }
    void Update()
    {
        if (!Boss.Upanimation)
        {
            Raining();
        }
        if (transform.position.y < Boss.transform.position.y)
        {
            StartCoroutine(DestroyCount());
        }
    }
    void SetStartTransform()
    {
        this.transform.position = new Vector2(Random.Range(this.transform.position.x - 0.2f, this.transform.position.x + 0.2f), 15);
        this.transform.rotation = Quaternion.Euler(this.transform.rotation.x, this.transform.rotation.y-180, -110);
    }
    void Raining()
    {
        dir = new Vector3(Rotateing(rand_value), - 3);  
        dir.Normalize();
        transform.position += dir * Time.deltaTime * falling_Speed;
    }
    IEnumerator DestroyCount()
    {
        yield return new WaitForSeconds(destroyTime);
        Destroy(gameObject);
    }
}
