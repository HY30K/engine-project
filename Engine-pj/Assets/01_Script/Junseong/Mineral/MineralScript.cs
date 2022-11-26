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
    public PlayerInput player; //����� ���ට�� ����
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
            Destroy(gameObject);//���߿� Ǯ���������
            //gameObject.SetActive(false);
            Debug.Log("����hp 0");
         }
    }

    public void OnOreBreak()
    {
        if(hp < 0)
        {
            tg.isOreAlive[(int)transform.position.x, (int)transform.position.y] = false;// �ش���ġ�� bool�� false�� ��ȯ
            state.MiningDmg += 0.02f;
            //hp 0 �϶� �����Ұ͵�
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

    public void SetType()// ���� Ÿ�Կ����� ���� ����
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
