using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MineralType
{
    Ground,
    Rock,
    Coal,
    Silver,
    Gold,
    Diamond,
    Brown,
    Ruby,
    Emerald
}
public class MineralScript : MonoBehaviour
{
    public MineralType MineralType;
    public PlayerInput player; //오디오 실행때매 참조
    public float hp;

    PlayerProperty state;
    TerrainGeneration tg;

    private void Awake()
    {
        //SetType();
    }

    private void Update()
    {
         if(hp < 0)
         {
            player.OnMine?.Invoke();
            Destroy(gameObject);//나중에 풀링해줘야함
            //gameObject.SetActive(false);
            Debug.Log("광물hp 0");
         }
    }

    public void OnOreBreak()
    {
        if(hp < 0)
        {
            tg.isOreAlive[(int)transform.position.x, (int)transform.position.y] = false;// 해당위치에 bool값 false로 변환
            state.MiningDmg += 0.02f;
            //hp 0 일때 실행할것들
        }
    }

    public void DropItem()
    {
        switch (MineralType)
        {
            case MineralType.Ground:
                
                break;
            case MineralType.Rock:
                break;
            case MineralType.Coal:
                break;
            case MineralType.Silver:
                break;
            case MineralType.Gold:
                break;
            case MineralType.Diamond:
                break;
            case MineralType.Brown:
                break;
            case MineralType.Ruby:
                break;
            case MineralType.Emerald:
                break;

            default:
                break;
        }
    }

    public void SetType()// 광석 타입에따른 피통 지정
    {
    //    switch (MineralType)
    //    {
    //        case MineralType.Ground:
    //            hp = 1;
    //            break;
    //        case MineralType.Rock:
    //            hp = 2;
    //            break;
    //        case MineralType.Coal:
    //            hp = 3;
    //            break;
    //        case MineralType.Silver:
    //            hp = 4;
    //            break;
    //        case MineralType.Gold:
    //            hp = 5;
    //            break;
    //        case MineralType.Diamond:
    //            hp = 6;
    //            break;
    //    }
    }

}
