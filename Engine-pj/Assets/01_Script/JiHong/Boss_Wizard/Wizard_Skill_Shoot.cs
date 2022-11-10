using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard_Skill_Shoot : MonoBehaviour
{
    Wizard_Movement Boss;
    private void Awake()
    {
        Boss = GetComponentInParent<Wizard_Movement>();
    }
    void Start()
    {

    }
    void Update()
    {
        StartCoroutine(Starting());
    }

    IEnumerator Starting()
    {
            StartCoroutine(StartSpin());
            yield return new WaitForSeconds(4);
            StartCoroutine(StartShot());
    }
    IEnumerator StartSpin()
    {
        float rotz=transform.rotation.z;
        float scale = 0.1f;
        transform.rotation = Quaternion.Euler(transform.rotation.x,transform.rotation.y,rotz);
        rotz += 1;
        if(scale!=1)
        {
                transform.localScale= new (scale,scale,1);
                scale += 0.01f;
        }
            yield return new WaitForSeconds(Time.deltaTime);
    }
    IEnumerator StartShot()
    {
            yield return new WaitForSeconds(Time.deltaTime);
    }
}
