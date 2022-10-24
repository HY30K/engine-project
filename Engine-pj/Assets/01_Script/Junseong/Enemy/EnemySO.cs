using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType
{
    NormalEnemy,
    ShieldEnemy,
    Boss
}
[CreateAssetMenu(menuName = "Asset/EnemySO")]
public class EnemySO : ScriptableObject
{
    public EnemyType enemyType;
    public string enemyName;
    [SerializeField] int hp;
    [SerializeField] int damage;
    [SerializeField] float beforeDetectSpeed;
    [SerializeField] float afterDetectSpeed;
    [SerializeField] float detectRange;
    [SerializeField] float attackRange;
    [SerializeField] float attackSpeed;
    [SerializeField] float attackDelay;

    public int HP() { return hp; }
    public int Damage() { return damage; }
    public float BeforeDetectSpeed() { return beforeDetectSpeed; }
    public float AfterDetectSpeed() { return afterDetectSpeed; }
    public float DetectRange() { return detectRange; }
    public float AttackRange() { return attackRange; }
    public float AttackSpeed() { return attackSpeed; }
    public float AttackDelay() { return attackDelay; }
}
