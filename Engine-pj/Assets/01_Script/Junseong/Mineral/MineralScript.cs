using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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
public class MineralScript : PoolAbleMono
{
    public MineralType MineralType;
    public float hp;
    public string itemName;
    [SerializeField] GameManager gameManager;   
    TerrainGeneration tg;
    Item item;


    private void Update()
    {
         itemName = MineralType.ToString();
         if(hp < 0)
         {
            DropItem();
            Destroy(gameObject);//���߿� Ǯ���������
            Debug.Log("����hp 0");
         }
    }

    public void OnOreBreak()
    {
        if(hp < 0)
        {
            tg.isOreAlive[(int)transform.position.x, (int)transform.position.y] = false;// �ش���ġ�� bool�� false�� ��ȯ
            //state.MiningDmg += 0.02f;

            //hp 0 �϶� �����Ұ͵�
        }
    }

    public void DropItem()
    {
        Debug.Log("���� ������");
        item = PoolManager.Instance.Pop(itemName) as Item;
        item.transform.position = transform.position;
        Vector3 offset = Random.insideUnitCircle;
        if(offset.y < 0) offset.y = -offset.y;

        item.transform.DOJump(transform.position + offset, 0.5f, 1, 0.4f);
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

    public override void Init()
    {
        
    }
}
