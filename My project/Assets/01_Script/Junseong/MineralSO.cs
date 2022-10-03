using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Mineral")]
public class MineralSO : ScriptableObject
{
    public string oreName;
    [SerializeField] float spawnPercent;
    [SerializeField] float canSpawnStartHeight;
    [SerializeField] float canSpawnEndHeight;
    [SerializeField] float oreHp;

    public float SpawnPercent()
    {
        return spawnPercent;
    }

    public float CanSpawnStartHeight()
    {
        return canSpawnStartHeight;
    }
    public float CanSpawnEndHeight()
    {
        return canSpawnEndHeight;
    }

    public float OreHp()
    {
        return oreHp;
    }

}
