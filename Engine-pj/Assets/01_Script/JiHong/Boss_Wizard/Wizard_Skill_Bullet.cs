using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard_Skill_Bullet : MonoBehaviour
{
    float destroyTime = 0;
    
    private void Update()
    {
        destroyTime += Time.deltaTime;
        if (destroyTime > 8)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            DamaToPlayer();
            Destroy(this.gameObject);
        }
        //if (collision.gameObject.CompareTag("Player"))
        //{
        //    Destroy(this.gameObject);
        //}
    }
    void DamaToPlayer() //플레이어에게 데미지 주기
    {

    }
}
