using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item/Potion/HealingPotion")]
public class HealingPotion : UseItem
{
    public int healAmount;

    public override bool ExecuteRole()
    {
        //게임매니저에 플레이어 hp 연결해서 회복시키기
        Debug.Log($"힐?링 {healAmount}");
        return true;
    }

}
