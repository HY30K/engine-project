using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHpManager : EnemyBase
{
    int hp;
    int damage;

    private void Awake()
    {
        this.hp = _enemy.HP();
        this.damage = _enemy.Damage();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //적 창에 맞았을때 피깍아줌
        //장애물이 있다면 장애물에 맞았을때 피깍임
    }


}
